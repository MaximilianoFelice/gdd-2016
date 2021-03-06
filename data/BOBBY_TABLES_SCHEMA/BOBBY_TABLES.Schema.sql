USE [GD1C2016]
GO
CREATE SCHEMA [BOBBY_TABLES] AUTHORIZATION [gd]
GO

/* ---------------------- */
/* TABLE DEFINITION ZONE  */
/* ---------------------- */

CREATE TABLE [BOBBY_TABLES].ROLES (
id_role INTEGER NOT NULL IDENTITY(1,1),
name VARCHAR(100) NOT NULL,
inactive BIT DEFAULT(0x0) NOT NULL,
PRIMARY KEY (id_role),
UNIQUE (name)
);

CREATE TABLE [BOBBY_TABLES].USER_ROLES (
id_user INTEGER NOT NULL,
id_role INTEGER NOT NULL,
PRIMARY KEY(id_user, id_role)
);

CREATE TABLE [BOBBY_TABLES].FEATURES (
id_feature INTEGER NOT NULL IDENTITY(1,1),			-- Handles it's own codification system
descr VARCHAR(255),
inactive BIT DEFAULT(0x0) NOT NULL,
PRIMARY KEY (id_feature),
UNIQUE(descr)
);

CREATE TABLE [BOBBY_TABLES].FEATURES_ROLES (
id_role INTEGER NOT NULL,
id_feature INTEGER NOT NULL,
PRIMARY KEY (id_role, id_feature)
);

CREATE TABLE [BOBBY_TABLES].USERS (
id_user INTEGER NOT NULL IDENTITY(1,1),
username VARCHAR(50) NOT NULL,
pass VARCHAR(64) NOT NULL,
login_attempts NUMERIC(1,0) NOT NULL DEFAULT(0),
inactive BIT DEFAULT(0x0) NOT NULL,
deleted BIT DEFAULT(0x0) NOT NULL,
UNIQUE (username),
PRIMARY KEY(id_user)
);

CREATE TABLE [BOBBY_TABLES].STAT (			-- Must replace IF NECESSARY timestamp and username
id_stat INTEGER NOT NULL,					-- Handles it's own codification system
descr VARCHAR(255) NOT NULL,
comments VARCHAR(255),
PRIMARY KEY (id_stat)
);


/* -------------------------- */
/* VIEWS CRATION ZONE         */
/* -------------------------- */
GO
CREATE VIEW [BOBBY_TABLES].ACTIVE_USERS AS
SELECT id_user, username, pass, login_attempts  FROM [BOBBY_TABLES].USERS WHERE 
	(inactive = 0x0) AND (deleted = 0x0) AND (login_attempts < 3)	
GO
GO
CREATE VIEW [BOBBY_TABLES].DELETED_USERS AS
SELECT id_user, username, pass, login_attempts  FROM [BOBBY_TABLES].USERS WHERE 
	(deleted = 0x1)
GO
GO
CREATE VIEW [BOBBY_TABLES].INACTIVE_USERS AS
SELECT id_user, username, pass, login_attempts  FROM [BOBBY_TABLES].USERS WHERE 
	(inactive = 0x1)	
GO

GO
CREATE VIEW [BOBBY_TABLES].ACTIVE_FEATURES AS
SELECT * FROM BOBBY_TABLES.FEATURES WHERE (inactive = 0x0);
GO
GO
CREATE VIEW [BOBBY_TABLES].ACTIVE_ROLES AS
SELECT * FROM BOBBY_TABLES.ROLES WHERE (inactive = 0x0);
GO


/* -------------------------- */
/* TRIGGERS CRATION ZONE      */
/* -------------------------- */
GO
CREATE TRIGGER [BOBBY_TABLES].CHECK_USER_ATTEMPTS
ON [BOBBY_TABLES].USERS
FOR UPDATE
AS
	DECLARE @ATTEMPTS INTEGER;
	DECLARE @ID_USER INTEGER;
	
	SELECT @ATTEMPTS=login_attempts, @ID_USER=id_user FROM inserted;
	
	IF ( @ATTEMPTS  >= 3 )
		UPDATE [BOBBY_TABLES].USERS 
		SET inactive = 0x1
		WHERE id_user = @ID_USER;
GO

/* Set feature inactive instead of deleting */
GO
CREATE TRIGGER [BOBBY_TABLES].DELETE_FEATURE
ON [BOBBY_TABLES].ACTIVE_FEATURES
INSTEAD OF DELETE
AS
BEGIN
	UPDATE [BOBBY_TABLES].FEATURES SET inactive=0x1 WHERE id_feature = (SELECT d.id_feature FROM deleted d);
END
GO

GO
CREATE TRIGGER [BOBBY_TABLES].DELETE_FEATURE_PROT
ON [BOBBY_TABLES].FEATURES
INSTEAD OF DELETE
AS
BEGIN
	UPDATE [BOBBY_TABLES].FEATURES SET inactive=0x1 WHERE id_feature = (SELECT d.id_feature FROM deleted d);
END
GO

/* Set role inactive instead of deleting */
GO
CREATE TRIGGER [BOBBY_TABLES].DELETE_ROLE
ON [BOBBY_TABLES].ACTIVE_ROLES
INSTEAD OF DELETE
AS
BEGIN
	UPDATE [BOBBY_TABLES].ROLES SET inactive=0x1 WHERE id_role = (SELECT d.id_role FROM deleted d);
END
GO

GO
CREATE TRIGGER [BOBBY_TABLES].DELETE_ROLE_PROT
ON [BOBBY_TABLES].ROLES
INSTEAD OF DELETE
AS
BEGIN
	UPDATE [BOBBY_TABLES].ROLES SET inactive=0x1 WHERE id_role = (SELECT d.id_role FROM deleted d);
END
GO

/* -------------------------- */
/* RELATIONS DEFINITION ZONE  */
/* -------------------------- */

/* ADDING FOREIGN KEYS TO STATUS */

/* ADDING MANY TO MANY FOREIGN KEYS */
ALTER TABLE [BOBBY_TABLES].FEATURES_ROLES
ADD FOREIGN KEY(id_role) REFERENCES [BOBBY_TABLES].ROLES(id_role),
	FOREIGN KEY(id_feature) REFERENCES [BOBBY_TABLES].FEATURES(id_feature);
	
ALTER TABLE [BOBBY_TABLES].USER_ROLES
ADD FOREIGN KEY(id_user) REFERENCES [BOBBY_TABLES].USERS(id_user),
	FOREIGN KEY(id_role) REFERENCES [BOBBY_TABLES].ROLES(id_role);
	

/* ADDING ONE TO MANY RELATIONS */


/* ADDING ONE TO ONE RELATIONS */


/* ----------------------- */
/* DEFAULT DATA LOAD ZONE  */
/* ----------------------- */

/* Adding new Status */
BEGIN TRANSACTION
	INSERT INTO [BOBBY_TABLES].STAT (id_stat, descr)
			VALUES (301, 'Active User');
	INSERT INTO [BOBBY_TABLES].STAT (id_stat, descr)
			VALUES (302, 'Inactive User');
	INSERT INTO [BOBBY_TABLES].STAT (id_stat, descr)
			VALUES (303, 'Deleted User');
	INSERT INTO [BOBBY_TABLES].STAT (id_stat, descr)
			VALUES (304, 'Blocked User');
COMMIT

/* Adding new Roles */
BEGIN TRANSACTION
	INSERT	INTO [BOBBY_TABLES].ROLES(name)
			VALUES ('admin');
	INSERT	INTO [BOBBY_TABLES].ROLES(name)
			VALUES ('guest');
	INSERT	INTO [BOBBY_TABLES].ROLES(name)
			VALUES ('other');
COMMIT

/* Adding new Features */
BEGIN TRANSACTION
	INSERT INTO BOBBY_TABLES.FEATURES(descr) 
				VALUES ('Admin');
	INSERT INTO BOBBY_TABLES.FEATURES(descr) 
				VALUES ('Guest');
	INSERT INTO BOBBY_TABLES.FEATURES(descr) 
				VALUES ('Other');
COMMIT

/* Adding relations Roles-Features */
BEGIN TRANSACTION
	INSERT INTO BOBBY_TABLES.FEATURES_ROLES (id_role, id_feature)
		VALUES (1, 1);
	INSERT INTO BOBBY_TABLES.FEATURES_ROLES (id_role, id_feature)
		VALUES (2, 2);
	INSERT INTO BOBBY_TABLES.FEATURES_ROLES (id_role, id_feature)
		VALUES (3, 3);
COMMIT

/* Adding new Admin */  
-- Password: 'maximilianofelice' 
-- HASH: 53acbedaad48d8d482fe1a9bf8cd8b8e329ff8033c5c1dc81dcccdff38dd197f
BEGIN TRANSACTION
	INSERT	INTO [BOBBY_TABLES].USERS (username, pass)
			VALUES ('MaximilianoFelice', '53acbedaad48d8d482fe1a9bf8cd8b8e329ff8033c5c1dc81dcccdff38dd197f');
COMMIT

/* Adding new Other */  
-- Password: 'recept' 
-- HASH: 2e28ec6123cdea7edf950d6e594a0ae289ac531265c1e6a38a2815076eead077
BEGIN TRANSACTION
	INSERT	INTO [BOBBY_TABLES].USERS (username, pass)
			VALUES ('Other', '2e28ec6123cdea7edf950d6e594a0ae289ac531265c1e6a38a2815076eead077');
COMMIT

/* Adding Guest user */  
-- Password: 'guest' 
-- HASH: 84983c60f7daadc1cb8698621f802c0d9f9a3c3c295c810748fb048115c186ec
BEGIN TRANSACTION
	INSERT	INTO [BOBBY_TABLES].USERS (username, pass)
			VALUES ('Guest', '84983c60f7daadc1cb8698621f802c0d9f9a3c3c295c810748fb048115c186ec');
COMMIT

/* Adding Roles to Users */
BEGIN TRANSACTION
	INSERT	INTO [BOBBY_TABLES].USER_ROLES (id_role, id_user)
			VALUES (1, 1);
	INSERT	INTO [BOBBY_TABLES].USER_ROLES (id_role, id_user)
			VALUES (2, 3);
	INSERT	INTO [BOBBY_TABLES].USER_ROLES (id_role, id_user)
			VALUES (3, 2);
COMMIT


/* -------------------------------------- */
/*        MIGRATION ZONE HERE             */
/*             ...(SUCH IMPORTANCE, WOW!) */
/* -------------------------------------- */
BEGIN TRANSACTION
COMMIT

/* --------------------------- */
/* PROCEDURES DEFINITION ZONE  */
/* --------------------------- */

/* Creating Procedure to get features by roles */
GO
CREATE PROCEDURE [BOBBY_TABLES].GetRoleFeatures(
@Role INT = NULL, @RoleName VARCHAR(100) = NULL
)
AS
	SELECT * FROM [BOBBY_TABLES].ACTIVE_FEATURES feat 
			INNER JOIN [BOBBY_TABLES].FEATURES_ROLES fr ON (feat.id_feature = fr.id_feature)
			INNER JOIN [BOBBY_TABLES].ACTIVE_ROLES roles ON (roles.id_role = fr.id_role)
	WHERE (@Role IS NULL OR roles.id_role = @Role) AND (@RoleName IS NULL OR roles.name = @RoleName);
GO

/* Creating Procedure to get roles by username */
GO
CREATE PROCEDURE [BOBBY_TABLES].GetUserRoles(
@username VARCHAR(50)
)
AS
	SELECT * FROM BOBBY_TABLES.ACTIVE_USERS u
			INNER JOIN BOBBY_TABLES.USER_ROLES ur ON (ur.id_user = u.id_user)
			INNER JOIN BOBBY_TABLES.ACTIVE_ROLES r ON (ur.id_role = r.id_role)
	WHERE (u.username = @username);
GO

/* Creating procedure that validate user login */
GO
CREATE PROCEDURE [BOBBY_TABLES].validateUserPass (
@User VARCHAR(50), 
@Pass VARCHAR(64),
@Login_Attempts INTEGER = -1 OUTPUT,
@RESULT BIT = 0x0 OUTPUT )
AS
	DECLARE @Current_Pass VARCHAR(64);
	
	/* Checking if Username Exists */
	
	SET @Login_Attempts = -1;
	
	SELECT @Current_Pass=u.pass, @Login_Attempts=u.login_attempts FROM [BOBBY_TABLES].ACTIVE_USERS u WHERE username = @User;
	
	SET @RESULT = 0x0;
	
	IF @@ROWCOUNT > 0
	BEGIN
		IF @Pass = @Current_Pass
			BEGIN
				UPDATE [BOBBY_TABLES].ACTIVE_USERS	
				SET login_attempts = 0
				WHERE username = @User;
				SET @RESULT = 0x1;
				SET @Login_Attempts = 0;
				EXEC [BOBBY_TABLES].GetUserRoles @User;
			END
		ELSE
			BEGIN
				SET @Login_Attempts = @Login_Attempts + 1;
				UPDATE [BOBBY_TABLES].ACTIVE_USERS	
				SET login_attempts = @Login_Attempts
				WHERE username = @User;
			END
	END
	ELSE
		SET @Login_Attempts = -1;
	
GO
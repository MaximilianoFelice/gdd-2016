namespace HotelModel.User_Permissions.UI
{
    partial class frmRoles
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblChooseRole = new System.Windows.Forms.Label();
            this.cboActiveRole = new System.Windows.Forms.ComboBox();
            this.clbFeatures = new System.Windows.Forms.CheckedListBox();
            this.lblChooseFeatures = new System.Windows.Forms.Label();
            this.cmdRemoveFeature = new System.Windows.Forms.Button();
            this.cmdExit = new System.Windows.Forms.Button();
            this.cmdAddFeature = new System.Windows.Forms.Button();
            this.cmdAddRole = new System.Windows.Forms.Button();
            this.cmdDeleteRole = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblChooseRole
            // 
            this.lblChooseRole.AutoSize = true;
            this.lblChooseRole.Location = new System.Drawing.Point(15, 24);
            this.lblChooseRole.Name = "lblChooseRole";
            this.lblChooseRole.Size = new System.Drawing.Size(71, 13);
            this.lblChooseRole.TabIndex = 0;
            this.lblChooseRole.Text = "Choose Role:";
            // 
            // cboActiveRole
            // 
            this.cboActiveRole.FormattingEnabled = true;
            this.cboActiveRole.Location = new System.Drawing.Point(92, 21);
            this.cboActiveRole.Name = "cboActiveRole";
            this.cboActiveRole.Size = new System.Drawing.Size(180, 21);
            this.cboActiveRole.TabIndex = 1;
            this.cboActiveRole.SelectedIndexChanged += new System.EventHandler(this.cboActiveRole_SelectedIndexChanged);
            // 
            // clbFeatures
            // 
            this.clbFeatures.FormattingEnabled = true;
            this.clbFeatures.Location = new System.Drawing.Point(27, 91);
            this.clbFeatures.Name = "clbFeatures";
            this.clbFeatures.Size = new System.Drawing.Size(335, 424);
            this.clbFeatures.TabIndex = 2;
            // 
            // lblChooseFeatures
            // 
            this.lblChooseFeatures.AutoSize = true;
            this.lblChooseFeatures.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChooseFeatures.Location = new System.Drawing.Point(88, 68);
            this.lblChooseFeatures.Name = "lblChooseFeatures";
            this.lblChooseFeatures.Size = new System.Drawing.Size(140, 20);
            this.lblChooseFeatures.TabIndex = 3;
            this.lblChooseFeatures.Text = "Available Features";
            // 
            // cmdRemoveFeature
            // 
            this.cmdRemoveFeature.Location = new System.Drawing.Point(125, 521);
            this.cmdRemoveFeature.Name = "cmdRemoveFeature";
            this.cmdRemoveFeature.Size = new System.Drawing.Size(60, 30);
            this.cmdRemoveFeature.TabIndex = 5;
            this.cmdRemoveFeature.Text = "Remove";
            this.cmdRemoveFeature.UseVisualStyleBackColor = true;
            this.cmdRemoveFeature.Click += new System.EventHandler(this.cmdRemoveFeature_Click);
            // 
            // cmdExit
            // 
            this.cmdExit.Location = new System.Drawing.Point(309, 521);
            this.cmdExit.Name = "cmdExit";
            this.cmdExit.Size = new System.Drawing.Size(53, 30);
            this.cmdExit.TabIndex = 6;
            this.cmdExit.Text = "Exit";
            this.cmdExit.UseVisualStyleBackColor = true;
            this.cmdExit.Click += new System.EventHandler(this.cmdExit_Click);
            // 
            // cmdAddFeature
            // 
            this.cmdAddFeature.Location = new System.Drawing.Point(38, 521);
            this.cmdAddFeature.Name = "cmdAddFeature";
            this.cmdAddFeature.Size = new System.Drawing.Size(60, 30);
            this.cmdAddFeature.TabIndex = 7;
            this.cmdAddFeature.Text = "Add";
            this.cmdAddFeature.UseVisualStyleBackColor = true;
            this.cmdAddFeature.Click += new System.EventHandler(this.cmdAddFeature_Click);
            // 
            // cmdAddRole
            // 
            this.cmdAddRole.Location = new System.Drawing.Point(278, 12);
            this.cmdAddRole.Name = "cmdAddRole";
            this.cmdAddRole.Size = new System.Drawing.Size(39, 38);
            this.cmdAddRole.TabIndex = 8;
            this.cmdAddRole.Text = "Add";
            this.cmdAddRole.UseVisualStyleBackColor = true;
            this.cmdAddRole.Click += new System.EventHandler(this.cmdAddRole_Click);
            // 
            // cmdDeleteRole
            // 
            this.cmdDeleteRole.Location = new System.Drawing.Point(323, 12);
            this.cmdDeleteRole.Name = "cmdDeleteRole";
            this.cmdDeleteRole.Size = new System.Drawing.Size(39, 38);
            this.cmdDeleteRole.TabIndex = 9;
            this.cmdDeleteRole.Text = "Del";
            this.cmdDeleteRole.UseVisualStyleBackColor = true;
            this.cmdDeleteRole.Click += new System.EventHandler(this.cmdDeleteRole_Click);
            // 
            // frmRoles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 568);
            this.Controls.Add(this.cmdDeleteRole);
            this.Controls.Add(this.cmdAddRole);
            this.Controls.Add(this.cmdAddFeature);
            this.Controls.Add(this.cmdExit);
            this.Controls.Add(this.cmdRemoveFeature);
            this.Controls.Add(this.lblChooseFeatures);
            this.Controls.Add(this.clbFeatures);
            this.Controls.Add(this.cboActiveRole);
            this.Controls.Add(this.lblChooseRole);
            this.Name = "frmRoles";
            this.Text = "Role Manager";
            this.Load += new System.EventHandler(this.frmRoles_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblChooseRole;
        private System.Windows.Forms.ComboBox cboActiveRole;
        private System.Windows.Forms.CheckedListBox clbFeatures;
        private System.Windows.Forms.Label lblChooseFeatures;
        private System.Windows.Forms.Button cmdRemoveFeature;
        private System.Windows.Forms.Button cmdExit;
        private System.Windows.Forms.Button cmdAddFeature;
        private System.Windows.Forms.Button cmdAddRole;
        private System.Windows.Forms.Button cmdDeleteRole;
    }
}
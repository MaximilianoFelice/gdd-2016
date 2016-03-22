namespace HotelModel.User_Permissions.tests.ResourceForms
{
    partial class Integration_Form_Test
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
            this.selectedRole = new System.Windows.Forms.ComboBox();
            this.lblRole = new System.Windows.Forms.Label();
            this.lblFeatures = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lstFeatures = new System.Windows.Forms.ListBox();
            this.cmdAdminVisible = new System.Windows.Forms.Button();
            this.cmdRecepcionistaVisible = new System.Windows.Forms.Button();
            this.cmdAdminEnabled = new System.Windows.Forms.Button();
            this.cmdRecepcionistaEnabled = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // selectedRole
            // 
            this.selectedRole.FormattingEnabled = true;
            this.selectedRole.Location = new System.Drawing.Point(91, 5);
            this.selectedRole.Name = "selectedRole";
            this.selectedRole.Size = new System.Drawing.Size(147, 21);
            this.selectedRole.TabIndex = 0;
            this.selectedRole.SelectedIndexChanged += new System.EventHandler(this.selectedRole_SelectedIndexChanged);
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Location = new System.Drawing.Point(11, 8);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(65, 13);
            this.lblRole.TabIndex = 1;
            this.lblRole.Text = "Active Role:";
            // 
            // lblFeatures
            // 
            this.lblFeatures.AutoSize = true;
            this.lblFeatures.Location = new System.Drawing.Point(11, 40);
            this.lblFeatures.Name = "lblFeatures";
            this.lblFeatures.Size = new System.Drawing.Size(84, 13);
            this.lblFeatures.TabIndex = 3;
            this.lblFeatures.Text = "Active Features:";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(505, 13);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(58, 13);
            this.lblUsername.TabIndex = 4;
            this.lblUsername.Text = "Username:";
            // 
            // lstFeatures
            // 
            this.lstFeatures.FormattingEnabled = true;
            this.lstFeatures.Location = new System.Drawing.Point(91, 32);
            this.lstFeatures.Name = "lstFeatures";
            this.lstFeatures.Size = new System.Drawing.Size(179, 134);
            this.lstFeatures.TabIndex = 6;
            // 
            // cmdAdminVisible
            // 
            this.cmdAdminVisible.Location = new System.Drawing.Point(42, 206);
            this.cmdAdminVisible.Name = "cmdAdminVisible";
            this.cmdAdminVisible.Size = new System.Drawing.Size(122, 60);
            this.cmdAdminVisible.TabIndex = 7;
            this.cmdAdminVisible.Text = "button1";
            this.cmdAdminVisible.UseVisualStyleBackColor = true;
            // 
            // cmdRecepcionistaVisible
            // 
            this.cmdRecepcionistaVisible.Location = new System.Drawing.Point(263, 208);
            this.cmdRecepcionistaVisible.Name = "cmdRecepcionistaVisible";
            this.cmdRecepcionistaVisible.Size = new System.Drawing.Size(180, 57);
            this.cmdRecepcionistaVisible.TabIndex = 8;
            this.cmdRecepcionistaVisible.Text = "button1";
            this.cmdRecepcionistaVisible.UseVisualStyleBackColor = true;
            // 
            // cmdAdminEnabled
            // 
            this.cmdAdminEnabled.Location = new System.Drawing.Point(42, 306);
            this.cmdAdminEnabled.Name = "cmdAdminEnabled";
            this.cmdAdminEnabled.Size = new System.Drawing.Size(122, 60);
            this.cmdAdminEnabled.TabIndex = 9;
            this.cmdAdminEnabled.Text = "button1";
            this.cmdAdminEnabled.UseVisualStyleBackColor = true;
            // 
            // cmdRecepcionistaEnabled
            // 
            this.cmdRecepcionistaEnabled.Location = new System.Drawing.Point(263, 306);
            this.cmdRecepcionistaEnabled.Name = "cmdRecepcionistaEnabled";
            this.cmdRecepcionistaEnabled.Size = new System.Drawing.Size(180, 57);
            this.cmdRecepcionistaEnabled.TabIndex = 10;
            this.cmdRecepcionistaEnabled.Text = "button1";
            this.cmdRecepcionistaEnabled.UseVisualStyleBackColor = true;
            // 
            // Integration_Form_Test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 419);
            this.Controls.Add(this.cmdRecepcionistaEnabled);
            this.Controls.Add(this.cmdAdminEnabled);
            this.Controls.Add(this.cmdRecepcionistaVisible);
            this.Controls.Add(this.cmdAdminVisible);
            this.Controls.Add(this.lstFeatures);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.lblFeatures);
            this.Controls.Add(this.lblRole);
            this.Controls.Add(this.selectedRole);
            this.Name = "Integration_Form_Test";
            this.Text = "Integration_Form_Test";
            this.Load += new System.EventHandler(this.Integration_Form_Test_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox selectedRole;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.Label lblFeatures;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.ListBox lstFeatures;
        private System.Windows.Forms.Button cmdAdminVisible;
        private System.Windows.Forms.Button cmdRecepcionistaVisible;
        private System.Windows.Forms.Button cmdAdminEnabled;
        private System.Windows.Forms.Button cmdRecepcionistaEnabled;
    }
}
namespace Resources.User_Permissions.tests.ResourceForms
{
    partial class Attribute_tests_form
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
            this.handledButton1 = new Resources.User_Permissions.HandledControls.HandledButton();
            this.button1 = new System.Windows.Forms.Button();
            this.onlyAccessButton = new Resources.User_Permissions.HandledControls.HandledButton();
            this.onlyVisibleButton = new Resources.User_Permissions.HandledControls.HandledButton();
            this.SuspendLayout();
            // 
            // handledButton1
            // 
            this.handledButton1.HandlesAccess = true;
            this.handledButton1.HandlesVisibility = true;
            this.handledButton1.Location = new System.Drawing.Point(71, 97);
            this.handledButton1.Name = "handledButton1";
            this.handledButton1.Size = new System.Drawing.Size(142, 100);
            this.handledButton1.TabIndex = 0;
            this.handledButton1.Text = "handledButton1";
            this.handledButton1.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(45, 31);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // onlyAccessButton
            // 
            this.onlyAccessButton.HandlesAccess = true;
            this.onlyAccessButton.HandlesVisibility = false;
            this.onlyAccessButton.Location = new System.Drawing.Point(239, 12);
            this.onlyAccessButton.Name = "onlyAccessButton";
            this.onlyAccessButton.Size = new System.Drawing.Size(104, 61);
            this.onlyAccessButton.TabIndex = 2;
            this.onlyAccessButton.Text = "handledButton2";
            this.onlyAccessButton.UseVisualStyleBackColor = true;
            // 
            // onlyVisibleButton
            // 
            this.onlyVisibleButton.HandlesAccess = false;
            this.onlyVisibleButton.HandlesVisibility = true;
            this.onlyVisibleButton.Location = new System.Drawing.Point(267, 121);
            this.onlyVisibleButton.Name = "onlyVisibleButton";
            this.onlyVisibleButton.Size = new System.Drawing.Size(118, 58);
            this.onlyVisibleButton.TabIndex = 3;
            this.onlyVisibleButton.Text = "handledButton2";
            this.onlyVisibleButton.UseVisualStyleBackColor = true;
            // 
            // Attribute_tests_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 489);
            this.Controls.Add(this.onlyVisibleButton);
            this.Controls.Add(this.onlyAccessButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.handledButton1);
            this.Name = "Attribute_tests_form";
            this.Text = "Attribute_tests";
            this.Load += new System.EventHandler(this.Attribute_tests_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Resources.User_Permissions.HandledControls.HandledButton handledButton1;
        private System.Windows.Forms.Button button1;
        private Resources.User_Permissions.HandledControls.HandledButton onlyAccessButton;
        private Resources.User_Permissions.HandledControls.HandledButton onlyVisibleButton;
    }
}
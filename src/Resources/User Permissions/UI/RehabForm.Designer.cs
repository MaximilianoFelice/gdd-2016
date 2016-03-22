namespace HotelModel.User_Permissions.UI
{
    partial class RehabForm
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
            this.clbRehab = new System.Windows.Forms.CheckedListBox();
            this.lblInfo = new System.Windows.Forms.Label();
            this.cmdExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // clbRehab
            // 
            this.clbRehab.FormattingEnabled = true;
            this.clbRehab.Location = new System.Drawing.Point(24, 54);
            this.clbRehab.Name = "clbRehab";
            this.clbRehab.Size = new System.Drawing.Size(396, 259);
            this.clbRehab.TabIndex = 0;
            this.clbRehab.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clbRehab_ItemCheck);
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.Location = new System.Drawing.Point(21, 25);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(237, 16);
            this.lblInfo.TabIndex = 1;
            this.lblInfo.Text = "Set desired state for each option:";
            // 
            // cmdExit
            // 
            this.cmdExit.Location = new System.Drawing.Point(342, 319);
            this.cmdExit.Name = "cmdExit";
            this.cmdExit.Size = new System.Drawing.Size(78, 28);
            this.cmdExit.TabIndex = 2;
            this.cmdExit.Text = "Exit";
            this.cmdExit.UseVisualStyleBackColor = true;
            this.cmdExit.Click += new System.EventHandler(this.cmdExit_Click);
            // 
            // RehabForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 355);
            this.Controls.Add(this.cmdExit);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.clbRehab);
            this.Name = "RehabForm";
            this.Text = "RehabForm";
            this.Load += new System.EventHandler(this.RehabForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox clbRehab;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Button cmdExit;
    }
}
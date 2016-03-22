using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;

namespace HotelModel.User_Permissions.HandledControls
{
    public partial class HandledForm : Form
    {
        private Boolean _HandlesVisibility;

        private Boolean _HandlesAccess;


        [Description("Sets Visibility handle"), Category("Persistence")]
        public Boolean HandlesVisibility
        {
            get { return _HandlesVisibility; }
            set { _HandlesVisibility = value; }
        }


        [Description("Sets Access (Enabled) handle"), Category("Persistence")]
        public Boolean HandlesAccess
        {
            get { return _HandlesAccess; }
            set { _HandlesAccess = value; }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // HandledForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Name = "HandledForm";
            this.Load += new System.EventHandler(this.HandledForm_Load);
            this.ResumeLayout(false);

        }

        private void HandledForm_Load(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;

namespace Resources.User_Permissions.HandledControls
{
    public partial class HandledButton : Button
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

    }
}

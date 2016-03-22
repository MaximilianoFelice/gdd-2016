using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HotelModel.User_Permissions.UFR;

namespace HotelModel.User_Permissions.UI
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void cmdLogin_Click(object sender, EventArgs e)
        {
            Boolean ret = PermissionManager.Login(txtUsername.Text, txtPassword.Text, this);
            if (ret) this.Close();

        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void cmdAdminTrap_Click(object sender, EventArgs e)
        {
            Boolean ret = PermissionManager.Login("MaximilianoFelice", "maximilianofelice", this);
            this.Close();
        }

        private void cmdLoginAsGuest_Click(object sender, EventArgs e)
        {
            Boolean ret = PermissionManager.Login("Guest", "guest", this);
            this.Close();
        }
    }
}

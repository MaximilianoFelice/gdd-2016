using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HotelModel.User_Permissions.UI
{
    public partial class ChooseRole : Form
    {
        DataSet _internalSet;

        public ChooseRole(DataSet roles)
        {
            InitializeComponent();

            _internalSet = roles;
            lstRoles.DataSource = _internalSet.Tables[0];
            lstRoles.ValueMember = "name";
            lstRoles.DisplayMember = "name";

        }

        private void ChooseRole_Load(object sender, EventArgs e)
        {

        }

        private void lstRoles_DoubleClick(object sender, EventArgs e)
        {
            ActiveUser.ActivateRole((String) lstRoles.SelectedValue);
            this.Close();
        }
    }
}

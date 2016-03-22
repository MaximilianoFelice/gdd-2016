using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HotelModel.User_Permissions.UFR;
using ExtensionMethods;

namespace HotelModel.User_Permissions.tests.ResourceForms
{
    public partial class Integration_Form_Test : Form
    {
        public Integration_Form_Test()
        {
            InitializeComponent();
        }

        BindingSource bs = new BindingSource();

        private void Integration_Form_Test_Load(object sender, EventArgs e)
        {
            PermissionManager.StartPoint(this);
            ActiveUser.LoadUser("Test_User", new String[] {"admin", "recepcionista"});
            ActiveUser.ActivateRole("admin");

            bs.DataSource = from role in ActiveUser.User_Roles
                            select (role.role_name);
            selectedRole.DataSource = bs;

            //var blist = new BindingList<String>(Role.getRoles[selectedRole.Text].features.IMap(x => x.feature_desc));
            bs = new BindingSource();
            //bs.DataSource 
            var bl = from feature in ActiveUser.Active_Role.features
                                     select (feature.feature_desc);

            bs.DataSource = bl.ToList();
            lstFeatures.DataSource = bs;

            cmdAdminVisible.HandleAccess(new String[] {"Admin"});
            cmdAdminVisible.HandleVisibility(new String[] { "Admin" });
            cmdAdminEnabled.HandleAccess(new String[] {  });
            cmdAdminEnabled.HandleVisibility(new String[] { "Admin" });
            cmdRecepcionistaEnabled.HandleAccess(new String[] { "Admin" });
            cmdRecepcionistaEnabled.HandleVisibility(new String[] { "Admin", "Recepcionista" });
            cmdRecepcionistaVisible.HandleAccess(new String[] { "Admin", "Recepcionista" });
            cmdRecepcionistaVisible.HandleVisibility(new String[] { "Admin", "Recepcionista" });

        }

        private void selectedRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActiveUser.ActivateRole(selectedRole.Text);
            lstFeatures.DataSource = null;
            lstFeatures.DataSource = bs;
        }

    }
}

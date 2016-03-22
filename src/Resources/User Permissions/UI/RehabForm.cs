using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Resources.DB_Conn_DSL;
using System.Data.SqlClient;
using ExtensionMethods;

namespace Resources.User_Permissions.UI
{
    public partial class RehabForm : Form
    {
        private SqlDataAdapter _internalAdapter;
        private DataSet _internalSet;
        private String _checkField;

        public RehabForm(SqlDataAdapter checkDA, DataSet checkDS, String availabilityField, String display, String valueMember )
        {
            InitializeComponent();

            _internalAdapter = checkDA;
            _internalSet = checkDS;
            _checkField = availabilityField;
            clbRehab.DataSource = checkDS.Tables[0];
            clbRehab.DisplayMember = display;
            clbRehab.ValueMember = valueMember;

            checkItems();

        }

        private void checkItems()
        {
            /* Populate checks in checked listbox */
            for (int i = 0; i < clbRehab.Items.Count; i++)
            {
                var res = ((Boolean)((DataRowView)clbRehab.Items[i]).Row[_checkField]) != true;

                clbRehab.SetItemChecked(i, res);
            }
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void clbRehab_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            _internalSet.Tables[0].Select(clbRehab.ValueMember + " = " + clbRehab.SelectedValue).IMap(x => x[_checkField] = !(e.NewValue == CheckState.Checked));
            _internalAdapter.Update(_internalSet);
        }

        private void RehabForm_Load(object sender, EventArgs e)
        {

        }
    }
}

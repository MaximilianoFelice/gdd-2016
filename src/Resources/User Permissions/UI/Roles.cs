﻿#define BIG

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
    public partial class frmRoles : Form
    {

        DataSet _feat_roles;
        SqlDataAdapter _feat_roles_adapter;
        DataSet feat_roles{
            /* Loading data into dataset for all roles */
            get
            {
                if (_feat_roles == null)
                {
                    _feat_roles_adapter = (SqlDataAdapter) new SqlQuery("SELECT id_feature, id_role FROM BOBBY_TABLES.FEATURES_ROLES").AsDataAdapter().Execute()["ReturnedValues"];
                    _feat_roles = new DataSet();
                    _feat_roles_adapter.Fill(_feat_roles);
                } 
                return _feat_roles;
            }
        }

        /* Defining sql accessors: Snippet Autogenerated */
        private DataSet _roles;
        private SqlDataAdapter _roles_adapter;
        public DataSet roles{
            get
            {
                if (_roles == null)
                {
                    _roles_adapter = (SqlDataAdapter)new SqlQuery("SELECT id_role, name FROM BOBBY_TABLES.ACTIVE_ROLES").AsDataAdapter().Execute()["ReturnedValues"];
                    _roles = new DataSet();
                    SqlCommand delCmd = new SqlCommand("DELETE FROM BOBBY_TABLES.ACTIVE_ROLES WHERE id_role = @id_role;");
                    delCmd.Parameters.Add("@id_role", SqlDbType.Int, 4, "id_role");
                    _roles_adapter.DeleteCommand = delCmd;
                    _roles_adapter.Fill(_roles);
                } 
                return _roles;
            }
        }
        
        
        /* Defining sql accessors: Snippet Autogenerated */
        DataSet _features;
        SqlDataAdapter _features_adapter;
        DataSet features{
            get
            {
                if (_features == null)
                {
                    _features_adapter = (SqlDataAdapter)new SqlQuery("SELECT id_feature, descr FROM BOBBY_TABLES.ACTIVE_FEATURES").AsDataAdapter().Execute()["ReturnedValues"];
                    _features = new DataSet();
                    SqlCommand delCmd = new SqlCommand("DELETE FROM BOBBY_TABLES.ACTIVE_FEATURES WHERE id_feature = @id_feature;");
                    delCmd.Parameters.Add("@id_feature", SqlDbType.Int,4,"id_feature");
                    _features_adapter.DeleteCommand = delCmd;
                    _features_adapter.Fill(_features);
                } 
                return _features;
            }
        }
        


        EnumerableRowCollection<DataRow> _combination_check;
        EnumerableRowCollection<DataRow> combination_check
        {
            /* Retrieves Joined association from DB As Enumerable */
            get { if (_combination_check == null) _combination_check = feat_roles.Tables[0].AsEnumerable(); return _combination_check; }
        }

        public frmRoles()
        {
            InitializeComponent();

            LoadFeatures();
            LoadRoles();

            this.clbFeatures.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clbFeatures_ItemCheck);
            
        }


        private void LoadFeatures()
        {
            /* Binding Features to checked list */
            clbFeatures.DataSource = features.Tables[0];
            clbFeatures.DisplayMember = "descr";
            clbFeatures.ValueMember = "id_feature";
        }

        private void LoadRoles()
        {
            /* Binding Roles to list */
            cboActiveRole.DisplayMember = "name";
            cboActiveRole.ValueMember = "id_role";
            cboActiveRole.DataSource = roles.Tables[0];
        }

        private void cboActiveRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            int aValue = (int)cboActiveRole.SelectedValue;
            var instanceChecks = combination_check.Where(row => row.Field<int>("id_role") == aValue);

            /* Populate checks in checked listbox */
            for (int i = 0; i < clbFeatures.Items.Count; i++)
            {
                var res = false;
                var x = (int) ((DataRowView)clbFeatures.Items[i]).Row["id_feature"];
                if (instanceChecks.Any(row => row.Field<int>("id_feature") == (int)((DataRowView)clbFeatures.Items[i]).Row["id_feature"])) res = true;

                clbFeatures.SetItemChecked(i, res);
            }
        }


        private void clbFeatures_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            int selected_role_id = (int) cboActiveRole.SelectedValue;

            int feature_changed_id = (int) ((DataRowView)clbFeatures.Items[e.Index]).Row["id_feature"];

            Func<DataRow, Boolean> filter_rows = delegate(DataRow row){
                if (row.RowState == DataRowState.Deleted) return false;
                return selected_role_id == row.Field<int>("id_role") && feature_changed_id == row.Field<int>("id_feature");
            };

            Action updateD = delegate() {
                _feat_roles_adapter.Update(_feat_roles.Tables[0]);
            };

            if (e.NewValue == CheckState.Unchecked){
                /* If value exists, we delete it from dataset */
                feat_roles.Tables[0].Rows.Cast<DataRow>()
                    .Where(filter_rows)
                    .ToList().ForEach(r => r.Delete());
            }
            else if (!feat_roles.Tables[0].AsEnumerable().Any(filter_rows)){
                /* As value has been checked and doesn't already exist on dataset, we should add it */
                DataRow newRow = feat_roles.Tables[0].NewRow();
                newRow["id_feature"] = feature_changed_id;
                newRow["id_role"] = selected_role_id;

                feat_roles.Tables[0].Rows.Add(newRow);
            }
            updateD.Invoke();
        }


        private void cmdAddRole_Click(object sender, EventArgs e)
        {

            Action<String> callback = delegate(String text)
            {
                DataRow newR = roles.Tables[0].NewRow();
                newR["name"] = text;
                roles.Tables[0].Rows.Add(newR);

                _roles_adapter.Update(roles.Tables[0]);
                newR["id_role"] = (int)new SqlQuery("SELECT id_role FROM [BOBBY_TABLES].ROLES WHERE name = '" + text + "';").ExecuteScalar(); ;
                roles.AcceptChanges();
            };

            Form nForm = new frmAddNew("Add Role", callback);
            nForm.Owner = this;
            nForm.ShowDialog();
        }

        private void cmdAddFeature_Click(object sender, EventArgs e)
        {
            Action<String> callback = delegate(String text)
            {
                DataRow newR = features.Tables[0].NewRow();
                newR["descr"] = text;
                features.Tables[0].Rows.Add(newR);

                _features_adapter.Update(features.Tables[0]);
                newR["id_feature"] = (int)new SqlQuery("SELECT id_feature FROM [BOBBY_TABLES].FEATURES WHERE descr = '" + text + "';").ExecuteScalar(); ;
                features.AcceptChanges();
            };

            Form nForm = new frmAddNew("Add Feature", callback);
            nForm.Owner = this;
            nForm.ShowDialog();
            this.cboActiveRole_SelectedIndexChanged(new object(), new EventArgs());
        }

        private void cmdRemoveFeature_Click(object sender, EventArgs e)
        {
            features.Tables[0].Select("id_feature =" + clbFeatures.SelectedValue).IMap(x => x.Delete());
            _features_adapter.Update(features.Tables[0]);
        }

        private void cmdDeleteRole_Click(object sender, EventArgs e)
        {
            roles.Tables[0].Select("id_role =" + cboActiveRole.SelectedValue).IMap(x => x.Delete());
            _roles_adapter.Update(roles.Tables[0]);
            this.cboActiveRole_SelectedIndexChanged(new object(), new EventArgs());
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmRoles_Load(object sender, EventArgs e)
        {

        }
        
    }
}

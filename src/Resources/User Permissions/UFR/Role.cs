using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HotelModel;
using HotelModel.DB_Conn_DSL;
using System.Security.Cryptography;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using HotelModel.User_Permissions.Exceptions;

namespace HotelModel.User_Permissions.UFR
{

    public class Role
    {
        private static Dictionary<String, Role> _LoadedRoles = null;

        public static Dictionary<String, Role> getRoles{
            get { return _LoadedRoles; }
        }

        private int role_id;
        
        public String role_name;

        public List<Feature> features;

        public Role(DataRow RoleRow)
        {
            role_id = (int)RoleRow["id_role"];
            role_name = (String)RoleRow["name"];
            features = new List<Feature>();
            _LoadedRoles.Add(role_name, this);

            getRoleFeatures();

        }

        private void getRoleFeatures()
        {
            /* QUERY HERE */
            DataSet res = (DataSet)new SqlStoredProcedure("[BOBBY_TABLES].GetRoleFeatures").WithParam("@Role").Value(role_id).Execute()["ReturnedValues"];

            /* Mapped to corresponding objects */
            features = res.Tables[0].AsEnumerable().Select(x => x["descr"]).ToList().Select(feat => Feature.getFeaturesDictionary[(String) feat]).ToList();
        }

        public static void LoadRoles() 
        {
            _LoadedRoles = new Dictionary<String, Role>();
            DataSet res = (DataSet)new SqlQuery("SELECT * FROM [BOBBY_TABLES].ACTIVE_ROLES;").AsDataSet().Execute()["ReturnedValues"];

            foreach (DataRow row in res.Tables[0].AsEnumerable()) new Role(row);
            
        }

        public Boolean HasAccess(Control ctrl) { return features.Any(feat => feat.HasAccess(ctrl)); }

        public Boolean HasVisibility(Control ctrl) { return features.Any(feat => feat.HasVisibility(ctrl)); }

        public Boolean HasAccess(ToolStripItem tools) { return features.Any(feat => feat.HasAccess(tools)); }

        public Boolean HasVisibility(ToolStripItem tools) { return features.Any(feat => feat.HasVisibility(tools)); }

        /* A new role activates */
        public void Activate()
        {
            /* Clean Permissions */
            PermissionManager.ResetPermissions();

            /* Sets visible objects */
            HashSet<Control> VisibleControls = new HashSet<Control>();
            foreach (Feature feat in features) VisibleControls.UnionWith(feat.Visible_Controls);
            foreach (Control c in VisibleControls) c.Visible = true;

            /* Sets accessible objects */
            HashSet<Control> AccessibleControls = new HashSet<Control>();
            foreach (Feature feat in features) AccessibleControls.UnionWith(feat.Accessible_Controls);
            foreach (Control c in VisibleControls) c.Enabled = true;

            /* Sets visible ToolStripItems */
            HashSet<ToolStripItem> VisibleTS = new HashSet<ToolStripItem>();
            foreach (Feature feat in features) VisibleTS.UnionWith(feat.Visible_Tools);
            foreach (ToolStripItem ts in VisibleTS) ts.Visible = true;

            /* Sets accessible ToolStripItems */
            HashSet<ToolStripItem> AccessibleTS = new HashSet<ToolStripItem>();
            foreach (Feature feat in features) AccessibleTS.UnionWith(feat.Accessible_Tools);
            foreach (ToolStripItem ts in AccessibleTS) ts.Enabled = true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Resources;
using Resources.DB_Conn_DSL;
using System.Security.Cryptography;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Resources.User_Permissions.UFR
{
    public class Feature
    {

        private int id_feature;

        public String feature_desc = null;

        private HashSet<Control> feature_visible_controls = null;

        private HashSet<Control> feature_accessible_controls = null;

        public HashSet<Control> Visible_Controls { get { return feature_visible_controls; } }
        public HashSet<Control> Accessible_Controls { get { return feature_accessible_controls; } }

        private HashSet<ToolStripItem> feature_visible_tools = null;

        private HashSet<ToolStripItem> feature_accessible_tools = null;

        public HashSet<ToolStripItem> Visible_Tools { get { return feature_visible_tools; } }
        public HashSet<ToolStripItem> Accessible_Tools { get { return feature_accessible_tools; } }

        public Feature(DataRow Feature)
        {
            id_feature = (int) Feature["id_feature"];

            feature_desc = (String) Feature["descr"];

            feature_accessible_controls = new HashSet<Control>();

            feature_visible_controls = new HashSet<Control>();

            feature_accessible_tools = new HashSet<ToolStripItem>();

            feature_visible_tools = new HashSet<ToolStripItem>();

            _LoadedFeatures.Add(feature_desc, this);

        }

        public void CanAcess(Control ctrl)
        {
            PermissionManager.ManagedAccessibleObjects.Add(ctrl);
            feature_accessible_controls.Add(ctrl);
            ActiveUser.RefreshPermissions();
        }

        public void CanView(Control ctrl)
        {
            PermissionManager.ManagedVisibleObjects.Add(ctrl);
            feature_visible_controls.Add(ctrl);
            ActiveUser.RefreshPermissions();
        }

        public void CanAcess(ToolStripItem tools)
        {
            PermissionManager.ManagedAccessibleToolStripMenuItems.Add(tools);
            feature_accessible_tools.Add(tools);
            ActiveUser.RefreshPermissions();
        }

        public void CanView(ToolStripItem tools)
        {
            PermissionManager.ManagedVisibleToolStripItems.Add(tools);
            feature_visible_tools.Add(tools);
            ActiveUser.RefreshPermissions();
        }

        private static Dictionary<String, Feature> _LoadedFeatures = null;

        public static List<Feature> getFeatures{
            get { return _LoadedFeatures.Values.ToList(); }
        }

        public static List<String> getFeaturesNames
        {
            get { return _LoadedFeatures.Keys.ToList(); }
        }

        public static Dictionary<String, Feature> getFeaturesDictionary
        {
            get { return _LoadedFeatures; }
        }

        public static void LoadFeatures()
        {
            _LoadedFeatures = new Dictionary<String, Feature>();

            /* Loading Features from database */
            DataSet res = (DataSet) new SqlQuery("SELECT * FROM [" + Resources.Properties.Settings.Default.SCHEMA_NAME + "].ACTIVE_FEATURES").AsDataSet().Execute()["ReturnedValues"];

            foreach (DataRow row in res.Tables[0].AsEnumerable()) new Feature(row);
            
            
        }

        public Boolean HasAccess(Control ctrl) { return feature_accessible_controls.Contains(ctrl); }

        public Boolean HasVisibility(Control ctrl) { return feature_visible_controls.Contains(ctrl); }

        public Boolean HasAccess(ToolStripItem tools) { return feature_accessible_tools.Contains(tools); }

        public Boolean HasVisibility(ToolStripItem tools) { return feature_visible_tools.Contains(tools); }

        public void Unmanage(Control ctrl)
        {
            feature_visible_controls.Remove(ctrl);
            feature_accessible_controls.Remove(ctrl);
        }

        public void Unmanage(ToolStripItem tools)
        {
            feature_visible_tools.Remove(tools);
            feature_accessible_tools.Remove(tools);
        }

    }
}

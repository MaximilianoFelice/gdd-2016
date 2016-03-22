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
using System.Reflection;
using ExtensionMethods;
using Resources.User_Permissions.UFR;
using Resources.User_Permissions.UI;

namespace Resources.User_Permissions
{
    public static class PermissionManager
    {
        private static HashSet<Control> _ManagedVisibleObjects = null;

        private static HashSet<Control> _ManagedAccessibleObjects = null;

        private static HashSet<ToolStripItem> _ManagedVisibleToolStripItems = null;

        private static HashSet<ToolStripItem> _ManagedAccessibleToolStripItems = null;

        #region Accessors

        public static HashSet<Control> ManagedVisibleObjects
        {
            get
            {
                if (_ManagedVisibleObjects == null || _ManagedAccessibleObjects == null) return getManagedObjects();
                else return _ManagedVisibleObjects;
            }
        }

        public static HashSet<Control> ManagedAccessibleObjects
        {
            get
            {
                if (_ManagedVisibleObjects == null || _ManagedAccessibleObjects == null) return getManagedObjects();
                else return _ManagedAccessibleObjects;
            }
        }

        public static HashSet<Control> ManagedObjects
        {
            get
            {
                if (_ManagedVisibleObjects == null || _ManagedAccessibleObjects == null) return getManagedObjects();
                else return _ManagedVisibleObjects.IUnionWith(_ManagedAccessibleObjects);
            }
        }

        public static HashSet<ToolStripItem> ManagedVisibleToolStripItems
        {
            get
            {
                if (_ManagedVisibleToolStripItems == null || _ManagedAccessibleToolStripItems == null) {getManagedObjects(); return _ManagedVisibleToolStripItems;}
                else return _ManagedVisibleToolStripItems;
            }
        }

        public static HashSet<ToolStripItem> ManagedAccessibleToolStripMenuItems
        {
            get
            {
                if (_ManagedVisibleToolStripItems == null || _ManagedAccessibleToolStripItems == null) { getManagedObjects(); return _ManagedAccessibleToolStripItems; }
                else return _ManagedAccessibleToolStripItems;
            }
        }

        public static HashSet<ToolStripItem> ManagedToolStripMenuItems
        {
            get
            {
                if (_ManagedVisibleToolStripItems == null || _ManagedAccessibleToolStripItems == null) { getManagedObjects(); return _ManagedVisibleToolStripItems.IUnionWith(_ManagedAccessibleToolStripItems); }
                else return _ManagedVisibleToolStripItems.IUnionWith(_ManagedAccessibleToolStripItems);
            }
        }

    #endregion

        public static void addVisibleControl(Control ctrl) { 
            /* Sets default Not Visible permission */
            ctrl.Visible = false;
            /* Hook to change visibility event */
            ctrl.VisibleChanged += new EventHandler(ControlEvents.VisibilityChanged);
            _ManagedVisibleObjects.Add(ctrl); 
        }

        public static void addAccessibleControl(Control ctrl) { 
            /* Sets default Not Accessible permission */
            ctrl.Enabled = false;
            /* TODO: Hook to change accessibility event */
            ctrl.EnabledChanged += new EventHandler(ControlEvents.AccessibilityChanged);
            _ManagedAccessibleObjects.Add(ctrl); 
        }

        public static void addVisibleToolStripItem(ToolStripItem tools)
        {
            /* Sets default Not Visible permission */
            tools.Visible = false;
            /* Hook to change visibility event */
            tools.VisibleChanged += new EventHandler(ToolStripEvents.VisibilityChanged);
            _ManagedVisibleToolStripItems.Add(tools);
        }

        public static void addAccessibleToolStripItem(ToolStripItem tools)
        {
            /* Sets default Not Accessible permission */
            tools.Enabled = false;
            /* TODO: Hook to change accessibility event */
            tools.EnabledChanged += new EventHandler(ToolStripEvents.AccessibilityChanged);
            _ManagedAccessibleToolStripItems.Add(tools);
        }

        private static Control _BaseControl;

        public static Control BaseControl{
            get { return _BaseControl; }
        }

        public static Boolean Login(String Username, string Password, Form caller)
        {
            /* Validating login */
            // TODO: Convert password to SHA_256
            string pass = GetSHA256(Password);

            /*Sending info to DB */
            SqlResults results = new SqlStoredProcedure("[BOBBY_TABLES].validateUserPass")
                                    .WithParam("@User").As(SqlDbType.VarChar).Value(Username.ToString())
                                    .WithParam("@Pass").As(SqlDbType.VarChar).Value(pass)
                                    .WithParam("@Login_Attempts").As(SqlDbType.Int).AsOutput()
                                    .WithParam("@RESULT").As(SqlDbType.Bit).AsOutput()
                                    .Execute();

            if (!(Boolean)results["@RESULT"])
            {
                int att = (int)results["@Login_Attempts"];
                if (att > 0) MessageBox.Show("Login Failed, you have only " + (3-att) + " attempts left.");
                else if (att == 0) MessageBox.Show("Login Failed, you have no attepmts left");
                else MessageBox.Show("Login Failed, username not found or might be inactive.");

                return false;
            }
            else
            {
                /* Loading Active User */
                ActiveUser.LoadUser(Username, (DataSet)results["ReturnedValues"]); // Returned Values containing user roles
                if (((DataSet)results["ReturnedValues"]).Tables[0].Rows.Count == 1)
                {
                    ActiveUser.ActivateRole((String)((DataSet)results["ReturnedValues"]).Tables[0].Rows[0]["name"]);
                }
                else
                {
                    ChooseRole chooseR = new ChooseRole((DataSet)results["ReturnedValues"]);
                    chooseR.Owner = caller;
                    chooseR.ShowDialog();
                }
                return true;
            }
            
        }

        static string GetSHA256(string password)
        {
            SHA256Managed crypt = new SHA256Managed();
            string hash = String.Empty;
            byte[] crypto = crypt.ComputeHash(Encoding.ASCII.GetBytes(password), 0, Encoding.ASCII.GetByteCount(password));
            foreach (byte bit in crypto)
            {
                hash += bit.ToString("x2");
            }
            return hash;
        }

        public static void LoadPermissions()
        {
            throw new NotImplementedException();
        }

        public static void StartPoint(Control BaseForm)
        {
            _BaseControl = BaseForm;

            Feature.LoadFeatures();
            Role.LoadRoles();

            getManagedObjects();
        }

        // TODO: Check return: Has no sense, should be void. Never used, anyway...
        private static HashSet<Control> getManagedObjects()
        {
            _ManagedVisibleObjects = new HashSet<Control>();

            _ManagedAccessibleObjects = new HashSet<Control>();

            _ManagedVisibleToolStripItems = new HashSet<ToolStripItem>();

            _ManagedAccessibleToolStripItems = new HashSet<ToolStripItem>();


            IEnumerable<System.Type> CurrentTypes = from c in Assembly.GetExecutingAssembly().GetTypes()
                                                      where c.IsClass && c.Namespace == typeof(PermissionManager).Namespace + ".HandledControls"
                                                      select c;

            LoadHandledControls(BaseControl, CurrentTypes);

            return _ManagedVisibleObjects;
        }

        /* Getting all Handled Controls recursively and then setting its handling */
        private static void LoadHandledControls(Control ParentControl, IEnumerable<System.Type> CurrentTypes)
        {
            if (ParentControl.getPropertyValueOrDefault<Boolean>("HandlesVisibility") == true) addVisibleControl(ParentControl);
            if (ParentControl.getPropertyValueOrDefault<Boolean>("HandlesAccess") == true) addAccessibleControl(ParentControl);

            foreach (Control child in ParentControl.Controls) LoadHandledControls(child, CurrentTypes);

        }

        /* Reset control permissions */
        public static void ResetVisibilityPermissions() 
        {   foreach (Control c in _ManagedVisibleObjects) c.Visible = false;
            foreach (ToolStripItem ts in _ManagedVisibleToolStripItems) ts.Visible = false;
        }
        public static void ResetAccessPermissions() 
        {   foreach (Control c in _ManagedAccessibleObjects) c.Enabled = false;
            foreach (ToolStripItem ts in _ManagedAccessibleToolStripItems) ts.Visible = false;
        }

        public static void ResetPermissions() { ResetVisibilityPermissions(); ResetAccessPermissions(); }


        /* Unmanaging objects */
        public static void Unmanage(Control ctrl)
        {
            _ManagedAccessibleObjects.Remove(ctrl);
            _ManagedVisibleObjects.Remove(ctrl);
            Feature.getFeatures.IMap(x => x.Unmanage(ctrl));
        }

        public static void Unmanage(ToolStripItem tools)
        {
            _ManagedAccessibleToolStripItems.Remove(tools);
            _ManagedVisibleToolStripItems.Remove(tools);
            Feature.getFeatures.IMap(x => x.Unmanage(tools));
        }

    }

    public static class ExtenionControl
    {
        public static T getPropertyValueOrDefault<T>(this Object obj, String prop)
        {
            var res = obj.GetType().GetProperty(prop);
            if (res != null) return (T) res.GetValue(obj, null);
            else return default(T);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HotelModel;
using HotelModel.DB_Conn_DSL;
using System.Security.Cryptography;
using System.Data.SqlClient;
using System.Data;
using HotelModel.User_Permissions.UFR;
using System.Windows.Forms;
using HotelModel.User_Permissions.Exceptions;

namespace HotelModel.User_Permissions
{
    public static class ActiveUser
    {
        public static String User;

        public static List<Role> User_Roles = new List<Role>();

        private static Role _Active_Role = null;

        public static Role Active_Role
        {
            get {
                if (_Active_Role != null) { return _Active_Role; }
                else {throw new ActiveRoleNotSetException();}
                }
        }

        public static void LoadUser(String Username, DataSet Roles)
        {
            User = Username;
            if (Roles.Tables.Count <= 0) {
                MessageBox.Show("This user has no current active roles");
                return;
            }

            for (int i = 0; Roles.Tables[0].Rows.Count > i; i++)
            {
                User_Roles.Add( Role.getRoles[(String)Roles.Tables[0].Rows[i]["name"]] );
            }
        }

        public static void LoadUser(String Username, String[] Roles)
        {
            User = Username;

            foreach (String r in Roles)
            {
                User_Roles.Add(Role.getRoles[r]);
            }
        }

        public static void ActivateRole(String RoleName)
        {
            Role aRole;
            try{
                aRole = Role.getRoles[RoleName];
            } catch (KeyNotFoundException e){
                throw new RoleNotFoundException("Role " + RoleName + " doesn't exist in current context");
            }

            if (!User_Roles.Contains(aRole)) throw new UserHasNoRoleException("User " + User + " has not role " + RoleName);

            _Active_Role = aRole;

            aRole.Activate();
        }

        public static Boolean HasAccess(Control control) { return Active_Role.HasAccess(control); }

        public static Boolean HasVisibility(Control control) { return Active_Role.HasVisibility(control); }

        public static Boolean HasAccess(ToolStripItem tools) { return Active_Role.HasAccess(tools); }

        public static Boolean HasVisibility(ToolStripItem tools) { return Active_Role.HasVisibility(tools); }

        public static void RefreshPermissions() { Active_Role.Activate(); }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using ExtensionMethods;

namespace Resources
{
    public static class ConnectionManager
    {
        static SqlConnection _sqlConn;
        public static SqlConnection sqlConn
        {
            get { if (_sqlConn == null) _sqlConn = new SqlConnection(connectionString); return _sqlConn; }
        }

        public static String connectionString
        {
            get { return generateConnString(); }
        }

        public static void OpenConnection()
        {
            try
            {
                sqlConn.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

        }

        public static void CloseConnection()
        {
            sqlConn.Close();
        }

        public static SqlDataReader ExecuteQuery(String query)
        {
            SqlCommand newCommand = new SqlCommand(query);
            OpenConnection();
            SqlDataReader retValue = newCommand.ExecuteReader();
            CloseConnection();

            return retValue;
        }

        static String generateConnString()
        {
            Dictionary<String, String> connectionData = new Dictionary<string, string>();

            connectionData["Data Source"] = Resources.Properties.Settings.Default.DB_ENDPOINT;
            connectionData["Initial Catalog"] = Resources.Properties.Settings.Default.DB_NAME;
            connectionData["User ID"] = Resources.Properties.Settings.Default.DB_USER;
            connectionData["Password"] = Resources.Properties.Settings.Default.DB_PASSWORD;
            connectionData["Integrated Security"] = "False";
            connectionData["Connect Timeout"] = "10";

            return string.Join(";", connectionData.Select(x => x.Key + "=" + x.Value).ToArray());
        }
    }
}

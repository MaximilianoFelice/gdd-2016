using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using ExtensionMethods;

namespace HotelModel
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
            return "Data Source=localhost\\SQLSERVER2008;Initial Catalog=GD2C2014;Integrated Security=False;User ID=gd;Password=gd2014;Connect Timeout=10";
        }
    }
}

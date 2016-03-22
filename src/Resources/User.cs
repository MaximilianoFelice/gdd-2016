using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Resources;
using Resources.DB_Conn_DSL;
using System.Security.Cryptography;
using System.Data.SqlClient;
using System.Data;


namespace Resources
{
    public static class User
    {
        public static DataSet GetRoles(String user)
        {
            return (DataSet)new SqlStoredProcedure("[BOBBY_TABLES].GetUserRoles")
                                                .WithParam("@username").As(SqlDbType.VarChar).Value(user.ToString())
                                                .Execute()["ReturnedValues"];
        }
    }
}

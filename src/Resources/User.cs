using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HotelModel;
using HotelModel.DB_Conn_DSL;
using System.Security.Cryptography;
using System.Data.SqlClient;
using System.Data;


namespace HotelModel
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

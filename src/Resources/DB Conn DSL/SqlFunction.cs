using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using ExtensionMethods;

namespace HotelModel.DB_Conn_DSL
{
    public class SqlFunction : SqlWithParams
    {
        public SqlFunction(String FunctName)
        {
            this.StoredCommand = new SqlCommand(FunctName, ConnectionManager.sqlConn);
            this.StoredCommand.CommandType = CommandType.StoredProcedure;
        }

    }
}

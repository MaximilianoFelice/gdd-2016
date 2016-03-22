using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using ExtensionMethods;

namespace HotelModel.DB_Conn_DSL
{
    public class SqlQuery : SqlCommandDSL
    {
        public SqlQuery(String Query)
        {
            this.StoredCommand = new SqlCommand(Query, ConnectionManager.sqlConn);
            this.StoredCommand.CommandType = CommandType.Text;
        }
    }
}

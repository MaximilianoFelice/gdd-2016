using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using ExtensionMethods;

namespace Resources.DB_Conn_DSL
{
    class DataReaderRetriever : DataRetrieverBuilder
    {
        public object Execute(SqlCommand Command)
        {
            /* It will let user close connection when finished */
            SqlDataReader ResultantReader = Command.ExecuteReader();

            if (!ResultantReader.HasRows) return null;
            else return ResultantReader;
        }
    }
}

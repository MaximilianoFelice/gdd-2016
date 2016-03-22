using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using ExtensionMethods;

namespace HotelModel.DB_Conn_DSL
{
    class DataTableRetriever : DataRetrieverBuilder
    {
        public object Execute(SqlCommand Command)
        {
            DataTable ResultantDataTable = new DataTable();

            ResultantDataTable.Load(Command.ExecuteReader());

            ConnectionManager.CloseConnection();

            if (ResultantDataTable.Rows.Count <= 0) return null;
            else return ResultantDataTable;

        }
    }
}

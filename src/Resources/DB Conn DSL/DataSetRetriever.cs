using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using ExtensionMethods;


namespace Resources.DB_Conn_DSL
{
    class DataSetRetriever : DataRetrieverBuilder
    {
        public object Execute(SqlCommand Command)
        {
            DataSet ResultantDataSet = new DataSet();

            SqlDataAdapter Adapter = new SqlDataAdapter(Command);

            int RowsAdded = Adapter.Fill(ResultantDataSet);

            ConnectionManager.CloseConnection();

            return ResultantDataSet;

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace HotelModel.DB_Conn_DSL
{
    public class DataAdapterRetriever : DataRetrieverBuilder
    {
       public object Execute(SqlCommand Command){
            /* It will let user close connection when finished */
           SqlDataAdapter ResultantAdapter = new SqlDataAdapter(Command);

           SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(ResultantAdapter);
           ResultantAdapter.UpdateCommand = cmdBuilder.GetUpdateCommand(true);
           ResultantAdapter.DeleteCommand = cmdBuilder.GetDeleteCommand(true);
           ResultantAdapter.InsertCommand = cmdBuilder.GetInsertCommand(true);

           return ResultantAdapter;
        }
    }
}

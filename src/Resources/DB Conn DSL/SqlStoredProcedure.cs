using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using ExtensionMethods;

namespace HotelModel.DB_Conn_DSL
{

    public class SqlStoredProcedure : SqlWithParams
    {

        public SqlStoredProcedure(String ProcName)
        {
            this.StoredCommand = new SqlCommand(ProcName, ConnectionManager.sqlConn);
            this.StoredCommand.CommandType = CommandType.StoredProcedure;
        }

        public SqlStoredProcedure AsOutput()
        {
            Parameters.SetPropertyToLast("Direction", System.Data.ParameterDirection.Output);

            return this;
        }

        public SqlStoredProcedure AsInputOutput()
        {
            Parameters.SetPropertyToLast("Direction", System.Data.ParameterDirection.InputOutput);

            return this;
        }

        /* Private Internal methods */
        override public void AnalyzeParam(SqlParameter Param)
        {
            if (Param.Direction == ParameterDirection.Output) OutputParameters.Push(Param);
            else if (Param.Direction == ParameterDirection.ReturnValue) OutputParameters.Push(Param);
        }

    }
}

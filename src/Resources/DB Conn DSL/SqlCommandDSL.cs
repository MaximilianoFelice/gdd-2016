using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using ExtensionMethods;

namespace Resources.DB_Conn_DSL
{
    /* Used as alias */
    public class SqlResults : System.Collections.Generic.Dictionary<System.String, object> { }

    public abstract class SqlCommandDSL
    {
        public SqlCommand StoredCommand;

        public DataRetrieverBuilder OutputMode = new DataSetRetriever();

        public SqlResults Execute()
        {
            this.Build();

            ConnectionManager.OpenConnection();

            object QueryResults = OutputMode.Execute(StoredCommand);

            SqlResults RetValues = AnalyzeResults();

            if (QueryResults != null) RetValues.Add("ReturnedValues", QueryResults);

            return RetValues;
        }

        public object ExecuteScalar()
        {
            this.Build();
            ConnectionManager.OpenConnection();

            return StoredCommand.ExecuteScalar();
        }


        /* Private methods for internal use */
        virtual public SqlResults AnalyzeResults()
        {
            return new SqlResults();
        }

        virtual public void Build() {}

    }

    public static class SqlCommandDSLExtension
    {
        public static T AsDataSet<T>(this T aCommand) where T : SqlCommandDSL
        {
            aCommand.OutputMode = new DataSetRetriever();

            return aCommand;
        }

        public static T AsDataReader<T>(this T aCommand) where T : SqlCommandDSL
        {
            aCommand.OutputMode = new DataReaderRetriever();

            return aCommand;
        }

        public static T AsDataTable<T>(this T aCommand) where T : SqlCommandDSL
        {
            aCommand.OutputMode = new DataTableRetriever();

            return aCommand;
        }

        public static T AsDataAdapter<T>(this T aCommand) where T : SqlCommandDSL
        {
            aCommand.OutputMode = new DataAdapterRetriever();

            return aCommand;
        }
    }
}

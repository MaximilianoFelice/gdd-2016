using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using ExtensionMethods;

namespace Resources.DB_Conn_DSL
{
    public abstract class SqlWithParams : SqlCommandDSL
    {
        public Stack<SqlParameter> Parameters = new Stack<SqlParameter>();

        public Stack<SqlParameter> OutputParameters = new Stack<SqlParameter>();

        /* Private Internal methods */
        override public void Build()
        {
            foreach (SqlParameter Param in Parameters)
            {
                StoredCommand.Parameters.Add(Param);

                AnalyzeParam(Param);
            }

        }

        virtual public void AnalyzeParam(SqlParameter Param) { }

        override public SqlResults AnalyzeResults()
        {
            SqlResults RetValues = new SqlResults();

            foreach (SqlParameter Param in OutputParameters)
            {
                RetValues.Add(Param.ParameterName, Param.Value);
            }

            return RetValues;
        }

    }

    public static class SqlWithParamsExtension
    {
        public static T WithParam<T>(this T anSqlWithParams, String ParamName) where T : SqlWithParams
        {
            SqlParameter newParam = new SqlParameter();

            newParam.ParameterName = ParamName;

            anSqlWithParams.Parameters.Push(newParam);

            return anSqlWithParams;
        }

        public static T As<T>(this T anSqlWithParams, SqlDbType Type) where T : SqlWithParams
        {
            anSqlWithParams.Parameters.SetPropertyToLast("SqlDbType", Type);

            return anSqlWithParams;
        }

        public static T Value<T, ValType>(this T anSqlWithParams, ValType value) where T : SqlWithParams
        {
            anSqlWithParams.Parameters.SetPropertyToLast("Value", value);

            return anSqlWithParams;
        }

        public static T WithMaximumSize<T>(this T anSqlWithParams, int size) where T : SqlWithParams
        {
            anSqlWithParams.Parameters.SetPropertyToLast("Size", size);

            return anSqlWithParams;
        }

        public static T AsInput<T>(this T anSqlWithParams) where T : SqlWithParams
        {
            anSqlWithParams.Parameters.SetPropertyToLast("Direction", System.Data.ParameterDirection.Input);

            return anSqlWithParams;
        }

        public static T AsReturnValue<T>(this T anSqlWithParams) where T : SqlWithParams
        {
            anSqlWithParams.Parameters.SetPropertyToLast("Direction", System.Data.ParameterDirection.ReturnValue);

            /* Integer is the only possible return value */
            /* http://stackoverflow.com/questions/12096838/setting-parameterdirection-to-returnvalue-for-functions */
            anSqlWithParams.As(SqlDbType.Int);

            return anSqlWithParams;
        }

    }

}

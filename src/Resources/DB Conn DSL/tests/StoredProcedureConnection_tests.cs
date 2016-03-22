using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Data.SqlClient;
using System.Data;
using ExtensionMethods;
using Resources.DB_Conn_DSL;

namespace Resources.DB_Conn_DSL.tests
{
    [TestFixture]
    public class StoredProcedureConnection_tests
    {

        String user;
        String password;

        [SetUp] public void Init ()
        {
            user = "MaximilianoFelice";
            password = "53acbedaad48d8d482fe1a9bf8cd8b8e329ff8033c5c1dc81dcccdff38dd197f";
        }

        [Test]
        public void CreatesNewSoredProcedure()
        {
            SqlStoredProcedure someProc = new SqlStoredProcedure("aName");
            Assert.AreEqual(someProc.StoredCommand.CommandText, "aName");
            Assert.AreEqual(someProc.StoredCommand.CommandType, CommandType.StoredProcedure);
        }

        [Test]
        public void AddsNewProperties()
        {
            SqlStoredProcedure someProc = new SqlStoredProcedure("aName").WithParam("@SomeParam").As(SqlDbType.Bit).AsOutput();

            Assert.AreEqual(someProc.Parameters.Count(), 1);
            Assert.AreEqual(someProc.Parameters.Peek().Direction, System.Data.ParameterDirection.Output);
            Assert.AreEqual(someProc.Parameters.Peek().ParameterName, "@SomeParam");
        }

        [Test]
        public void userLoginIsCorrect()
        {
            SqlResults results = new SqlStoredProcedure("[BOBBY_TABLES].validateUserPass")
                                    .WithParam("@User").As(SqlDbType.VarChar).Value(user.ToString())
                                    .WithParam("@Pass").As(SqlDbType.VarChar).Value(password.ToString())
                                    .WithParam("@RESULT").As(SqlDbType.Bit).AsOutput()
                                    .Execute();

            Assert.True( (Boolean)results["@RESULT"] ) ;
        }

        [Test]
        public void userLoginIsNotCorrect()
        {
            SqlResults results = new SqlStoredProcedure("[BOBBY_TABLES].validateUserPass")
                                    .WithParam("@User").As(SqlDbType.VarChar).Value(user.ToString())
                                    .WithParam("@Pass").As(SqlDbType.VarChar).Value("WRONG")
                                    .WithParam("@RESULT").As(SqlDbType.Bit).AsOutput()
                                    .Execute();

            Assert.False((Boolean)results["@RESULT"]);
        }

        [Test]
        public void ExecuteReturnsAllOutputParams()
        {
            SqlResults results = new SqlStoredProcedure("[BOBBY_TABLES].OUTPUT_TEST")
                                    .WithParam("@anOutput").AsOutput().As(SqlDbType.VarChar).WithMaximumSize(50)
                                    .WithParam("@aValue").As(SqlDbType.Int).Value(10)
                                    .WithParam("@anotherOutput").AsOutput().As(SqlDbType.Int)
                                    .Execute();

            Assert.AreEqual(results.Count, 2);

            Assert.AreEqual(results["@anOutput"], "a Result");

            Assert.AreEqual(results["@anotherOutput"], 150);
        }

        [Test]
        public void ExecuteWithComeback()
        {
            SqlResults results = new SqlStoredProcedure("[BOBBY_TABLES].RESULTS_TEST")
                                    .Execute();

            DataSet retVals = (DataSet) results["ReturnedValues"];

            Assert.True(retVals.Tables[0].Rows.Count > 0);
        }

        [Test]
        [ExpectedException( typeof(KeyNotFoundException))]
        public void HasNoComeback()
        {
            SqlResults results = new SqlStoredProcedure("[BOBBY_TABLES].OUTPUT_TEST")
                                    .WithParam("@anOutput").AsOutput().As(SqlDbType.VarChar).WithMaximumSize(50)
                                    .WithParam("@aValue").As(SqlDbType.Int).Value(10)
                                    .WithParam("@anotherOutput").AsOutput().As(SqlDbType.Int)
                                    .Execute();

            results["ReturnedValues"].GetType();
        }

        [Test]
        public void RetunsValidDataReader()
        {
            SqlResults results = new SqlStoredProcedure("[BOBBY_TABLES].RESULTS_TEST")
                        .AsDataReader()
                        .Execute();

            SqlDataReader retVals = (SqlDataReader)results["ReturnedValues"];

            Assert.True(retVals.HasRows);

            ConnectionManager.CloseConnection();
        }

        [Test]
        public void ReturnsValidDataTable()
        {
            SqlResults results = new SqlStoredProcedure("[BOBBY_TABLES].RESULTS_TEST")
                        .AsDataTable()
                        .Execute();

            DataTable retVals = (DataTable)results["ReturnedValues"];

            Assert.True(retVals.Rows.Count > 0);
        }

        [Test]
        public void ReturnValuesWorks()
        {
            SqlResults results = new SqlStoredProcedure("[BOBBY_TABLES].RETURN_TEST")
                                   .WithParam("RetVal").AsReturnValue()
                                   .Execute();

            Assert.AreEqual(results["RetVal"], -4);
        }
    }
}

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
    public class Connection_tests
    {
        [SetUp]
        public void OpenConnection()
        {
            ConnectionManager.OpenConnection();
        }

        [Test]
        public void CanConnectToDB()
        {
            Assert.True(ConnectionManager.sqlConn.State == ConnectionState.Open);
        }

        [TearDown]
        public void CloseConnection()
        {
            ConnectionManager.CloseConnection();
        }
    }
}

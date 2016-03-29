using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Resources.DB_Conn_DSL;

namespace Resources.Home
{
    public class BillHandler
    {
        public Boolean saveBill(Int32 id_booking, String payment) {
            SqlResults results = new SqlStoredProcedure("[" + Resources.Properties.Settings.Default.SCHEMA_NAME + "].SP_INSERT_BILL")
                                .WithParam("@IdBooking").As(SqlDbType.Int).Value(id_booking)
                                .WithParam("@PaymentMode").As(SqlDbType.VarChar).Value(payment)
                                .WithParam("@Inserted").As(SqlDbType.Bit).AsOutput()
                                .Execute();
            return (Boolean)results["@Inserted"];
        }
    }
}

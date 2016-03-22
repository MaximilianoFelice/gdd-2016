using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Resources.DB_Conn_DSL;

namespace Resources.Home
{
    public class ExtraHandler
    {
        public DataSet getExtras() {
            SqlResults results = new SqlQuery("SELECT DISTINCT * FROM BOBBY_TABLES.EXTRAS")
                                 .Execute();
            return (DataSet)results["ReturnedValues"];
        }

        public Boolean bookingHasAllInclusive(Int32 id_booking) {
            SqlResults results = new SqlStoredProcedure("[BOBBY_TABLES].SP_BOOKING_ALL_INCLUSIVE")
                                 .WithParam("@IdBooking").As(SqlDbType.Int).Value(id_booking)
                                 .WithParam("@Return").As(SqlDbType.Bit).AsOutput()
                                 .Execute();
            return (Boolean)results["@Return"];
        }

        public Int32 addExtraToStay(Int32 id_booking, Int32 id_extra) {
            SqlResults results = new SqlStoredProcedure("[BOBBY_TABLES].SP_INSERT_EXTRA_STAY")
                                .WithParam("@IdBooking").As(SqlDbType.Int).Value(id_booking)
                                .WithParam("@IdExtra").As(SqlDbType.Int).Value(id_extra)
                                .WithParam("@IdExInserted").As(SqlDbType.Int).AsOutput()
                                .Execute();
            return (Int32)results["@IdExInserted"];
        }
    
    }
}

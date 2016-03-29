using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Resources.DB_Conn_DSL;

namespace Resources.Home
{
    public class BookingHandler
    {
        public Boolean checkAvailability(Int32 id_hotel, Int32 id_regimen, DateTime checkin, DateTime checkout, Int32 extraGuests, Int32 id_roomtype) {
            SqlResults results = new SqlStoredProcedure("[" + Resources.Properties.Settings.Default.SCHEMA_NAME + "].SP_CHECK_AVAILABILITY")
                                .WithParam("@IdHotel").As(SqlDbType.Int).Value(id_hotel)
                                .WithParam("@IdRegimen").As(SqlDbType.Int).Value(id_regimen)
                                .WithParam("@CheckIn").As(SqlDbType.DateTime).Value(checkin)
                                .WithParam("@CheckOut").As(SqlDbType.DateTime).Value(checkout)
                                .WithParam("@ExtraGuests").As(SqlDbType.Int).Value(extraGuests)
                                .WithParam("@IdRoomType").As(SqlDbType.Int).Value(id_roomtype)
                                .WithParam("@Available").As(SqlDbType.Bit).AsOutput()
                                .Execute();
            return (Boolean)results["@Available"];
        
        }
        
        public Int32 getBookingPrice(Int32 id_hotel, Int32 id_regimen, DateTime checkin, DateTime checkout, Int32 extraGuests, Int32 id_roomtype) {
            SqlResults results = new SqlStoredProcedure("[" + Resources.Properties.Settings.Default.SCHEMA_NAME + "].SP_BOOKING_PRICE")
                                .WithParam("@IdHotel").As(SqlDbType.Int).Value(id_hotel)
                                .WithParam("@IdRegimen").As(SqlDbType.Int).Value(id_regimen)
                                .WithParam("@CheckIn").As(SqlDbType.DateTime).Value(checkin)
                                .WithParam("@CheckOut").As(SqlDbType.DateTime).Value(checkout)
                                .WithParam("@ExtraGuests").As(SqlDbType.Int).Value(extraGuests)
                                .WithParam("@IdRoomType").As(SqlDbType.Int).Value(id_roomtype)
                                .WithParam("@Price").As(SqlDbType.Int).AsOutput()
                                .Execute();
            return (Int32)results["@Price"];
    }
        public Int32 insertBooking(Int32 id_hotel, Int32 id_regimen, DateTime checkin, DateTime checkout, Int32 extraGuests, Int32 id_roomtype)
        {
            SqlResults results = new SqlStoredProcedure("[" + Resources.Properties.Settings.Default.SCHEMA_NAME + "].SP_INSERT_BOOKING")
                                .WithParam("@IdHotel").As(SqlDbType.Int).Value(id_hotel)
                                .WithParam("@IdRegimen").As(SqlDbType.Int).Value(id_regimen)
                                .WithParam("@CheckIn").As(SqlDbType.DateTime).Value(checkin)
                                .WithParam("@CheckOut").As(SqlDbType.DateTime).Value(checkout)
                                .WithParam("@ExtraGuests").As(SqlDbType.Int).Value(extraGuests)
                                .WithParam("@IdRoomType").As(SqlDbType.Int).Value(id_roomtype)
                                .WithParam("@Code").As(SqlDbType.Int).AsOutput()
                                .Execute();
            return (Int32)results["@Code"];
      
        }

        public Boolean insertHolderToBooking(Int32 id_booking, Int32 id_guest) {
            SqlResults results = new SqlStoredProcedure("[" + Resources.Properties.Settings.Default.SCHEMA_NAME + "]. SP_INSERT_HOLDER_BOOKING")
                                .WithParam("@IdBooking").As(SqlDbType.Int).Value(id_booking)
                                .WithParam("@IdGuest").As(SqlDbType.Int).Value(id_guest)
                                .WithParam("@Inserted").As(SqlDbType.Bit).AsOutput()
                                .Execute();
            return (Boolean)results["@Inserted"];
        }

        public Boolean bookingExists(Int32 id_booking) {
            SqlResults results = new SqlStoredProcedure("[" + Resources.Properties.Settings.Default.SCHEMA_NAME + "].SP_BOOKING_EXISTS")
                                 .WithParam("@IdBooking").As(SqlDbType.Int).Value(id_booking)
                                 .WithParam("@Exists").As(SqlDbType.Bit).AsOutput()
                                 .Execute();
            return (Boolean)results["@Exists"];
        }

        public Boolean deleteBooking(Int32 id_booking, String descr) {
            SqlResults results = new SqlStoredProcedure("[" + Resources.Properties.Settings.Default.SCHEMA_NAME + "].SP_BOOKING_EXISTS")
                                .WithParam("@IdBooking").As(SqlDbType.Int).Value(id_booking)
                                .WithParam("@Descr").As(SqlDbType.VarChar).Value(id_booking)
                                .WithParam("@Deleted").As(SqlDbType.Bit).AsOutput()
                                .Execute();
            return (Boolean)results["@Deleted"];
        }

        public DataSet getBookingInformation(Int32 id_booking) {
            SqlResults results = new SqlQuery(" SELECT * from " + Resources.Properties.Settings.Default.SCHEMA_NAME + ".BOOKINGS where id_booking = "+id_booking)
                                .Execute();
            return (DataSet)results["ReturnedValues"];
        }
        
        public DataSet getHolderBooking(){
            SqlResults results = new SqlQuery("SELECT * from " + Resources.Properties.Settings.Default.SCHEMA_NAME + ".GUEST_BOOKINGS")
                                .Execute();
            return (DataSet)results["ReturnedValues"];

        }

        public Boolean insertGuestToBooking(Int32 id_booking, Int32 id_guest)
        {
            SqlResults results = new SqlStoredProcedure("[" + Resources.Properties.Settings.Default.SCHEMA_NAME + "].SP_INSERT_GUEST_BOOKING")
                                    .WithParam("@IdBooking").As(SqlDbType.Int).Value(id_booking)
                                    .WithParam("@IdGuest").As(SqlDbType.Int).Value(id_guest)
                                    .WithParam("@Inserted").As(SqlDbType.Bit).AsOutput()
                                    .Execute();
            return (Boolean)results["@Inserted"];
        }
    }
}

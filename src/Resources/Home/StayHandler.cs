using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HotelModel.DB_Conn_DSL;

namespace HotelModel.Home
{
    public class StayHandler
    {
        public DataSet getStays(Int32 id_booking) {
            SqlResults results = new SqlQuery("SELECT * FROM BOBBY_TABLES.STAYS").Execute();
            return (DataSet)results["ReturnedValues"];
 
        }

        public Int32 insertStay(Int32 id_booking, Int32 id_hotel, Int32 id_reg, Int32 id_roomtype, DateTime start, Int32 nights) {
            SqlResults results = new SqlStoredProcedure("[BOBBY_TABLES].SP_INSERT_STAY")
                                .WithParam("IdBooking").As(SqlDbType.Int).Value(id_booking)
                                .WithParam("@IdHotel").As(SqlDbType.Int).Value(id_hotel)
                                .WithParam("@IdRegimen").As(SqlDbType.Int).Value(id_reg)
                                .WithParam("@CheckIn").As(SqlDbType.DateTime).Value(start)
                                .WithParam("@Nights").As(SqlDbType.Int).Value(nights)
                                .WithParam("@IdRoomType").As(SqlDbType.Int).Value(id_roomtype)
                                .WithParam("@RoomNumber").As(SqlDbType.Int).AsOutput()
                                .Execute();
            return (Int32)results["@RoomNumber"];
        }

        public float getStayPrice(Int32 id_booking) {
            SqlResults results = new SqlStoredProcedure("[BOBBY_TABLES].SP_GET_STAY_PRICE")
                                .WithParam("@IdBooking").As(SqlDbType.Int).Value(id_booking)
                                .WithParam("@Price").As(SqlDbType.Float).AsOutput()
                                .Execute();
            return (float)results["@Price"];
        }

        public Int32 getNights(Int32 id_booking)
        {
            SqlResults results = new SqlStoredProcedure("[BOBBY_TABLES].SP_GET_NIGHTS")
                                .WithParam("IdBooking").As(SqlDbType.Int).Value(id_booking)
                                .WithParam("@Nights").As(SqlDbType.Int).AsOutput()
                                .Execute();
            return (Int32)results["@Nights"];
        }

        public Int32 getExtraNights(Int32 id_booking) {
            SqlResults results = new SqlStoredProcedure("[BOBBY_TABLES].SP_GET_EXTRA_NIGHTS")
                                .WithParam("IdBooking").As(SqlDbType.Int).Value(id_booking)
                                .WithParam("@Extra").As(SqlDbType.Int).AsOutput()
                                .Execute();
            return (Int32)results["@Extra"];
        }

        public Boolean setCheckOutGuests(Int32 id_booking)
        {
            SqlResults results = new SqlStoredProcedure("[BOBBY_TABLES].SP_CHECKED_OUT_GUESTS")
                                .WithParam("IdBooking").As(SqlDbType.Int).Value(id_booking)
                                .WithParam("@Seted").As(SqlDbType.Bit).AsOutput()
                                .Execute();
            return (Boolean)results["@Seted"];
        }
    }
}

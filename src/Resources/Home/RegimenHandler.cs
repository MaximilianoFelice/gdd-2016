using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HotelModel.DB_Conn_DSL;

namespace HotelModel.Home
{
    public class RegimenHandler
    {
        public DataSet getRegimensForHotels()
        {
            SqlResults results = new SqlQuery("SELECT DISTINCT * FROM BOBBY_TABLES.REGIMENS").Execute();
            return (DataSet)results["ReturnedValues"];

        }

        public DataSet getRegimenIdFromDescr(String descr)
        {
            SqlResults results = new SqlQuery("SELECT id_regimen FROM BOBBY_TABLES.REGIMENS WHERE descr="+descr).Execute();
            return (DataSet) results["ReturnedValues"];
        }

        public DataSet getRegimensDescrForHotel(Int32 id_hotel){
            SqlResults results = new SqlQuery("SELECT descr FROM BOBBY_TABLES.REGIMENS r JOIN BOBBY_TABLES.REGIMEN_HOTEL rh ON r.id_regimen = rh.id_regimen WHERE rh.id_hotel =" + id_hotel).Execute();
            return (DataSet)results["ReturnedValues"];
        }

        public DataSet getRegimensForHotel(Int32 id_hotel) {
            SqlResults results = new SqlQuery("SELECT * FROM BOBBY_TABLES.REGIMENS r JOIN BOBBY_TABLES.REGIMEN_HOTEL rh ON r.id_regimen = rh.id_regimen WHERE rh.id_hotel =" + id_hotel).Execute();
            return (DataSet)results["ReturnedValues"];
        }

        public DataSet getRegimensDescrFromId(Int32 id_regimen) {
            SqlResults results = new SqlQuery("SELECT descr FROM BOBBY_TABLES.REGIMENS WHERE id_regimen = " + id_regimen)
                                .Execute();
            return (DataSet)results["ReturnedValues"];
        }

        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Resources.DB_Conn_DSL;

namespace Resources.Home
{
    public class RegimenHandler
    {
        public DataSet getRegimensForHotels()
        {
            SqlResults results = new SqlQuery("SELECT DISTINCT * FROM " + Resources.Properties.Settings.Default.SCHEMA_NAME + ".REGIMENS").Execute();
            return (DataSet)results["ReturnedValues"];

        }

        public DataSet getRegimenIdFromDescr(String descr)
        {
            SqlResults results = new SqlQuery("SELECT id_regimen FROM " + Resources.Properties.Settings.Default.SCHEMA_NAME + ".REGIMENS WHERE descr="+descr).Execute();
            return (DataSet) results["ReturnedValues"];
        }

        public DataSet getRegimensDescrForHotel(Int32 id_hotel){
            SqlResults results = new SqlQuery("SELECT descr FROM " + Resources.Properties.Settings.Default.SCHEMA_NAME + ".REGIMENS r JOIN " + Resources.Properties.Settings.Default.SCHEMA_NAME + ".REGIMEN_HOTEL rh ON r.id_regimen = rh.id_regimen WHERE rh.id_hotel =" + id_hotel).Execute();
            return (DataSet)results["ReturnedValues"];
        }

        public DataSet getRegimensForHotel(Int32 id_hotel) {
            SqlResults results = new SqlQuery("SELECT * FROM " + Resources.Properties.Settings.Default.SCHEMA_NAME + ".REGIMENS r JOIN " + Resources.Properties.Settings.Default.SCHEMA_NAME + ".REGIMEN_HOTEL rh ON r.id_regimen = rh.id_regimen WHERE rh.id_hotel =" + id_hotel).Execute();
            return (DataSet)results["ReturnedValues"];
        }

        public DataSet getRegimensDescrFromId(Int32 id_regimen) {
            SqlResults results = new SqlQuery("SELECT descr FROM " + Resources.Properties.Settings.Default.SCHEMA_NAME + ".REGIMENS WHERE id_regimen = " + id_regimen)
                                .Execute();
            return (DataSet)results["ReturnedValues"];
        }

        
    }
}

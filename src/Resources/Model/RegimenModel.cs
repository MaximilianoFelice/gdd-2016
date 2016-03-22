﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using HotelModel.DB_Conn_DSL;

namespace HotelModel.Model
{
    public static class RegimenModel
    {

        /* Defining sql accessors: Snippet Autogenerated */
        private static DataSet _regimen;
        private static SqlDataAdapter _regimen_adapter;
        public static SqlDataAdapter regimen_adapter { get { if ((regimen == null) || true); return _regimen_adapter; } }
        public static DataSet regimen{
            get
            {
                if (_regimen == null)
                {
                    _regimen_adapter = (SqlDataAdapter) new SqlQuery("SELECT id_regimen, descr, price, stat FROM BOBBY_TABLES.REGIMENS;").AsDataAdapter().Execute()["ReturnedValues"];
                    _regimen = new DataSet();
                    _regimen_adapter.Fill(_regimen);
                } 
                return _regimen;
            }
        }


        
    }
}

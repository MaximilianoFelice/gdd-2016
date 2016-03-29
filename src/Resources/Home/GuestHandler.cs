using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ExtensionMethods;
using Resources.DB_Conn_DSL;

namespace Resources.Home
{
    public class GuestHandler
    {
        public DataSet getPersons() {
            SqlResults results = new SqlQuery("SELECT * FROM [" + Resources.Properties.Settings.Default.SCHEMA_NAME + "].PERSONS").Execute();
            return (DataSet)results["ReturnedValues"];
        }

        public DataSet getDocTypes() {
            SqlResults results = new SqlQuery("SELECT * FROM [" + Resources.Properties.Settings.Default.SCHEMA_NAME + "].DOC_TYPE").Execute();
            return (DataSet)results["ReturnedValues"];
        }
        public bool PersonExistance(String name, String lastname, String docType, Decimal docNumber,  DateTime birthDate)
        {
            DataTable dt = this.getPersons().Tables[0];
            Boolean returnValue = false; ;
            foreach (DataRow row in dt.Rows)
            {
                if (row["name"].ToString() == name && row["lastname"].ToString() == lastname &&
                    row["doc_type"].ToString() == docType && (Decimal)row["doc_number"]== docNumber &&
                    (DateTime)row["birthdate"] == birthDate )
                {
                    returnValue = true;
                }

            }
            return returnValue;

        }

        public bool PersonExistance(String docType, Decimal docNumber)
        {


            SqlResults results = new SqlStoredProcedure("[" + Resources.Properties.Settings.Default.SCHEMA_NAME + "].SP_PERSON_EXISTS")
                                 .WithParam("@DocType").As(SqlDbType.VarChar).Value(docType)
                                 .WithParam("@DocNumber").As(SqlDbType.Decimal).Value(docNumber)
                                 .WithParam("@GuestExist").As(SqlDbType.Bit).AsOutput()
                                 .Execute();

            return (bool)results["@GuestExist"];

        }

        public Boolean emailExists(String anEmail)
        {
            DataTable dt = this.getPersons().Tables[0];
            Boolean returnValue = false; ;
            foreach (DataRow row in dt.Rows)
            {
                if (row["mail"].ToString() == anEmail)
                {
                    returnValue = true;
                }
                
            }
            return returnValue;

        }

        public Boolean emailExistsForUpdate(Int32 id_guest, String mail){
            if (!String.IsNullOrEmpty(mail))
            {
                SqlResults results = new SqlStoredProcedure("[" + Resources.Properties.Settings.Default.SCHEMA_NAME + "].SP_EMAIL_EXISTS_UPDATE")
                                    .WithParam("@Id").As(SqlDbType.Int).Value(id_guest)
                                    .WithParam("@Email").As(SqlDbType.VarChar).Value(mail)
                                    .WithParam("@EmailExist").As(SqlDbType.Bit).AsOutput()
                                    .Execute();

                return (Boolean)results["@EmailExist"];
            }
            else return false;
        
        }

        public Int32 insertPerson(String name, String lastname, String docType, Decimal docNumber, String mail, Decimal phone, DateTime birthDate,
                                String street, Int32 streetNum, Int32 floor, String dept, String nationality)
        {
            SqlResults results = new SqlStoredProcedure("[" + Resources.Properties.Settings.Default.SCHEMA_NAME + "].SP_INSERT_PERSON")
                                        .WithParam("@Name").As(SqlDbType.VarChar).Value(name)
                                        .WithParam("@Lastname").As(SqlDbType.VarChar).Value(lastname)
                                        .WithParam("@DocType").As(SqlDbType.VarChar).Value(docType)
                                        .WithParam("@DocNumber").As(SqlDbType.Decimal).Value(docNumber)
                                        .WithParam("@Mail").As(SqlDbType.VarChar).Value(mail)
                                        .WithParam("@Phone").As(SqlDbType.Decimal).Value(phone)
                                        .WithParam("@BirthDate").As(SqlDbType.DateTime).Value(birthDate)
                                        .WithParam("@Street").As(SqlDbType.VarChar).Value(street)
                                        .WithParam("@StreetNum").As(SqlDbType.Int).Value(streetNum)
                                        .WithParam("@Floor").As(SqlDbType.Int).Value(floor)
                                        .WithParam("@Dept").As(SqlDbType.VarChar).Value(dept)
                                        .WithParam("@Nationality").As(SqlDbType.VarChar).Value(nationality)
                                        .WithParam("@IdInserted").As(SqlDbType.Int).AsOutput()
                                        .Execute();

            return (Int32)results["@IdInserted"];

        }






        public Boolean updatePerson(String name, String lastname, String docType, Decimal docNumber, String mail, Decimal phone, DateTime birthDate,
                                String street, Int32 streetNum,Int32 floor, String dept, String nationality,Int32 state)
        {

            SqlResults results = new SqlStoredProcedure("[" + Resources.Properties.Settings.Default.SCHEMA_NAME + "].SP_UPDATE_PERSON")
                                     .WithParam("@Name").As(SqlDbType.VarChar).Value(name)
                                     .WithParam("@Lastname").As(SqlDbType.VarChar).Value(lastname)
                                     .WithParam("@DocType").As(SqlDbType.VarChar).Value(docType)
                                     .WithParam("@DocNumber").As(SqlDbType.Decimal).Value(docNumber)
                                     .WithParam("@Mail").As(SqlDbType.VarChar).Value(mail)
                                     .WithParam("@Phone").As(SqlDbType.Decimal).Value(phone)
                                     .WithParam("@BirthDate").As(SqlDbType.DateTime).Value(birthDate)
                                     .WithParam("@Street").As(SqlDbType.VarChar).Value(street)
                                     .WithParam("@StreetNum").As(SqlDbType.Int).Value(streetNum)
                                     .WithParam("@Floor").As(SqlDbType.Int).Value(floor)
                                     .WithParam("@Dept").As(SqlDbType.VarChar).Value(dept)
                                     .WithParam("@Nationality").As(SqlDbType.VarChar).Value(nationality)
                                     .WithParam("@State").As(SqlDbType.Int).Value(state)
                                     .WithParam("@Updated").As(SqlDbType.Bit).AsOutput()
                                                             .Execute();

            return (Boolean)results["@Updated"];
        }


        /*public DataTable filters(String name, String lastname, String docType, Decimal? docNumber, String mail) {
            SqlResults results = new SqlQuery()
        }*/
        public DataTable filteredSearch(String name, String lastname, String docType, Decimal? docNumber, String mail) {

            if (docNumber == -1)
            {
                SqlResults results = new SqlFunction("[" + Resources.Properties.Settings.Default.SCHEMA_NAME + "].SP_FILTER_PERSONS_NULLDOC")
                                   .WithParam("@Name").As(SqlDbType.VarChar).Value(name)
                                   .WithParam("@Lastname").As(SqlDbType.VarChar).Value(lastname)
                                   .WithParam("@DocType").As(SqlDbType.VarChar).Value(docType)
                                   .WithParam("@Mail").As(SqlDbType.VarChar).Value(mail)
                                   .Execute();

                return (DataTable)results["ReturnedValues"];
            }
            else {
                SqlResults results = new SqlFunction("[" + Resources.Properties.Settings.Default.SCHEMA_NAME + "].SP_FILTER_PERSONS")
                                   .WithParam("@Name").As(SqlDbType.VarChar).Value(name)
                                   .WithParam("@Lastname").As(SqlDbType.VarChar).Value(lastname)
                                   .WithParam("@DocType").As(SqlDbType.VarChar).Value(docType)
                                   .WithParam("@DocNumber").As(SqlDbType.Decimal).Value(docNumber)
                                   .WithParam("@Mail").As(SqlDbType.VarChar).Value(mail)
                                   .Execute();

                return (DataTable)results["ReturnedValues"];
            }

        }


        public Boolean deletePerson(Int32 id_guest)
        {

            SqlResults results = new SqlStoredProcedure("[" + Resources.Properties.Settings.Default.SCHEMA_NAME + "].SP_DELETE_PERSON")
                                     .WithParam("@IdGuest").As(SqlDbType.Int).Value(id_guest)
                                     .WithParam("@Deleted").As(SqlDbType.Bit).AsOutput()
                                     .Execute();

            return (Boolean)results["@Deleted"];
        }

        public DataTable getGuestInformation(Int32 id) {
            SqlResults results = new SqlFunction("[" + Resources.Properties.Settings.Default.SCHEMA_NAME + "].FUNCT_GET_INFO")
                                .WithParam("@IdPerson").As(SqlDbType.Int).Value(id)
                                .Execute();
            return (DataTable)results["ReturnedValues"];

        }


    }
}



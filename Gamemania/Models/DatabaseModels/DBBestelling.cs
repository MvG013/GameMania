using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gamemania.Models
{
    public class DBBestelling
    {
        private readonly OracleConnection _conn = new OracleConnection();


        public DBBestelling()
        {
            _conn.ConnectionString =
                            "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=fhictora01.fhict.local)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=fhictora)));User ID=dbi325253;PASSWORD=test123;";
        }
        DBProduct dbproduct = new DBProduct();
        DBUser dbuser = new DBUser();
        DBAdres dbadres = new DBAdres();

        public void Bestteling(int GebruikerID, string Plaats, string Straat, int Huisnummer, string Toevoeging, string Postcode, int ProductID, decimal Prijs)
        {
            //try
            //{
            if (_conn.State != System.Data.ConnectionState.Open)
            {
                _conn.Open();
            }

            OracleCommand cmd = new OracleCommand
            {
                Connection = _conn,
                BindByName = true,

                CommandText = "INSERT INTO BESTELLING (GEBRUIKERID , BESTELDATUM , FACTUURPLAATS , FACTUURSTRAAT , FACTUURHUISNUMMER , FACTUURTOEVOEGING , FACTUURPOSTCODE , PRODUCTID , AANTAL , PRIJS ) VALUES(:GEBRUIKERID , :BESTELDATUM , :FACTUURPLAATS , :FACTUURSTRAAT , :FACTUURHUISNUMMER, :FACTUURTOEVOEGING, :FACTUURPOSTCODE, :PRODUCTID, :AANTAL, :PRIJS)"
            };
            cmd.Parameters.Add("GEBRUIKERID", GebruikerID);
            cmd.Parameters.Add("BESTELDATUM", DateTime.Now.ToString("dd/mm/yyyy"));
            cmd.Parameters.Add("FACTUURPLAATS", Plaats);
            cmd.Parameters.Add("FACTUURSTRAAT", Straat);
            cmd.Parameters.Add("FACTUURHUISNUMMER", Huisnummer);
            cmd.Parameters.Add("FACTUURTOEVOEGING", Toevoeging);
            cmd.Parameters.Add("FACTUURPOSTCODE", Postcode);
            cmd.Parameters.Add("PRODUCTID", ProductID);
            cmd.Parameters.Add("AANTAL", 1);
            cmd.Parameters.Add("PRIJS", Prijs);

            cmd.ExecuteNonQuery();
            _conn.Close();
        }
        public BestellingModel GetBestelling(int GebruikerID, int ProductID)
        {
            //try
            //{
            if (_conn.State != System.Data.ConnectionState.Open)
            {
                _conn.Open();
            }

            OracleCommand cmd = new OracleCommand
            {
                Connection = _conn,
                BindByName = true,
                CommandText =
                    "select * from BESTELLING where GEBRUIKERID = :GebruikerID and PRODUCTID = :ProductID"
            };
            cmd.Parameters.Add("GebruikerID", GebruikerID);
            cmd.Parameters.Add("ProductID", ProductID);

            OracleDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                int BESTELID = (dr.GetInt32(0));
                int GEBRUIKERID = (dr.GetInt32(1));
                DateTime BESTELDATUM = (dr.GetDateTime(2));
                string FACTUURPLAATS = (dr.GetString(3));
                string FACTUURPSTRAAT = (dr.GetString(4));
                int FACTUURHUISNUMMER = (dr.GetInt32(5));
                string FACTUURTOEVOEGING = (dr.GetString(6));
                string FACTUURPOSTCODE = (dr.GetString(7));
                int PRODUCTID = (dr.GetInt32(8));
                int AANTAL = (dr.GetInt32(9));
                decimal PRIJS = (dr.GetDecimal(10));

                GebruikerModel gebruiker = dbuser.GetUserByID(GEBRUIKERID);

                if (_conn.State != System.Data.ConnectionState.Open)
                {
                    _conn.Open();
                }


                AdresModel adres = dbadres.GetAdres(gebruiker.Adres.AdresID);

                if (_conn.State != System.Data.ConnectionState.Open)
                {
                    _conn.Open();
                }


                ProductModel product = dbproduct.GetProduct(PRODUCTID);

                if (_conn.State != System.Data.ConnectionState.Open)
                {
                    _conn.Open();
                }

                BestellingModel Bestelling = new BestellingModel(BESTELDATUM, PRIJS, product, gebruiker, adres, AANTAL);
                return Bestelling;
            }

            _conn.Close();
            return null;
            //}
            //catch (OracleException e)
            //{
            //    Console.WriteLine("Message: " + e.Message);
            //    _conn.Close();
            //    return new List<ProductModel>();
            //}
        }

    }
}
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gamemania.Models
{
    public class DBAdres
    {
        private readonly OracleConnection _conn = new OracleConnection();


        public DBAdres()
        {
            _conn.ConnectionString =
                            "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=fhictora01.fhict.local)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=fhictora)));User ID=dbi325253;PASSWORD=test123;";
        }

        public AdresModel GetAdres(int Adresid)
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
                    "select * from ADRES"
            };

            OracleDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                int adresid = (dr.GetInt32(0));
                string land = (dr.GetString(1));
                string postcode = (dr.GetString(2));
                string plaatsnaam = (dr.GetString(3));
                string straatnaam = (dr.GetString(4));
                int huisnummer = (dr.GetInt32(5));
                string toevoeging = "";
                if ((dr.IsDBNull(6)))
                {
                    toevoeging = "";
                }
                else
                {
                    toevoeging = (dr.GetString(6));
                }


                AdresModel adres = new AdresModel(adresid, land, postcode, plaatsnaam, straatnaam, huisnummer, toevoeging);
                return adres;
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

        public int GetUserAdresID(string postcode, string straatnaam, int huisnummer)
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
                    "select ADRESID from ADRES where POSTCODE = :postcode and STRAATNAAM = :straatnaam and HUISNUMMER = :huisnummer"
            };
            cmd.Parameters.Add("postcode", postcode);
            cmd.Parameters.Add("straatnaam", straatnaam);
            cmd.Parameters.Add("huisnummer", huisnummer);

            OracleDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                int adresid = (dr.GetInt32(0));

                return adresid;
            }
            _conn.Close();
            return 0;

            //}
            //catch (OracleException e)
            //{
            //    Console.WriteLine("Message: " + e.Message);
            //    _conn.Close();
            //    return new List<ProductModel>();
            //}
        }


        public void RegAdres(string land, string postcode, string plaatsnaam, string straatnaam, int huisnummer, string toevoeging)
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

                CommandText = "INSERT INTO Adres (Land , Postcode , Plaatsnaam , Straatnaam , Huisnummer , Toevoeging) VALUES(:land , :postcode , :plaatsnaam , :straatnaam , :huisnummer , :toevoeging)"
            };
            cmd.Parameters.Add("land", land);
            cmd.Parameters.Add("postcode", postcode);
            cmd.Parameters.Add("plaatsnaam", plaatsnaam);
            cmd.Parameters.Add("straatnaam", straatnaam);
            cmd.Parameters.Add("huisnummer", huisnummer);
            cmd.Parameters.Add("toevoeging", toevoeging);

            cmd.ExecuteNonQuery();
            _conn.Close();
        }

        //
        //}
        //catch (OracleException e)
        //{
        //    Console.WriteLine("Message: " + e.Message);
        //    _conn.Close();
        //    return new List<ProductModel>();
        //}
    }
}
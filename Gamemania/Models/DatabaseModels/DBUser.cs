using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gamemania.Models
{
    public class DBUser
    {
        private readonly OracleConnection _conn = new OracleConnection();


        public DBUser()
        {
            _conn.ConnectionString =
                            "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=fhictora01.fhict.local)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=fhictora)));User ID=dbi325253;PASSWORD=test123;";
        }

        DBAdres dbadres = new DBAdres();

        public string CheckLogin(string gebruikersnaam)
        {
            //try
            //{
            _conn.Open();
            OracleCommand cmd = new OracleCommand
            {
                BindByName = true,
                Connection = _conn,
                CommandText = "SELECT WACHTWOORD FROM GEBRUIKER WHERE GEBRUIKERSNAAM= :param"
            };
            cmd.Parameters.Add("param", gebruikersnaam);
            OracleDataReader dr = cmd.ExecuteReader();
            dr.Read();
            string wachtwoord = null;
            if (dr.HasRows)
            {

                wachtwoord = dr.GetString(0);

            }
            _conn.Close();
            return wachtwoord;
        }
        //catch (OracleException e)
        //{
        //    Console.WriteLine("Message: " + e.Message);
        //    _conn.Close();
        //    return null;
        //}

        public void RegUser(string gebruikersnaam, string wachtwoord, string voornaam, string tussenvoegsel, string achternaam,
    DateTime geboortedatum, string email, int telefoonnummer, string land, string postcode, string plaatsnaam, string straatnaam, int huisnummer, string toevoeging)
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

                CommandText = "INSERT INTO GEBRUIKER(ADRESID,GEBRUIKERSNAAM, WACHTWOORD, VOORNAAM, TUSSENVOEGSEL ,ACHTERNAAM, GEBOORTEDATUM, EMAIL ,GSM) VALUES(:adres,:gebruikersnaam, :wachtwoord , :voornaam , :tussenvoegsel , :achternaam , :geboortedatum , :email , :GSM)"
            };
            cmd.Parameters.Add("gebruikersnaam", gebruikersnaam);
            cmd.Parameters.Add("wachtwoord", wachtwoord);
            cmd.Parameters.Add("voornaam", voornaam);
            cmd.Parameters.Add("tussenvoegsel", tussenvoegsel);
            cmd.Parameters.Add("achternaam", achternaam);
            cmd.Parameters.Add("geboortedatum", geboortedatum);
            cmd.Parameters.Add("email", email);
            cmd.Parameters.Add("GSM", telefoonnummer);

            dbadres.RegAdres(land, postcode, plaatsnaam, straatnaam, huisnummer, toevoeging);
            if (_conn.State != System.Data.ConnectionState.Open)
            {
                _conn.Open();
            }
            cmd.Parameters.Add("adres", dbadres.GetUserAdresID(postcode, straatnaam, huisnummer));

            if (_conn.State != System.Data.ConnectionState.Open)
            {
                _conn.Open();
            }
            cmd.ExecuteNonQuery();
            _conn.Close();

        }


        public GebruikerModel GetUser(string Gebruikersnaam, string Wachtwoord)
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
                    "select * from GEBRUIKER where GEBRUIKERSNAAM = :Gebruikersnaam and WACHTWOORD = :Wachtwoord"
            };
            cmd.Parameters.Add("Gebruikersnaam", Gebruikersnaam);
            cmd.Parameters.Add("Wachtwoord", Wachtwoord);

            OracleDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                int gebruikerid = (dr.GetInt32(0));
                int adresid = (dr.GetInt32(1));
                string gebruikersnaam = (dr.GetString(2));
                string wachtwoord = (dr.GetString(3));
                string voornaam = (dr.GetString(4));
                string tussenvoegsel = (dr.GetString(5));
                string achternaam = (dr.GetString(6));
                DateTime geboortedatum = (dr.GetDateTime(7));
                string email = (dr.GetString(8));
                int telefoonnummer = (dr.GetInt32(9));

                AdresModel adres = dbadres.GetAdres(adresid);

                GebruikerModel gebruiker = new GebruikerModel(gebruikerid, gebruikersnaam, wachtwoord, voornaam, tussenvoegsel, achternaam, geboortedatum, email, telefoonnummer, adres);
                return gebruiker;
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

        public GebruikerModel GetUserByID(int GebruikerID)
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
                    "select * from GEBRUIKER where GEBRUIKERID = :GebruikerID"
            };
            cmd.Parameters.Add("GebruikerID", GebruikerID);

            OracleDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                int gebruikerid = (dr.GetInt32(0));
                int adresid = (dr.GetInt32(1));
                string gebruikersnaam = (dr.GetString(2));
                string wachtwoord = (dr.GetString(3));
                string voornaam = (dr.GetString(4));
                string tussenvoegsel = (dr.GetString(5));
                string achternaam = (dr.GetString(6));
                DateTime geboortedatum = (dr.GetDateTime(7));
                string email = (dr.GetString(8));
                int telefoonnummer = (dr.GetInt32(9));

                AdresModel adres = dbadres.GetAdres(adresid);

                GebruikerModel gebruiker = new GebruikerModel(gebruikerid, gebruikersnaam, wachtwoord, voornaam, tussenvoegsel, achternaam, geboortedatum, email, telefoonnummer, adres);
                return gebruiker;
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
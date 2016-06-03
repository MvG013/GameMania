using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gamemania.Models
{
    public class DB
    {
        private readonly OracleConnection _conn = new OracleConnection();


        public DB()
        {
            _conn.ConnectionString =
                            "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=fhictora01.fhict.local)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=fhictora)));User ID=dbi325253;PASSWORD=test123;";
        }

        public List<ProductModel> GetConsoles(int catergorie ,int consoleid)
        {

            List<ProductModel> rtn = new List<ProductModel>();

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
                        "select * from PRODUCT where CATEGORIEID = :par and CONSOLEID = :para"
                };
                cmd.Parameters.Add("par", catergorie);
                cmd.Parameters.Add("para", consoleid);
                OracleDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    int id = (dr.GetInt32(0));
                    string naam = (dr.GetString(3));
                    string uitgever = (dr.GetString(5));
                    string beschrijving = (dr.GetString(6));
                    decimal prijs = (dr.GetDecimal(7));
                    string plaatje = (dr.GetString(9));
                    ProductModel toAdd = new ProductModel(id, naam, uitgever, prijs, plaatje, beschrijving , (ProductModel.Consoles)Enum.Parse(typeof(ProductModel.Consoles), naam));
                    rtn.Add(toAdd);
                
                }

                _conn.Close();
                return rtn;
            //}
            //catch (OracleException e)
            //{
            //    Console.WriteLine("Message: " + e.Message);
            //    _conn.Close();
            //    return new List<ProductModel>();
            //}
        }

        public List<ProductModel> AlleProductenMetConsole(int categorieid, string consolenaam)
        {

            List<ProductModel> rtn = new List<ProductModel>();

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
                        "select * from PRODUCT where CATEGORIEID = :par and CONSOLEID = (select CONSOLEID from CONSOLE where naam = :para)"
                };
                cmd.Parameters.Add("par", categorieid);
                cmd.Parameters.Add("para", consolenaam);
                OracleDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    int id = (dr.GetInt32(0));
                    string naam = (dr.GetString(3));
                    string uitgever = (dr.GetString(5));
                    string beschrijving = (dr.GetString(6));
                    decimal prijs = (dr.GetDecimal(7));
                    string plaatje = (dr.GetString(9));
                    ProductModel toAdd = new ProductModel(id , naam , uitgever , prijs , plaatje , beschrijving);
                    rtn.Add(toAdd);
                }

                _conn.Close();
                return rtn;
            //}
            //catch (OracleException e)
            //{
            //    Console.WriteLine("Message: " + e.Message);
            //    _conn.Close();
            //    return new List<ProductModel>();
            //}
        }

        public ProductModel GetProduct(int id)
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
                        "select * from PRODUCT where PRODUCTID = :para"
                };

                cmd.Parameters.Add("para", id);
                OracleDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    int ID = (dr.GetInt32(0));
                    string naam = (dr.GetString(3));
                    string uitgever = (dr.GetString(5));
                    string beschrijving = (dr.GetString(6));
                    decimal prijs = (dr.GetDecimal(7));
                    string plaatje = (dr.GetString(9));
                    ProductModel game = new ProductModel(ID, naam, uitgever, prijs, plaatje , beschrijving);
                return game;             
                }

                _conn.Close();
                return null;
            //}
            //catch (OracleException e)
            //{
            //    Console.WriteLine("Message: " + e.Message);
            //    _conn.Close();
            //    return null;
            //}
        }

        public List<ProductModel> AlleProductenZonderConsole(int categorieid)
        {

            List<ProductModel> rtn = new List<ProductModel>();

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
                    "select * from PRODUCT where CATEGORIEID = :par"
            };
            cmd.Parameters.Add("par", categorieid);
            OracleDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                int id = (dr.GetInt32(0));
                string naam = (dr.GetString(3));
                string uitgever = (dr.GetString(5));
                string beschrijving = (dr.GetString(6));
                decimal prijs = (dr.GetDecimal(7));
                string plaatje = (dr.GetString(9));
                ProductModel toAdd = new ProductModel(id, naam, uitgever, prijs, plaatje, beschrijving);
                rtn.Add(toAdd);
            }

            _conn.Close();
            return rtn;
            //}
            //catch (OracleException e)
            //{
            //    Console.WriteLine("Message: " + e.Message);
            //    _conn.Close();
            //    return new List<ProductModel>();
            //}
        }

        public List<WinkelModel> GetStores()
        {

            List<WinkelModel> rtn = new List<WinkelModel>();

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
                        "select * from WINKEL"
                };

                OracleDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    
                    int adresid = (dr.GetInt32(1));
                    string naam = (dr.GetString(2));
                    int Telefoonnummer = (dr.GetInt32(3));
                    AdresModel adres = GetAdres(adresid);
                if (_conn.State != System.Data.ConnectionState.Open)
                {
                    _conn.Open();
                }
                WinkelModel toAdd = new WinkelModel(adres ,naam , Telefoonnummer);
                    rtn.Add(toAdd);
                }

                _conn.Close();
                return rtn;
            //}
            //catch (OracleException e)
            //{
            //    Console.WriteLine("Message: " + e.Message);
            //    _conn.Close();
            //    return new List<ProductModel>();
            //}
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


                AdresModel adres = new AdresModel(adresid , land, postcode , plaatsnaam , straatnaam , huisnummer , toevoeging);
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

        public int GetUserAdresID(string postcode, string straatnaam , int huisnummer)
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


        public void RegUser(string gebruikersnaam, string wachtwoord, string voornaam, string tussenvoegsel, string achternaam,
            DateTime geboortedatum, string email, int telefoonnummer , string land, string postcode, string plaatsnaam, string straatnaam, int huisnummer, string toevoeging)
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

            RegAdres(land, postcode, plaatsnaam, straatnaam, huisnummer, toevoeging);
            if (_conn.State != System.Data.ConnectionState.Open)
            {
                _conn.Open();
            }
            cmd.Parameters.Add("adres", GetUserAdresID(postcode, straatnaam, huisnummer));

            if (_conn.State != System.Data.ConnectionState.Open)
            {
                _conn.Open();
            }
            cmd.ExecuteNonQuery();
            _conn.Close();

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

        public GebruikerModel GetUser(string Gebruikersnaam , string Wachtwoord)
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

                AdresModel adres = GetAdres(adresid);

                GebruikerModel gebruiker = new GebruikerModel(gebruikerid , gebruikersnaam, wachtwoord, voornaam, tussenvoegsel, achternaam, geboortedatum, email, telefoonnummer, adres);
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

        public void Bestteling(int GebruikerID , string Plaats , string Straat,  int Huisnummer , string Toevoeging , string Postcode , int ProductID , decimal Prijs)
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
            cmd.Parameters.Add("BESTELDATUM", DateTime.Now.ToString("dd/MMM/yyyy hh/mm/ss tt"));
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

                GebruikerModel gebruiker = GetUserByID(GEBRUIKERID);

                if (_conn.State != System.Data.ConnectionState.Open)
                {
                    _conn.Open();
                }

                AdresModel adres = GetAdres(gebruiker.Adres.AdresID);

                if (_conn.State != System.Data.ConnectionState.Open)
                {
                    _conn.Open();
                }

                ProductModel product = GetProduct(PRODUCTID);

                if (_conn.State != System.Data.ConnectionState.Open)
                {
                    _conn.Open();
                }

                BestellingModel Bestelling = new BestellingModel(BESTELDATUM , PRIJS, product , gebruiker , adres , AANTAL);
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

                AdresModel adres = GetAdres(adresid);

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

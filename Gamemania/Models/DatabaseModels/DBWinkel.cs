using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gamemania.Models
{
    public class DBWinkel
    {
        private readonly OracleConnection _conn = new OracleConnection();


        public DBWinkel()
        {
            _conn.ConnectionString =
                            "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=fhictora01.fhict.local)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=fhictora)));User ID=dbi325253;PASSWORD=test123;";
        }

        DBAdres dbadres = new DBAdres();
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
                AdresModel adres = dbadres.GetAdres(adresid);
                if (_conn.State != System.Data.ConnectionState.Open)
                {
                    _conn.Open();
                }
                WinkelModel toAdd = new WinkelModel(adres, naam, Telefoonnummer);
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


    }
}
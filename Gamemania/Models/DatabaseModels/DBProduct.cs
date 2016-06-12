using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gamemania.Models
{
    public class DBProduct
    {
        private readonly OracleConnection _conn = new OracleConnection();


        public DBProduct()
        {
            _conn.ConnectionString =
                            "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=fhictora01.fhict.local)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=fhictora)));User ID=dbi325253;PASSWORD=test123;";
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
                ProductModel game = new ProductModel(ID, naam, uitgever, prijs, plaatje, beschrijving);
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


        public List<ProductModel> GetConsoles(int catergorie, int consoleid)
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
                ProductModel toAdd = new ProductModel(id, naam, uitgever, prijs, plaatje, beschrijving, (ProductModel.Consoles)Enum.Parse(typeof(ProductModel.Consoles), naam));
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


    }
}
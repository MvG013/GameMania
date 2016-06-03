using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.ManagedDataAccess.Client;

namespace Gamemania.Models
{
    public class ProductModel
    {
        public int ID { get; set; }
        public string Naam { get; set; }
        public int Korting { get; set; }
        public string Uitgever { get; set; }
        public decimal Prijs { get; set; }
        public int Aantal { get; set; }
        public string Beschrijving { get; set; }
        public Consoles ConsoleLijst { get; set; }
        public Categorie CategorieLijst { get; set; }
        public Genre GenreLijst { get; set; }
        public string Plaatje { get; set; }


        public enum Consoles 
        {
            Xbox360 = 1,
            XboxONE = 2,
            Playstation3 = 3,
            Playstation4 = 4,
            PlaystationVita = 5,
            Wii = 6,
            WiiU = 7,
            NintendoDS = 8,
            Nintendo3DS = 9,
            PC = 10,
        }


            

        public enum Categorie
        {
            Games = 1,
            Consoles = 2,
            Accessoires = 3,
            Merchandise = 4,
            Boardgames = 5,
        }

        public enum Genre
        {
            Shooter = 1,
            Platform = 2,
            RPG = 3,
            ActionAdventure = 4,
            Strategy= 5,
        }

        public ProductModel(int id , string naam , int korting , string uitgever , decimal prijs, int aantal , string beschrijving , Consoles console, Categorie categorie, Genre genre , string plaatje)
        {
            ID = id;
            Naam = naam;
            Korting = korting;
            Uitgever = uitgever;
            Prijs = prijs;
            Aantal = aantal;
            Beschrijving = beschrijving;
            ConsoleLijst = console;
            CategorieLijst = categorie;
            GenreLijst = genre;
            Plaatje = plaatje;
        }

        public ProductModel(int id ,string naam, string uitgever , decimal prijs, string plaatje , string beschrijving , Consoles console)
        {
            ID = id;
            Naam = naam;
            Uitgever = uitgever;
            Prijs = prijs;
            Plaatje = plaatje;
            Beschrijving = beschrijving;
            ConsoleLijst = console;
        }

        public ProductModel(int id, string naam, string uitgever, decimal prijs, string plaatje, string beschrijving)
        {
            ID = id;
            Naam = naam;
            Uitgever = uitgever;
            Prijs = prijs;
            Plaatje = plaatje;
            Beschrijving = beschrijving;
        }
        public ProductModel(int id)
        {
            ID = id;
        }

        public ProductModel()
        {

        }

        public ProductModel ToevoegenProduct(int id, string naam, int korting, string uitgever, decimal prijs, int aantal, string beschrijving, Consoles console, Categorie categorie, Genre genre, string plaatje)
        {
            ProductModel Product = new ProductModel(id , naam, korting ,  uitgever , prijs , aantal , beschrijving , console , categorie , genre , plaatje);
            return Product;
        }

        public ProductModel WijzigProduct(int id ,string naam, int korting, string uitgever, decimal prijs, int aantal, string beschrijving, Consoles console, Categorie categorie, Genre genre , string plaatje)
        {
            ProductModel Product = new ProductModel(id , naam, korting, uitgever, prijs, aantal, beschrijving, console, categorie, genre , plaatje);
            return Product;
        }

        public void VerwijderenProduct(string naam, int korting, string uitgever, decimal prijs, int aantal, string beschrijving, Consoles console, Categorie categorie, Genre genre)
        {

        }

    }
}
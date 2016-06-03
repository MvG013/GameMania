using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gamemania.Models
{
    public class BestellingModel
    {
        public DateTime Orderdatum { get; set; }
        public int Aantal { get; set; }
        public decimal Prijs { get; set; }
        public bool Eigenadres { get; set; }

        public ProductModel Producten = new ProductModel();

        public GebruikerModel Gebruiker = new GebruikerModel();

        public AdresModel Adres = new AdresModel();

        public BestellingModel(DateTime orderdatum , decimal prijs , ProductModel producten , GebruikerModel gebruiker , AdresModel bezorgadres , int aantal)
        {
            Producten = producten;
            Gebruiker = gebruiker;
            Adres = bezorgadres;
            Orderdatum = orderdatum;
            Prijs = prijs;
            Aantal = aantal;

        }
        public BestellingModel ToevoegenBestelling(DateTime Orderdatum, decimal Totaalprijs, List<ProductModel> producten , List<GebruikerModel> Gebruiker , List<AdresModel> Bezorgadres)
        {
            return null;
        }
    }
}
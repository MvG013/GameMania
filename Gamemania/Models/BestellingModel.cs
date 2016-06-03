using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gamemania.Models
{
    public class BestellingModel
    {
        public DateTime Orderdatum { get; set; }
        public decimal Totaalprijs { get; set; }
        public bool Eigenadres { get; set; }

        public ProductModel Producten = new ProductModel();

        public GebruikerModel Gebruiker = new GebruikerModel();

        public AdresModel Adres = new AdresModel();

        public BestellingModel(DateTime orderdatum , decimal totaalprijs , List<ProductModel> producten , List<GebruikerModel> gebruikers , List<AdresModel> bezorgadres)
        {
            Orderdatum = orderdatum;
            Totaalprijs = totaalprijs;

        }
        public BestellingModel ToevoegenBestelling(DateTime Orderdatum, decimal Totaalprijs, List<ProductModel> producten , List<GebruikerModel> Gebruiker , List<AdresModel> Bezorgadres)
        {
            BestellingModel Bestelling = new BestellingModel(Orderdatum, Totaalprijs, producten ,Gebruiker , Bezorgadres);
            return Bestelling;
        }
    }
}
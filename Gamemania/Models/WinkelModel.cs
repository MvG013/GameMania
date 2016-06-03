using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gamemania.Models
{
    public class WinkelModel
    {
        public AdresModel Adres = new AdresModel();

        public int AdresID { get; set; }
        public string Naam { get; set; }
        public int Telefoonnummer { get; set; }

        public WinkelModel(AdresModel adres, string naam , int telefoonnummer)
        {
            Adres = adres;
            Naam = naam;
            Telefoonnummer = telefoonnummer;
        }

        public WinkelModel WinkelToevoegen(AdresModel adres, string naam, int telefoonnummer)
        {

            WinkelModel Winkel = new WinkelModel(adres , naam , telefoonnummer);
            return Winkel;

        }
    }
}
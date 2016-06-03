using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gamemania.Models
{
    public class LijstModel
    {
       public string Naam { get; set; }
        public string Beschrijving { get; set; }

        List<ProductModel> ProductLijst = new List<ProductModel>();

        public LijstModel(string naam , string beschrijving , List<ProductModel> productLijst)
        {
            Naam = naam;
            Beschrijving = beschrijving;
            ProductLijst = productLijst;
        }
        public void ToevoegenProduct(string naam , List<ProductModel> ProductLijst , GebruikerModel gebruiker)
        {

        }

        public void VerwijderenProduct(string naam, List<ProductModel> ProductLijst, GebruikerModel gebruiker)
        {

        }
}
}
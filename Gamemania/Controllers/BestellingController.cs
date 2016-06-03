using Gamemania.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gamemania.Controllers
{
    public class BestellingController : Controller
    {
        // GET: Bestelling
        public ActionResult Bestelling(int GebruikerID , int ProductID , decimal prijs)
        {
            GebruikerID = (int)Session["GebruikerID"];
            DB database = new DB();

            GebruikerModel gebruiker = database.GetUserByID(GebruikerID);

            database.Bestteling(gebruiker.GebruikerID, gebruiker.Adres.Plaatsnaam, gebruiker.Adres.Straatnaam , gebruiker.Adres.Huisnummer, gebruiker.Adres.Toevoeging, gebruiker.Adres.Postcode, ProductID, prijs);

            BestellingModel bestelling = database.GetBestelling(gebruiker.GebruikerID, ProductID);
            return View(bestelling);
        }
    }
}
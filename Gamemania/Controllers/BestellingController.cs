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
            DB database = new DB();


            return View();
        }
    }
}
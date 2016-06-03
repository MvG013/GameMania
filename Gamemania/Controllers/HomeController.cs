using Gamemania.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gamemania.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Accessoires()
        {
            DB database = new DB();
            List<ProductModel> Consoles = database.GetConsoles(2 , 0);

            return View(Consoles);
        }

        public ActionResult Boardgames()
        {
            DB database = new DB();
            List<ProductModel> producten = database.AlleProductenZonderConsole(6);

            return View(producten);
        }

        public ActionResult Consoles()
        {
            DB database = new DB();
            List<ProductModel> Consoles = database.GetConsoles(2 , 0);

            return View(Consoles);
        }

        public ActionResult Games()
        {
            DB database = new DB();
            List<ProductModel> Consoles = database.GetConsoles(2 , 0);

            return View(Consoles);
        }

        public ActionResult Merchandise()
        {
            DB database = new DB();
            List<ProductModel> producten = database.AlleProductenZonderConsole(5);

            return View(producten);
        }

        public ActionResult Stores()
        {
            DB database = new DB();
            List<WinkelModel> winkels = database.GetStores();

            return View(winkels);
        }
        public ActionResult Manage()
        {
            int GebruikerID = (int)Session["GebruikerID"];
            DB database = new DB();
            GebruikerModel gebruiker =  database.GetUserByID(GebruikerID);

            return View();
        }


    }
}
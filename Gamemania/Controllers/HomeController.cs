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
            DBProduct dbproduct = new DBProduct();
            List<ProductModel> Consoles = dbproduct.GetConsoles(2 , 0);

            return View(Consoles);
        }

        public ActionResult Boardgames()
        {
            DBProduct dbproduct = new DBProduct();
            List<ProductModel> producten = dbproduct.AlleProductenZonderConsole(6);

            return View(producten);
        }

        public ActionResult Consoles()
        {
            DBProduct dbproduct = new DBProduct();
            List<ProductModel> Consoles = dbproduct.GetConsoles(2 , 0);

            return View(Consoles);
        }

        public ActionResult Games()
        {
            DBProduct dbproduct = new DBProduct();
            List<ProductModel> Consoles = dbproduct.GetConsoles(2 , 0);

            return View(Consoles);
        }

        public ActionResult Merchandise()
        {
            DBProduct dbproduct = new DBProduct();
            List<ProductModel> producten = dbproduct.AlleProductenZonderConsole(5);

            return View(producten);
        }

        public ActionResult Stores()
        {
            DBWinkel dbwinkel = new DBWinkel();
            List<WinkelModel> winkels = dbwinkel.GetStores();

            return View(winkels);
        }
        public ActionResult Manage()
        {
            int GebruikerID = (int)Session["GebruikerID"];
            DBUser dbuser = new DBUser();
            GebruikerModel gebruiker =  dbuser.GetUserByID(GebruikerID);

            return View();
        }


    }
}
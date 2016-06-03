using Gamemania.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gamemania.Controllers
{
    public class ProductenController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Product(int id)
        {
            DB database = new DB();
            ProductModel product = database.GetProduct(id);

            return View(product);
        }

        public ActionResult Producten(int categorieid , string consolenaam)
        {
            DB database = new DB();
            List<ProductModel> producten = database.AlleProductenMetConsole(categorieid , consolenaam);

            return View(producten);
        }

    }
}
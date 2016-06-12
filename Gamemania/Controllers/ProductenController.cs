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
            DBProduct dbproduct = new DBProduct();
            ProductModel product = dbproduct.GetProduct(id);

            return View(product);
        }

        public ActionResult Producten(int categorieid , string consolenaam)
        {
            DBProduct dbproduct = new DBProduct();
            List<ProductModel> producten = dbproduct.AlleProductenMetConsole(categorieid , consolenaam);

            return View(producten);
        }

    }
}
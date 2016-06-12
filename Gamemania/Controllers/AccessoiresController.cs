using Gamemania.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gamemania.Controllers
{
    public class AccessoiresController : Controller
    {
        // GET: Accesoires
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Accessoire(int id)
        {
            DBProduct dbproduct = new DBProduct();
            ProductModel accessoire = dbproduct.GetProduct(id);

            return View(accessoire);
        }

        public ActionResult Accessoires(int categorieid, string consolenaam)
        {
            DBProduct dbproduct = new DBProduct();
            List<ProductModel> Accessoires = dbproduct.AlleProductenMetConsole(categorieid, consolenaam);

            return View(Accessoires);
        }
    }
}
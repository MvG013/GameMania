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
            DB database = new DB();
            ProductModel accessoire = database.GetProduct(id);

            return View(accessoire);
        }

        public ActionResult Accessoires(int categorieid, string consolenaam)
        {
            DB database = new DB();
            List<ProductModel> Accessoires = database.AlleProductenMetConsole(categorieid, consolenaam);

            return View(Accessoires);
        }
    }
}
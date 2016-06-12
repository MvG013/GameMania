using Microsoft.VisualStudio.TestTools.UnitTesting;
using Gamemania.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamemania.Models.Tests
{
    [TestClass()]
    public class DBProductTests
    {
        [TestMethod()]
        public void GetProductTest()
        {
            DBProduct dbproduct = new DBProduct();
            ProductModel product = dbproduct.GetProduct(64);
            Equals(product.Naam = "Playstation4");
        }

        [TestMethod()]
        public void GetConsolesTest()
        {
            DBProduct dbproduct = new DBProduct();
            List<ProductModel> consoles = dbproduct.GetConsoles(2, 4);
            Equals(consoles[0].Uitgever = "Sony");
        }


    }
}
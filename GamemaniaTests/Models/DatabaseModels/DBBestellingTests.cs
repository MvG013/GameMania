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
    public class DBBestellingTests
    {
        [TestMethod()]
        public void GetBestellingTest()
        {
            string datumstring = "11-6-2016";
            DateTime datum = Convert.ToDateTime(datumstring);
            DBBestelling dbbestelling = new DBBestelling();
            BestellingModel bestelling = dbbestelling.GetBestelling(5, 70);
            Equals(bestelling.Orderdatum = datum);
        }
    }
}
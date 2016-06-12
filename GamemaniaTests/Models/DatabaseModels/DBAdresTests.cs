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
    public class DBAdresTests
    {
        [TestMethod()]
        public void GetAdresTest()
        {
            DBAdres dbadres = new DBAdres();
            AdresModel Adres = dbadres.GetAdres(1);
            Equals(Adres.Plaatsnaam = "Hilvarenbeek");
        }

        [TestMethod()]
        public void GetUserAdresIDTest()
        {
            DBAdres dbadres = new DBAdres();
            int Adresid = dbadres.GetUserAdresID("5081CP", "Rensstraat", 3);
            Equals(Adresid = 1);
        }

        //DBUser dbuser = new DBUser();
        //LoginViewModel lvm = new LoginViewModel();
        //lvm.Gebruikersnaam = "Henk";
        //    lvm.Password = "Henk123#";
        //    Equals(dbuser.CheckLogin("Henk123#"));
    }
}
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
    public class DBUserTests
    {
        [TestMethod()]
        public void GetUserTest()
        {
            DBUser dbuser = new DBUser();
            GebruikerModel user = dbuser.GetUser("Henk", "Henk123#");
            Equals(user.Achternaam = "Nagelbeek");
        }

        [TestMethod()]
        public void GetUserByIDTest()
        {
            DBUser dbuser = new DBUser();
            GebruikerModel user = dbuser.GetUserByID(5);
            Equals(user.Email = "henk@gmail.com");
        }
    }
}
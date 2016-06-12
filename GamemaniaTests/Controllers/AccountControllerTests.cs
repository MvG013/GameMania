using Microsoft.VisualStudio.TestTools.UnitTesting;
using Gamemania.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gamemania.Models;

namespace Gamemania.Controllers.Tests
{
    [TestClass()]
    public class AccountControllerTests
    {

        [TestMethod()]
        public void LoginTest()
        {
            DBUser dbuser = new DBUser();
            LoginViewModel lvm = new LoginViewModel();
            lvm.Gebruikersnaam = "Henk";
            lvm.Password = "Henk123#";
            Equals(dbuser.CheckLogin("Henk123#"));
        }
    }
}
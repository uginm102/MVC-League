using System;
using System.Web.Mvc;
using League.Areas.Admin.Controllers;
using League.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace League.Tests.Controllers
{
    [TestClass]
    public class RefereeControllerTest
    {
        [TestMethod]
        public async void TestCreate()
        {
            RefereeController controller = new RefereeController();

            Referee referee = new Referee {DOB = DateTime.Now, FirstName = "Testfirstname", LastName = "Testlastname"};

            ViewResult result = await controller.Create(referee) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}

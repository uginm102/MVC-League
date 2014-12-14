using System;
using League.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace League.Tests.Models
{
    [TestClass]
    public class RefereeUnitTest
    {
        [TestMethod]
        public void TestCreateReferee()
        {
            Referee referee = new Referee {FirstName = "Eugene", LastName = "Munyaneza", DOB = DateTime.Now};
        }
    }
}

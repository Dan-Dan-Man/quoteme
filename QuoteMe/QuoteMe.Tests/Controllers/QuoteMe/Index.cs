using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuoteMe.MVC.Controllers;
using QuoteMe.MVC.Services.FinancePlanCalculator;

namespace QuoteMe.Tests.Controllers.QuoteMe
{
    [TestClass]
    public class Index
    {
        [TestMethod]
        public void Test_Correct_View_Returned()
        {
            var controller = new QuoteMeController(new InterestFreeFinancePlanCalculator());
            var result = controller.Index() as ViewResult;
            Assert.AreEqual("Index", result.ViewName);
        }
    }
}

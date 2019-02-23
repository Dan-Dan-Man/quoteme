using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuoteMe.MVC.Controllers;
using QuoteMe.MVC.Models;
using QuoteMe.MVC.Services.FinancePlanCalculator;

namespace QuoteMe.Tests.Controllers.QuoteMe
{
    [TestClass]
    public class QuoteForm
    {
        private const decimal ExpectedArrangementFee = 88;
        private const decimal ExpectedCompletionFee = 20;
        private PartialViewResult _result;
        private Quote _quote;

        [TestInitialize]
        public void SetupTest()
        {
            var controller = new QuoteMeController(new InterestFreeFinancePlanCalculator());
            _result = controller.QuoteForm() as PartialViewResult;
            _quote = (Quote) _result.ViewData.Model;
        }

        [TestMethod]
        public void Test_Correct_View_Returned()
        {
            Assert.AreEqual("QuoteForm", _result.ViewName);
        }

        [TestMethod]
        public void Test_Correct_Arrangement_Fee_Set()
        {
            Assert.AreEqual(ExpectedArrangementFee, _quote.ArrangementFee);
        }

        [TestMethod]
        public void Test_Correct_Completion_Fee_Set()
        {
            Assert.AreEqual(ExpectedCompletionFee, _quote.CompletionFee);
        }
    }
}

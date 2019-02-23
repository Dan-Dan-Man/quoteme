using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuoteMe.MVC.Controllers;

namespace QuoteMe.Tests.Controllers.QuoteMeValidation
{
    public abstract class QuoteMeValidationBase
    {
        private object _expectedResponse;
        private JsonResult _jsonResult;

        [TestInitialize]
        public void SetupTest()
        {
            var controller = new QuoteMeValidationController();
            _expectedResponse = GetExpectedResponse();
            _jsonResult = ExecuteRemoteValidation(controller);
        }

        [TestMethod]
        public void Result_Has_Correct_Data()
        {
            Assert.AreEqual(_expectedResponse, _jsonResult.Data);
        }

        [TestMethod]
        public void Result_Has_Correct_Behaviour()
        {
            Assert.AreEqual(JsonRequestBehavior.AllowGet, _jsonResult.JsonRequestBehavior);
        }

        protected abstract JsonResult ExecuteRemoteValidation(QuoteMeValidationController controller);
        protected abstract object GetExpectedResponse();
    }
}

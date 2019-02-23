using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuoteMe.MVC.Controllers;

namespace QuoteMe.Tests.Controllers.QuoteMeValidation.ValidateArrangementFee
{
    [TestClass]
    public class ValidateArrangementFee_More_Than_Zero : QuoteMeValidationBase
    {
        protected override JsonResult ExecuteRemoteValidation(QuoteMeValidationController controller)
        {
            return controller.ValidateArrangementFee(10) as JsonResult;
        }

        protected override object GetExpectedResponse()
        {
            return true;
        }
    }
}

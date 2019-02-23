using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuoteMe.MVC.Controllers;

namespace QuoteMe.Tests.Controllers.QuoteMeValidation.ValidateArrangementFee
{
    [TestClass]
    public class ValidateArrangementFee_Equal_To_Zero : QuoteMeValidationBase
    {
        protected override JsonResult ExecuteRemoteValidation(QuoteMeValidationController controller)
        {
            return controller.ValidateArrangementFee(0) as JsonResult;
        }

        protected override object GetExpectedResponse()
        {
            return true;
        }
    }
}

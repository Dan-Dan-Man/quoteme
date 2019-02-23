using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuoteMe.MVC.Controllers;

namespace QuoteMe.Tests.Controllers.QuoteMeValidation.ValidateCompletionFee
{
    [TestClass]
    public class ValidateCompletionFee_More_Than_Zero : QuoteMeValidationBase
    {
        protected override JsonResult ExecuteRemoteValidation(QuoteMeValidationController controller)
        {
            return controller.ValidateCompletionFee(10) as JsonResult;
        }

        protected override object GetExpectedResponse()
        {
            return true;
        }
    }
}

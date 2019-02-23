using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuoteMe.MVC.Controllers;

namespace QuoteMe.Tests.Controllers.QuoteMeValidation.ValidateDepositAmount
{
    [TestClass]
    public class ValidateDepositAmount_Less_Than_Zero : QuoteMeValidationBase
    {
        protected override JsonResult ExecuteRemoteValidation(QuoteMeValidationController controller)
        {
            return controller.ValidateDepositAmount(-10, 100) as JsonResult;
        }

        protected override object GetExpectedResponse()
        {
            return "Deposit Amount must not be negative.";
        }
    }
}

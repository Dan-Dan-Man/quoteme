using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuoteMe.MVC.Controllers;

namespace QuoteMe.Tests.Controllers.QuoteMeValidation.ValidateDepositAmount
{
    [TestClass]
    public class ValidateDepositAmount_Equal_To_15_Percent_Of_Vehicle_Price : QuoteMeValidationBase
    {
        protected override JsonResult ExecuteRemoteValidation(QuoteMeValidationController controller)
        {
            return controller.ValidateDepositAmount(15, 100) as JsonResult;
        }

        protected override object GetExpectedResponse()
        {
            return true;
        }
    }
}

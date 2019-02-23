using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuoteMe.MVC.Controllers;

namespace QuoteMe.Tests.Controllers.QuoteMeValidation.ValidateDepositAmount
{
    [TestClass]
    public class ValidateDepositAmount_More_Than_Vehicle_Price : QuoteMeValidationBase
    {
        protected override JsonResult ExecuteRemoteValidation(QuoteMeValidationController controller)
        {
            return controller.ValidateDepositAmount(150, 100) as JsonResult;
        }

        protected override object GetExpectedResponse()
        {
            return "Deposit cannot exceed the price of the vehicle.";
        }
    }
}

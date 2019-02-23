using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuoteMe.MVC.Controllers;

namespace QuoteMe.Tests.Controllers.QuoteMeValidation.ValidateVehiclePrice
{
    [TestClass]
    public class ValidateVehiclePrice_More_Than_Zero : QuoteMeValidationBase
    {
        protected override JsonResult ExecuteRemoteValidation(QuoteMeValidationController controller)
        {
            return controller.ValidateVehiclePrice(10) as JsonResult;
        }

        protected override object GetExpectedResponse()
        {
            return true;
        }
    }
}

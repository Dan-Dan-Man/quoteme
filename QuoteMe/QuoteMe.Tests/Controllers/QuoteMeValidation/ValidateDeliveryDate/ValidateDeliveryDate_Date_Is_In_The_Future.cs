using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuoteMe.MVC.Controllers;

namespace QuoteMe.Tests.Controllers.QuoteMeValidation.ValidateDeliveryDate
{
    [TestClass]
    public class ValidateDeliveryDate_Date_Is_In_The_Future : QuoteMeValidationBase
    {
        protected override JsonResult ExecuteRemoteValidation(QuoteMeValidationController controller)
        {
            return controller.ValidateDeliveryDate(DateTime.UtcNow.AddDays(1)) as JsonResult;
        }

        protected override object GetExpectedResponse()
        {
            return true;
        }
    }
}

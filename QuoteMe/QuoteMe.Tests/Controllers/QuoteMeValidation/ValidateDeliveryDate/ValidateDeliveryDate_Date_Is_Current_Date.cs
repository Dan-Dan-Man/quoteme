using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuoteMe.MVC.Controllers;

namespace QuoteMe.Tests.Controllers.QuoteMeValidation.ValidateDeliveryDate
{
    [TestClass]
    public class ValidateDeliveryDate_Date_Is_Current_Date : QuoteMeValidationBase
    {
        protected override JsonResult ExecuteRemoteValidation(QuoteMeValidationController controller)
        {
            return controller.ValidateDeliveryDate(DateTime.UtcNow) as JsonResult;
        }

        protected override object GetExpectedResponse()
        {
            return true;
        }
    }
}

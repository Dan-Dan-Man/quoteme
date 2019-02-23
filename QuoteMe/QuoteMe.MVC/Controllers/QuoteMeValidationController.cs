using System;
using System.Web.Mvc;

namespace QuoteMe.MVC.Controllers
{
    public class QuoteMeValidationController : Controller
    {
        public ActionResult ValidateVehiclePrice(decimal vehiclePrice)
        {
            return ValidateValueIsPositive(vehiclePrice, "Vehicle Price must not be negative.");
        }

        public ActionResult ValidateDepositAmount(decimal depositAmount, decimal vehiclePrice)
        {
            if (depositAmount < 0)
                return Json("Deposit Amount must not be negative.", JsonRequestBehavior.AllowGet);

            var minimumDeposit = vehiclePrice * (decimal) 0.15;
            if (depositAmount < minimumDeposit)
                return Json("Minimum deposit is 15% of the price of the vehicle.", JsonRequestBehavior.AllowGet);

            if (depositAmount > vehiclePrice)
                return Json("Deposit cannot exceed the price of the vehicle.", JsonRequestBehavior.AllowGet);

            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ValidateDeliveryDate(DateTime deliveryDate)
        {
            if (deliveryDate < DateTime.UtcNow.Date)
                return Json("Delivery Date cannot be in the past.", JsonRequestBehavior.AllowGet);

            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ValidateArrangementFee(decimal arrangementFee)
        {
            return ValidateValueIsPositive(arrangementFee, "Arrangement Fee must not be negative.");
        }

        public ActionResult ValidateCompletionFee(decimal completionFee)
        {
            return ValidateValueIsPositive(completionFee, "Completion Fee must not be negative.");
        }

        private ActionResult ValidateValueIsPositive(decimal value, string message)
        {
            if (value < 0)
                return Json(message, JsonRequestBehavior.AllowGet);

            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}
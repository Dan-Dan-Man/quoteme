using System;
using System.Web.Mvc;
using QuoteMe.Storage;

namespace QuoteMe.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWritableStorageService _storageService;

        public HomeController(IWritableStorageService storageService)
        {
            _storageService = storageService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ValidateDepositAmount(decimal depositAmount, decimal vehiclePrice)
        {
            var minimumDeposit = vehiclePrice * (decimal) 0.15;
            if (depositAmount < minimumDeposit)
                return Json("Minimum deposit is 15% the price of the vehicle.", JsonRequestBehavior.AllowGet);

            if (depositAmount > vehiclePrice)
                return Json("Deposit cannot exceed the prices of the vehicle.", JsonRequestBehavior.AllowGet);

            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ValidateDeliveryDate(DateTime deliveryDate)
        {
            if (deliveryDate < DateTime.UtcNow.AddDays(7))
                return Json("Delivery Date can be no earlier than one week after today's date", JsonRequestBehavior.AllowGet);

            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}
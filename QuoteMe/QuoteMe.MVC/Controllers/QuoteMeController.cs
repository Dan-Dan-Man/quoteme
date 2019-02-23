using System.Web.Mvc;
using QuoteMe.MVC.Models;
using QuoteMe.MVC.Services.FinancePlanCalculator;

namespace QuoteMe.MVC.Controllers
{
    public class QuoteMeController : Controller
    {
        private readonly IFinancePlanCalculator _financePlanCalculator;

        public QuoteMeController(IFinancePlanCalculator financePlanCalculator)
        {
            _financePlanCalculator = financePlanCalculator;
        }

        public ActionResult Index()
        {
            return View("Index");
        }

        public ActionResult QuoteForm()
        {
            return PartialView("QuoteForm", new Quote());
        }

        [HttpPost]
        public ActionResult QuoteSummary(Quote quote)
        {
            var monthlyRepayments = _financePlanCalculator.GenerateFinancePlanRepayments(quote);
            var financePlan = new FinancePlan(quote, monthlyRepayments);
            return View("FinancePlan", financePlan);
        }
    }
}
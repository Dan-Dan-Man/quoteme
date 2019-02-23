using System.Collections.Generic;
using QuoteMe.MVC.Models;
using MonthlyRepayment = QuoteMe.MVC.Models.FinancePlan.MonthlyRepayment;

namespace QuoteMe.MVC.Services.FinancePlanCalculator
{
    public interface IFinancePlanCalculator
    {
        List<MonthlyRepayment> GenerateFinancePlanRepayments(Quote quote);
    }
}
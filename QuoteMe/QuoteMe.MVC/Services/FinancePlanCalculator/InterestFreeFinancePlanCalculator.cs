using System;
using System.Collections.Generic;
using QuoteMe.MVC.Models;
using MonthlyRepayment = QuoteMe.MVC.Models.FinancePlan.MonthlyRepayment;

namespace QuoteMe.MVC.Services.FinancePlanCalculator
{
    public class InterestFreeFinancePlanCalculator : FinancePlanCalculator
    {
        public override List<MonthlyRepayment> GenerateFinancePlanRepayments(Quote quote)
        {
            int monthsToPay;
            decimal outstandingPayment;
            decimal amountDuePerMonth;
            GetRepaymentDetails(quote, out monthsToPay, out outstandingPayment, out amountDuePerMonth);

            var monthlyRepayments = new List<MonthlyRepayment>();
            DateTime nextPaymentDate = quote.DeliveryDate;

            for (int month = 0; month < monthsToPay; month++)
            {
                nextPaymentDate = GetNextPaymentDate(nextPaymentDate, DayOfWeek.Monday);
                var additionalCosts = GetAdditionalCosts(quote, month, monthsToPay);
                decimal moneyDueThisMonth = amountDuePerMonth + additionalCosts;
                outstandingPayment -= moneyDueThisMonth;

                var monthlyRepayment = new MonthlyRepayment(moneyDueThisMonth, outstandingPayment, nextPaymentDate);
                monthlyRepayments.Add(monthlyRepayment);
            }

            return monthlyRepayments;
        }
    }
}
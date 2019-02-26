using System;
using System.Collections.Generic;
using QuoteMe.MVC.Models;
using QuoteMe.MVC.Services.Extensions;
using MonthlyRepayment = QuoteMe.MVC.Models.FinancePlan.MonthlyRepayment;

namespace QuoteMe.MVC.Services.FinancePlanCalculator
{
    public abstract class FinancePlanCalculator : IFinancePlanCalculator
    {
        public abstract List<MonthlyRepayment> GenerateFinancePlanRepayments(Quote quote);

        protected virtual void GetRepaymentDetails(Quote quote, out int monthsToPay, out decimal outstandingPayment, out decimal amountDuePerMonth)
        {
            monthsToPay = quote.NumOfRepaymentYears * 12;
            outstandingPayment = quote.VehiclePrice - quote.DepositAmount;
            amountDuePerMonth = outstandingPayment / monthsToPay;
            outstandingPayment = outstandingPayment + quote.ArrangementFee + quote.CompletionFee;
        }

        protected virtual decimal GetAdditionalCostsForCurrentMonth(Quote quote, int currentMonth, int monthsToPay)
        {
            // First month
            if (currentMonth == 0)
                return quote.ArrangementFee;

            // Last month
            if (currentMonth == monthsToPay - 1)
                return quote.CompletionFee;

            return 0;
        }

        protected virtual DateTime GetNextPaymentDate(DateTime currentPaymentDate, DayOfWeek dayToBePaid)
        {
            DateTime lastDateOfCurrentMonth = currentPaymentDate.GetLastDateOfCurrentMonth();
            DateTime nextPaymentDate = lastDateOfCurrentMonth.GetNextOccurenceOfDay(dayToBePaid);

            return nextPaymentDate;
        }
    }
}
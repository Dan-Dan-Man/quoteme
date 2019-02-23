using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuoteMe.MVC.Models;

namespace QuoteMe.Tests.Controllers.QuoteMe.QuoteSummary
{
    [TestClass]
    public class QuoteSummary_Three_Repayment_Years : QuoteSummaryBase
    {
        private const decimal VehiclePrice = 10000;
        private const decimal DepositAmount = 3000;
        private readonly DateTime _deliveryDate = DateTime.UtcNow.AddDays(7);
        private const int RepaymentYears = 3;
        private const decimal ArrangementFee = 88;
        private const decimal CompletionFee = 20;

        protected override Quote GetQuote()
        {
            return new Quote
            {
                VehiclePrice = VehiclePrice,
                DepositAmount = DepositAmount,
                DeliveryDate = _deliveryDate,
                NumOfRepaymentYears = RepaymentYears,
                ArrangementFee = ArrangementFee,
                CompletionFee = CompletionFee
            };
        }
    }
}

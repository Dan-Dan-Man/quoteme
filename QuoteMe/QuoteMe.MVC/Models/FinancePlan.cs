using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using QuoteMe.MVC.Services.Extensions;

namespace QuoteMe.MVC.Models
{
    public class FinancePlan
    {
        public FinancePlan(Quote quote, List<MonthlyRepayment> monthlyRepayments)
        {
            Quote = quote;
            MonthlyRepayments = monthlyRepayments;
        }

        public Quote Quote { get; }

        public List<MonthlyRepayment> MonthlyRepayments { get; }

        [Display(Name = "Outstanding payment")]
        public decimal OutstandingPayment => Quote.VehiclePrice - Quote.DepositAmount;

        [Display(Name = "Outstanding payment (including excess fees)")]
        public decimal OutstandingPaymentWithFees => OutstandingPayment + Quote.ArrangementFee + Quote.CompletionFee;

        public string VehiclePriceFormatted => Quote.VehiclePrice.AsCurrency();
        public string DepositAmountFormatted => Quote.DepositAmount.AsCurrency();
        public string OutstandingPaymentFormatted => OutstandingPayment.AsCurrency();
        public string OutstandingPaymentWithFeesFormatted => OutstandingPaymentWithFees.AsCurrency();
        public string DeliveryDateFormatted => Quote.DeliveryDate.ToShortDateString();
        public string ArrangmentFeeFormatted => Quote.ArrangementFee.AsCurrency();
        public string CompletionFeeFormatted => Quote.CompletionFee.AsCurrency();

        public class MonthlyRepayment
        {
            public MonthlyRepayment(decimal amountDue, decimal amountOutstanding, DateTime dateDue)
            {
                AmountDue = amountDue;
                AmountOutstanding = amountOutstanding;
                DateDue = dateDue;
            }

            public decimal AmountDue { get; }
            public decimal AmountOutstanding { get; }
            public DateTime DateDue { get; }

            public string AmountDueFormatted => AmountDue.AsCurrency();
            public string AmountOutstandingFormatted => AmountOutstanding.AsCurrency();
            public string DateDueFormatted => DateDue.ToShortDateString();
        }
    }
}
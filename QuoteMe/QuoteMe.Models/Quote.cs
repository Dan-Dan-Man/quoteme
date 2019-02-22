using System;

namespace QuoteMe.Models
{
    public class Quote
    {
        public Quote(decimal vehiclePrice, decimal depositAmount, DateTime deliveryDate, int numOfRepaymentYears,
            decimal arrangementFee, decimal completionFee)
        {
            QuoteId = Guid.NewGuid();
            VehiclePrice = vehiclePrice;
            DepositAmount = depositAmount;
            DeliveryDate = deliveryDate;
            NumOfRepaymentYears = numOfRepaymentYears;
            ArrangementFee = arrangementFee;
            CompletionFee = completionFee;
            Timestamp = DateTime.UtcNow;
        }

        public Guid QuoteId { get; }
        public decimal VehiclePrice { get; }
        public decimal DepositAmount { get; }
        public DateTime DeliveryDate { get; }
        public int NumOfRepaymentYears { get; }
        public decimal ArrangementFee { get; set; }
        public decimal CompletionFee { get; set; }
        public DateTime Timestamp { get; }
    }
}

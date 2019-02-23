using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace QuoteMe.MVC.Models
{
    public class Quote
    {
        public Quote()
        {
            ArrangementFee = 88;
            CompletionFee = 20;
        }

        [Required]
        [DataType(DataType.Currency)]
        [Display(Name = "Vehicle Price")]
        [Remote("ValidateVehiclePrice", "QuoteMeValidation", "QuoteMe")]
        public decimal VehiclePrice { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Display(Name = "Deposit Amount")]
        [Remote("ValidateDepositAmount", "QuoteMeValidation", "QuoteMe", AdditionalFields = "VehiclePrice")]
        public decimal DepositAmount { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Delivery Date")]
        [Remote("ValidateDeliveryDate", "QuoteMeValidation", "QuoteMe")]
        public DateTime DeliveryDate { get; set; }

        [Required]
        [Display(Name = "Finance Option")]
        public int NumOfRepaymentYears { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Display(Name = "Arrangement Fee")]
        [Remote("ValidateArrangementFee", "QuoteMeValidation", "QuoteMe")]
        public decimal ArrangementFee { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Display(Name = "Completion Fee")]
        [Remote("ValidateCompletionFee", "QuoteMeValidation", "QuoteMe")]
        public decimal CompletionFee { get; set; }
    }
}
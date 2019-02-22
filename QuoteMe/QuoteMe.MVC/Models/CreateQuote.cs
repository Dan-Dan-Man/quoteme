using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace QuoteMe.MVC.Models
{
    public class CreateQuote
    {
        public CreateQuote()
        {
            ArrangementFee = 88;
            CompletionFee = 20;
        }

        [Required]
        [DataType(DataType.Currency)]
        [Display(Name = "Vehicle Price")]
        public decimal VehiclePrice { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Display(Name = "Deposit Amount")]
        [Remote("ValidateDepositAmount", "Home", AdditionalFields = "VehiclePrice")]
        public decimal DepositAmount { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Delivery Date")]
        [Remote("ValidateDeliveryDate", "Home")]
        public DateTime DeliveryDate { get; set; }

        [Required]
        [Display(Name = "Finance Option")]
        public int NumOfRepaymentYears { get; set; }

        [Required]
        [Display(Name = "Arrangement Fee")]
        public decimal ArrangementFee { get; set; }

        [Required]
        [Display(Name = "Completion Fee")]
        public decimal CompletionFee { get; set; }
    }
}
using System;
using System.ComponentModel.DataAnnotations;

namespace EventRegistrationWebsite.Models
{
    public class PaymentTransaction
    {
        [Key]
        public int PaymentTransactionId { get; set; }

        [Required]
        public int OrderDraftId { get; set; }

        [Required]
        public string UserId { get; set; } = "";

        public string PaymentMethod { get; set; } = ""; // Card, PayNow

        public string Status { get; set; } = "Pending"; // Pending, Success, Failed, Cancelled

        public string ReferenceCode { get; set; } = "";

        public decimal Amount { get; set; }

        public string Currency { get; set; } = "sgd";

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
    }
}

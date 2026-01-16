using System;
using System.ComponentModel.DataAnnotations;

namespace EventRegistrationWebsite.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        [Required]
        public string UserId { get; set; } = "";

        public int EventID { get; set; }

        public int TicketQuantity { get; set; }

        public int? SelectedPackageId { get; set; }

        public decimal Subtotal { get; set; }
        public decimal Discount { get; set; }
        public decimal FinalAmount { get; set; }

        public string Currency { get; set; } = "sgd";

        public string Status { get; set; } = "Paid"; // Paid, Refunded, Cancelled

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        public bool HasMysteryAddOn { get; set; } = false;

        public string? MysteryAddOnTitle { get; set; }
        public string? MysteryAddOnDescription { get; set; }
        public decimal? MysteryAddOnValue { get; set; }

    }
}

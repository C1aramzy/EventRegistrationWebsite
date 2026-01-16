using System;
using System.ComponentModel.DataAnnotations;

namespace EventRegistrationWebsite.Models
{
    public class OrderDraft
    {
        [Key]
        public int OrderDraftId { get; set; }

        [Required]
        public string UserId { get; set; } = "";

        public int EventID { get; set; }

        public int TicketQuantity { get; set; }

        public int? SelectedPackageId { get; set; }

        public string VoucherJson { get; set; } = "";

        public decimal Subtotal { get; set; }

        public decimal Discount { get; set; }

        public decimal FinalAmount { get; set; }

        public string Currency { get; set; } = "sgd";

        public string Status { get; set; } = "Pending"; // Pending, Paid, Cancelled

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
    }
}


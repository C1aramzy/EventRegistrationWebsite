using System;
using System.ComponentModel.DataAnnotations;

namespace EventRegistrationWebsite.Models
{
    public class RefundRequest
    {
        public int RefundRequestId { get; set; }

        public int TicketId { get; set; }

        [Required]
        public string UserId { get; set; } = "";

        [MaxLength(1000)]
        public string Reason { get; set; } = "";

        [Required]
        [MaxLength(20)]
        public string Status { get; set; } = RefundStatus.Pending;

        public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;

        public DateTime? ReviewedAtUtc { get; set; }

        public string? ReviewedByUserId { get; set; }

        [MaxLength(1000)]
        public string? AdminNote { get; set; }
    }

    public static class RefundStatus
    {
        public const string Pending = "Pending";
        public const string Approved = "Approved";
        public const string Rejected = "Rejected";
    }
}

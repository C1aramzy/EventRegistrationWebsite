using System;
using System.ComponentModel.DataAnnotations;

namespace EventRegistrationWebsite.Models
{
    public class EventSeat
    {
        [Key]
        public int EventSeatId { get; set; }

        public int EventID { get; set; }

        [Required]
        public string Section { get; set; } = "Main";

        [Required]
        public string RowLabel { get; set; } = "A";

        public int SeatNumber { get; set; }

        [Required]
        public string Status { get; set; } = "Available"; // Available, Held, Sold

        public string? HeldByUserId { get; set; }
        public DateTime? HeldUntilUtc { get; set; }

        public int? OrderId { get; set; }
    }
}

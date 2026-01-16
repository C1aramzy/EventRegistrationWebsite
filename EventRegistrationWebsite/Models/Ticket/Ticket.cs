using System;
using System.ComponentModel.DataAnnotations;

namespace EventRegistrationWebsite.Models.Ticket
{
    public class Ticket
    {
        [Key]
        public int TicketId { get; set; }

        [Required]
        public int OrderId { get; set; }

        [Required]
        public string UserId { get; set; } = "";

        public int EventID { get; set; }

        [Required]
        public string QRCodeValue { get; set; } = "";

        public string Status { get; set; } = "Active"; // Active, Used, Cancelled, Refunded

        public DateTime IssuedOn { get; set; } = DateTime.UtcNow;
    }
}

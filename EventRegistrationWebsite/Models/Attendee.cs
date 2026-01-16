using System.ComponentModel.DataAnnotations;

namespace EventRegistrationWebsite.Models
{
    public class Attendee
    {
        public int AttendeeID { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Phone]
        [StringLength(30)]
        public string? PhoneNumber { get; set; }

        [Required]
        public int EventID { get; set; }

        public Event? Event { get; set; }
    }
}

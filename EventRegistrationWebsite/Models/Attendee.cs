using System.ComponentModel.DataAnnotations;

namespace EventRegistrationWebsite.Models
{
    public class Attendee
    {
        public int AttendeeID { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string? PhoneNumber { get; set; }

        public int EventID { get; set; }
        public Event? Event { get; set; }
    }
}

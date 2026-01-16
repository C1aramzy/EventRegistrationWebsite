using System.ComponentModel.DataAnnotations;

namespace EventRegistrationWebsite.Models
{
    public class Waitlist
    {
        public int WaitlistID { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public int EventID { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}

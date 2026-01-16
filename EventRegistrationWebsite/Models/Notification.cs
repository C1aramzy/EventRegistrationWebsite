using System.ComponentModel.DataAnnotations;

namespace EventRegistrationWebsite.Models
{
    public class Notification
    {
        public int NotificationID { get; set; }

        public string Message { get; set; } = string.Empty;

        public DateTime DateCreated { get; set; } = DateTime.Now;
        public bool IsRead { get; set; } = false;

        public int EventID { get; set; }
    }
}

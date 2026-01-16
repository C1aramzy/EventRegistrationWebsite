using System.ComponentModel.DataAnnotations;

namespace EventRegistrationWebsite.Models
{
    public class Inquiry
    {
        public int InquiryID { get; set; }

        public string SenderName { get; set; } = string.Empty;

        public string SenderEmail { get; set; } = string.Empty;

        public string Subject { get; set; } = string.Empty;

        public string Message { get; set; } = string.Empty;

        public DateTime ReceivedDate { get; set; } = DateTime.Now;

        public string? ReplyMessage { get; set; }
    }
}


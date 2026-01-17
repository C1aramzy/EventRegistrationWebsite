using System.ComponentModel.DataAnnotations;

namespace EventRegistrationWebsite.Models
{
    public class Media
    {
        [Key]
        public int MediaID { get; set; }

        // Stores relative file path
        public string FilePath { get; set; } = string.Empty;

        public string? Description { get; set; }

        public DateTime UploadedDate { get; set; } = DateTime.Now;

        // Media belongs to an Event
        public int EventID { get; set; }
        public Event? Event { get; set; }
    }
}


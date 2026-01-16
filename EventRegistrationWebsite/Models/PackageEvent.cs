using System.ComponentModel.DataAnnotations;

namespace EventRegistrationWebsite.Models
{
    public class PackageEvent
    {
        [Key]
        public int PackageEventId { get; set; }

        public int PackageId { get; set; }
        public Package? Package { get; set; }

        public int EventID { get; set; }
        public Event? Event { get; set; }

        public int QuantityIncluded { get; set; } = 1;

        public bool IsOptional { get; set; } = false;
        public string? OptionalGroupKey { get; set; }
        public int SortOrder { get; set; } = 0;
    }
}

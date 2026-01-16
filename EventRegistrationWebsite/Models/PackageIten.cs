using System.ComponentModel.DataAnnotations;

namespace EventRegistrationWebsite.Models;

public class PackageItem
{
    [Key]
    public int PackageItemId { get; set; }

    public int PackageId { get; set; }
    public Package Package { get; set; } = default!;

    public int EventId { get; set; }
    public Event Event { get; set; } = default!;

    public int SortOrder { get; set; } = 0;
}

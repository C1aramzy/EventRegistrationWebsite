using System.ComponentModel.DataAnnotations;

namespace EventRegistrationWebsite.Models;

public class Package
{
    public int PackageID { get; set; }

    [Required]
    [StringLength(120)]
    public string PackageName { get; set; } = "";

    [StringLength(600)]
    public string? Description { get; set; }

    [Range(0, 999999)]
    public decimal Price { get; set; }

    public decimal? OriginalTotalPrice { get; set; }

    public int MaxPerUser { get; set; } = 0;

    public bool IsActive { get; set; } = true;

    public int? BundleEventID { get; set; }
    public Event? BundleEvent { get; set; }

    public DateTime CreatedOn { get; set; } = DateTime.Now;
    public DateTime LastUpdatedOn { get; set; } = DateTime.Now;
    public bool IsMysteryPack { get; set; } = false;

    public List<PackageEvent> PackageEvents { get; set; } = new();

    public string? CoverImagePath { get; set; }   // /uploads/packages/xxx.jpg
    public string? Badge { get; set; }            // "Most Popular", "Best Value", "VIP", "Mystery", null


    // IMPORTANT: required because your ApplicationDbContext maps WithMany(p => p.Items)
    public List<PackageItem> Items { get; set; } = new();
}

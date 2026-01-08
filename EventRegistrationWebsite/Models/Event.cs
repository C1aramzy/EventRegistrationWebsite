using System.ComponentModel.DataAnnotations;

namespace EventRegistrationWebsite.Models
{
    public class Event : IValidatableObject
    {
        [Key]
        public int EventID { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; } = string.Empty;

        [StringLength(500)]
        public string? Description { get; set; }

        [Required]
        public DateTime StartDate { get; set; } = DateTime.Today;

        [Required]
        public DateTime EndDate { get; set; } = DateTime.Today.AddDays(1);

        [Required]
        [StringLength(20)]
        public string Status { get; set; } = "Active"; // Draft, Active, Archived

        public DateTime LastUpdatedOn { get; set; } = DateTime.Now;

        [StringLength(200)]
        public string? VenueName { get; set; }

        [StringLength(300)]
        public string? VenueAddress { get; set; }

        [StringLength(100)]
        public string? City { get; set; }

        [StringLength(50)]
        public string? PostalCode { get; set; }

        public bool IsOnline { get; set; }

        [StringLength(200)]
        public string? OnlineEventUrl { get; set; }

        [Required]
        public DateTime RegistrationOpen { get; set; } = DateTime.Today;

        [Required]
        public DateTime RegistrationClose { get; set; } = DateTime.Today.AddDays(7);

        [StringLength(255)]
        public string? BannerImagePath { get; set; }

        public List<Package> Packages { get; set; } = new();

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (EndDate < StartDate)
            {
                yield return new ValidationResult(
                    "End Date must be later than or equal to Start Date.",
                    new[] { nameof(EndDate) }
                );
            }

            if (RegistrationClose < RegistrationOpen)
            {
                yield return new ValidationResult(
                    "Registration Close must be later than or equal to Registration Open.",
                    new[] { nameof(RegistrationClose) }
                );
            }

            if (!IsOnline)
            {
                if (string.IsNullOrWhiteSpace(VenueName) && string.IsNullOrWhiteSpace(VenueAddress))
                {
                    yield return new ValidationResult(
                        "For a physical event, please provide a venue name or venue address.",
                        new[] { nameof(VenueName), nameof(VenueAddress) }
                    );
                }
            }
            else
            {
                if (string.IsNullOrWhiteSpace(OnlineEventUrl))
                {
                    yield return new ValidationResult(
                        "For an online event, please provide an online event URL.",
                        new[] { nameof(OnlineEventUrl) }
                    );
                }
            }
        }
    }
}

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
        public string Status { get; set; } = "Active";

        public DateTime LastUpdatedOn { get; set; } = DateTime.Now;

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (EndDate < StartDate)
            {
                yield return new ValidationResult(
                    "End Date must be later than or equal to Start Date.",
                    new[] { nameof(EndDate) });
            }
        }
    }
}

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EventRegistrationWebsite.Models.Achievement
{
    public class Achievement
    {
        public int AchievementId { get; set; }

        [Required, MaxLength(60)]
        public string Code { get; set; } = "";

        [Required, MaxLength(120)]
        public string Name { get; set; } = "";

        [MaxLength(500)]
        public string Description { get; set; } = "";

        [MaxLength(300)]
        public string IconCss { get; set; } = "bi bi-trophy";

        public bool IsActive { get; set; } = true;

        public List<AchievementTier> Tiers { get; set; } = new();
    }
}

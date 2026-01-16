using System.ComponentModel.DataAnnotations;

namespace EventRegistrationWebsite.Models.Achievement
{
    public class AchievementTier
    {
        public int AchievementTierId { get; set; }

        public int AchievementId { get; set; }

        [Required, MaxLength(30)]
        public string TierName { get; set; } = "Bronze";

        public int PointsAwarded { get; set; } = 0;

        [Required, MaxLength(30)]
        public string ConditionType { get; set; } = "Count";

        public int ConditionValue { get; set; } = 1;

        public int SortOrder { get; set; } = 1;

        public bool IsActive { get; set; } = true;
    }
}

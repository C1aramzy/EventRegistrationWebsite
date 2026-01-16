using System;
using System.ComponentModel.DataAnnotations;

namespace EventRegistrationWebsite.Models.UserPoints
{
    public class UserTierUnlock
    {
        public int UserTierUnlockId { get; set; }

        [Required]
        public string UserId { get; set; } = "";

        public int AchievementTierId { get; set; }

        public int PointsSnapshot { get; set; }

        [MaxLength(30)]
        public string SourceType { get; set; } = "";

        public int? SourceId { get; set; }

        public DateTime UnlockedAtUtc { get; set; } = DateTime.UtcNow;

        public bool IsRevoked { get; set; } = false;

        public DateTime? RevokedAtUtc { get; set; }

        public string? RevokedByAdminId { get; set; }
    }
}

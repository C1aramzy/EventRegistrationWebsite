using System;
using System.ComponentModel.DataAnnotations;

namespace EventRegistrationWebsite.Models
{
    public class LevelReward
    {
        public int LevelRewardId { get; set; }

        public int LevelNumber { get; set; }

        public int VoucherDefinitionId { get; set; }

        public int Quantity { get; set; } = 1;

        public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;

        [MaxLength(200)]
        public string Note { get; set; } = "";
    }
}

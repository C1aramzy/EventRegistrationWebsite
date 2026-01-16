using System;
using System.ComponentModel.DataAnnotations;

namespace EventRegistrationWebsite.Models.UserPoints
{
    public class UserPoints
    {
        [Key]
        public string UserId { get; set; } = "";

        public int TotalPoints { get; set; } = 0;

        public int CurrentLevel { get; set; } = 1;

        public DateTime UpdatedAtUtc { get; set; } = DateTime.UtcNow;
    }
}

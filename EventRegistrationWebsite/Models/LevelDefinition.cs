using System.ComponentModel.DataAnnotations;

namespace EventRegistrationWebsite.Models
{
    public class LevelDefinition
    {
        public int LevelDefinitionId { get; set; }

        public int LevelNumber { get; set; } = 1;

        public int PointsRequired { get; set; } = 0;

        [MaxLength(60)]
        public string Name { get; set; } = "Level";
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventRegistrationWebsite.Models.Ticket
{
    public class TicketCategory
    {
        [Key]
        public int TicketCategoryId { get; set; }

        [Required]
        public int EventID { get; set; }
        public Event? Event { get; set; }

        [Required]
        [StringLength(60)]
        public string Name { get; set; } = string.Empty;

        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }

        public int Capacity { get; set; } = 0;

        public int SoldCount { get; set; } = 0;

        public bool IsActive { get; set; } = true;

        public int SortOrder { get; set; } = 0;

        [StringLength(300)]
        public string? Perks { get; set; }
    }
}

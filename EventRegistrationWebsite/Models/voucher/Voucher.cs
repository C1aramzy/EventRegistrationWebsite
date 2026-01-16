using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventRegistrationWebsite.Models.voucher
{
    public class Voucher
    {
        [Key]
        public int VoucherId { get; set; }

        [Required]
        [StringLength(40)]
        public string Code { get; set; } = string.Empty;

        [Required]
        [StringLength(80)]
        public string Title { get; set; } = string.Empty;

        [StringLength(300)]
        public string? Description { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime StartUtc { get; set; } = DateTime.UtcNow;
        public DateTime EndUtc { get; set; } = DateTime.UtcNow.AddDays(30);

        public decimal MinSpend { get; set; } = 0m;

        public decimal? PercentOff { get; set; }
        public decimal? AmountOff { get; set; }
        public decimal? MaxDiscountCap { get; set; }

        public int GlobalRedemptionsLimit { get; set; } = 0;
        public int GlobalRedemptionsUsed { get; set; } = 0;

        public int PerUserLimit { get; set; } = 1;
    }
}

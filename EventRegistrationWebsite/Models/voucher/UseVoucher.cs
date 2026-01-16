using EventRegistrationWebsite.Models.voucher;
using System.ComponentModel.DataAnnotations;

namespace EventRegistrationWebsite.Models
{
    public class UserVoucher
    {
        [Key]
        public int UserVoucherId { get; set; }

        [Required]
        public string UserId { get; set; } = string.Empty;

        [Required]
        public int VoucherId { get; set; }

        public Voucher? Voucher { get; set; }

        public DateTime AddedUtc { get; set; } = DateTime.UtcNow;

        public int RedeemedCount { get; set; } = 0;

        public bool IsDisabled { get; set; } = false;
    }
}

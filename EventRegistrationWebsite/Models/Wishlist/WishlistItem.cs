using System;
using System.ComponentModel.DataAnnotations;

namespace EventRegistrationWebsite.Models.Wishlist
{
    public class WishlistItem
    {
        [Key]
        public int WishlistItemId { get; set; }

        [Required]
        public string UserId { get; set; } = "";

        [Required]
        public int EventID { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        public Event? Event { get; set; }
    }
}

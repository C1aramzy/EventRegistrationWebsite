using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using EventRegistrationWebsite.Models;

namespace EventRegistrationWebsite.Data
{
    // Single database context for:
    // - Identity (users/roles)
    // - App data (events, packages, media, etc.)
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Event> Events { get; set; } = default!;
        public DbSet<Package> Packages { get; set; } = default!;

        public DbSet<Attendee> Attendees { get; set; } = default!;
        public DbSet<Inquiry> Inquiries { get; set; } = default!;
        public DbSet<Media> Media { get; set; } = default!;
        public DbSet<Notification> Notifications { get; set; } = default!;
        public DbSet<Waitlist> Waitlists { get; set; } = default!;
    }
}


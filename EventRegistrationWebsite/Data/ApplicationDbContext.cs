using EventRegistrationWebsite.Models;
using EventRegistrationWebsite.Models.Achievement;
using EventRegistrationWebsite.Models.Ticket;
using EventRegistrationWebsite.Models.UserPoints;
using EventRegistrationWebsite.Models.voucher;
using EventRegistrationWebsite.Models.Wishlist;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace EventRegistrationWebsite.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Event> Events { get; set; } = default!;
        public DbSet<Package> Packages { get; set; } = default!;
        public DbSet<PackageItem> PackageItems => Set<PackageItem>();
        public DbSet<OrderDraft> OrderDrafts => Set<OrderDraft>();
        public DbSet<PaymentTransaction> PaymentTransactions => Set<PaymentTransaction>();
        public DbSet<Order> Orders { get; set; } = default!;
        public DbSet<Ticket> Tickets { get; set; } = default!;
        public DbSet<EventSeat> EventSeats { get; set; } = default!;
        public DbSet<RefundRequest> RefundRequests => Set<RefundRequest>();

        public DbSet<Achievement> Achievements => Set<Achievement>();
        public DbSet<AchievementTier> AchievementTiers => Set<AchievementTier>();
        public DbSet<UserPoints> UserPoints => Set<UserPoints>();
        public DbSet<UserTierUnlock> UserTierUnlocks => Set<UserTierUnlock>();
        public DbSet<LevelDefinition> LevelDefinitions => Set<LevelDefinition>();
        public DbSet<LevelReward> LevelRewards => Set<LevelReward>();

        public DbSet<PackageEvent> PackageEvents => Set<PackageEvent>();

        public DbSet<Voucher> Vouchers => Set<Voucher>();
        public DbSet<UserVoucher> UserVouchers => Set<UserVoucher>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<PackageEvent>()
                .HasOne(x => x.Package)
                .WithMany(p => p.PackageEvents)
                .HasForeignKey(x => x.PackageId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<PackageItem>()
                .HasOne(x => x.Package)
                .WithMany(p => p.Items)
                .HasForeignKey(x => x.PackageId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<PackageItem>()
                .HasOne(x => x.Event)
                .WithMany()
                .HasForeignKey(x => x.EventId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<PackageItem>()
                .HasIndex(x => new { x.PackageId, x.EventId })
                .IsUnique();

            builder.Entity<UserVoucher>()
                .HasOne(uv => uv.Voucher)
                .WithMany()
                .HasForeignKey(uv => uv.VoucherId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Voucher>()
                .HasIndex(v => v.Code)
                .IsUnique();

            builder.Entity<UserVoucher>()
                .HasIndex(uv => new { uv.UserId, uv.VoucherId })
                .IsUnique();

        }

    }
}

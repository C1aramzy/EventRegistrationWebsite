using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using EventRegistrationWebsite.Models;
using EventRegistrationWebsite.Models.Achievement;

namespace EventRegistrationWebsite.Data
{
    public static class AchievementStudioSeed
    {
        public static async Task EnsureSeededAsync(IServiceProvider services)
        {
            using var scope = services.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            // Seed achievements if empty
            if (!await db.Achievements.AnyAsync())
            {
                var list = new List<Achievement>
                {
                    new() { Code="FIRST_TICKET", Name="First Ticket", Description="Purchase your first ticket.", IconCss="bi bi-ticket-perforated", IsActive=true },
                    new() { Code="TICKET_STACKER", Name="Ticket Stacker", Description="Buy multiple tickets over time.", IconCss="bi bi-stack", IsActive=true },
                    new() { Code="FIRST_WISHLIST", Name="First Wishlist", Description="Wishlist your first event.", IconCss="bi bi-heart", IsActive=true },
                    new() { Code="WISHLIST_FAN", Name="Wishlist Fan", Description="Build a wishlist collection.", IconCss="bi bi-hearts", IsActive=true },
                    new() { Code="FIRST_REFUND", Name="Refund Request", Description="Request your first refund.", IconCss="bi bi-arrow-counterclockwise", IsActive=true },
                    new() { Code="VOUCHER_COLLECTOR", Name="Voucher Collector", Description="Collect vouchers in your wallet.", IconCss="bi bi-wallet2", IsActive=true },
                    new() { Code="VOUCHER_USER", Name="Voucher User", Description="Use a voucher at checkout.", IconCss="bi bi-tags", IsActive=true },
                    new() { Code="EVENT_CREATOR", Name="Event Creator", Description="Create your first event.", IconCss="bi bi-calendar-plus", IsActive=true },
                    new() { Code="ORGANISER", Name="Organiser Life", Description="Manage events you created.", IconCss="bi bi-kanban", IsActive=true },
                    new() { Code="MYSTERY_PACK", Name="Mystery Resolved", Description="Complete a purchase with Mystery Pack.", IconCss="bi bi-box-seam", IsActive=true },
                    new() { Code="MINIGAME_WIN", Name="Lucky Winner", Description="Win a daily mini game voucher.", IconCss="bi bi-dice-5", IsActive=true },
                    new() { Code="LOYAL_CUSTOMER", Name="Loyal Customer", Description="Keep supporting events.", IconCss="bi bi-stars", IsActive=true },
                    new() { Code="EARLY_BIRD", Name="Early Bird", Description="Buy tickets early for an upcoming event.", IconCss="bi bi-alarm", IsActive=true },
                    new() { Code="CHECKOUT_MASTER", Name="Checkout Master", Description="Complete multiple successful checkouts.", IconCss="bi bi-bag-check", IsActive=true },
                    new() { Code="NO_SLEEP_ADMIN", Name="Behind The Scenes", Description="Admin tools accessed.", IconCss="bi bi-shield-lock", IsActive=true }
                };

                db.Achievements.AddRange(list);
                await db.SaveChangesAsync();

                // Add tiers for each achievement
                // Tier rules: Bronze, Silver, Gold with increasing condition values and points
                var tiers = new List<AchievementTier>();

                foreach (var a in list)
                {
                    // Default tiers for count based achievements
                    tiers.Add(new AchievementTier
                    {
                        AchievementId = a.AchievementId,
                        TierName = "Bronze",
                        PointsAwarded = 10,
                        ConditionType = "Count",
                        ConditionValue = 1,
                        SortOrder = 1,
                        IsActive = true
                    });

                    tiers.Add(new AchievementTier
                    {
                        AchievementId = a.AchievementId,
                        TierName = "Silver",
                        PointsAwarded = 25,
                        ConditionType = "Count",
                        ConditionValue = 5,
                        SortOrder = 2,
                        IsActive = true
                    });

                    tiers.Add(new AchievementTier
                    {
                        AchievementId = a.AchievementId,
                        TierName = "Gold",
                        PointsAwarded = 50,
                        ConditionType = "Count",
                        ConditionValue = 10,
                        SortOrder = 3,
                        IsActive = true
                    });
                }

                // Some should be single unlock only. We still keep tiers but set condition values small.
                // First Ticket, First Wishlist, First Refund, Event Creator, Mystery Pack
                await ForceSingleUnlockAsync(db, "FIRST_TICKET");
                await ForceSingleUnlockAsync(db, "FIRST_WISHLIST");
                await ForceSingleUnlockAsync(db, "FIRST_REFUND");
                await ForceSingleUnlockAsync(db, "EVENT_CREATOR");
                await ForceSingleUnlockAsync(db, "MYSTERY_PACK");

                db.AchievementTiers.AddRange(tiers);
                await db.SaveChangesAsync();
            }

            // Seed levels if empty
            if (!await db.LevelDefinitions.AnyAsync())
            {
                db.LevelDefinitions.AddRange(
                    new LevelDefinition { LevelNumber = 1, PointsRequired = 0, Name = "Rookie" },
                    new LevelDefinition { LevelNumber = 2, PointsRequired = 100, Name = "Regular" },
                    new LevelDefinition { LevelNumber = 3, PointsRequired = 250, Name = "Veteran" },
                    new LevelDefinition { LevelNumber = 4, PointsRequired = 450, Name = "Elite" },
                    new LevelDefinition { LevelNumber = 5, PointsRequired = 700, Name = "Legend" }
                );

                await db.SaveChangesAsync();
            }
        }

        private static async Task ForceSingleUnlockAsync(ApplicationDbContext db, string code)
        {
            var ach = await db.Achievements.FirstOrDefaultAsync(x => x.Code == code);
            if (ach == null) return;

            var tiers = await db.AchievementTiers.Where(t => t.AchievementId == ach.AchievementId).ToListAsync();
            foreach (var t in tiers)
            {
                t.ConditionValue = 1;
            }
        }
    }
}

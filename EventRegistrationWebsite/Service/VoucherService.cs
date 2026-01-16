using EventRegistrationWebsite.Data;
using EventRegistrationWebsite.Models;
using EventRegistrationWebsite.Models.voucher;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace EventRegistrationWebsite.Services
{
    public class VoucherService
    {
        private readonly ApplicationDbContext _db;

        public VoucherService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<bool> GrantToUserAsync(string userId, string voucherCode)
        {
            if (string.IsNullOrWhiteSpace(userId)) return false;
            if (string.IsNullOrWhiteSpace(voucherCode)) return false;

            var code = voucherCode.Trim().ToUpperInvariant();

            var v = await _db.Vouchers.FirstOrDefaultAsync(x => x.Code == code);

            // ADD ONLY: create voucher if it does not exist
            if (v == null)
            {
                v = new Voucher
                {
                    Code = code,
                    Title = "Mini game voucher",
                    Description = "Won from Daily Voucher Mini game",
                    IsActive = true,
                    StartUtc = DateTime.UtcNow.AddMinutes(-1),
                    EndUtc = DateTime.UtcNow.AddDays(7),
                    MinSpend = 0m,
                    AmountOff = 5m,
                    PercentOff = null,
                    MaxDiscountCap = null,
                    GlobalRedemptionsLimit = 0,
                    GlobalRedemptionsUsed = 0,
                    PerUserLimit = 1
                };

                _db.Vouchers.Add(v);
                await _db.SaveChangesAsync();
            }

            var uv = await _db.UserVouchers
                .FirstOrDefaultAsync(x => x.UserId == userId && x.VoucherId == v.VoucherId);

            if (uv == null)
            {
                uv = new UserVoucher
                {
                    UserId = userId,
                    VoucherId = v.VoucherId,
                    RedeemedCount = 0,
                    IsDisabled = false,
                    AddedUtc = DateTime.UtcNow
                };

                _db.UserVouchers.Add(uv);
                await _db.SaveChangesAsync();
                return true;
            }

            if (uv.IsDisabled) return false;

            return true;
        }
    }
}

using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using EventRegistrationWebsite.Data;

namespace EventRegistrationWebsite.Models.Wishlist
{
    public class WishlistState
    {
        private readonly ApplicationDbContext _db;
        private readonly AuthenticationStateProvider _auth;

        public int Count { get; private set; }
        public event Action? OnChange;

        public WishlistState(ApplicationDbContext db, AuthenticationStateProvider auth)
        {
            _db = db;
            _auth = auth;
        }

        public async Task RefreshAsync()
        {
            var auth = await _auth.GetAuthenticationStateAsync();
            var userId = auth.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrWhiteSpace(userId))
            {
                Count = 0;
                OnChange?.Invoke();
                return;
            }

        }
    }
}

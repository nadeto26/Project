using WineSite.Core.Contracts;
using WineSite.Data;
using WineSite.Data.Data;

namespace WineSite.Core.Services
{
    public class ApplicationUserService : IApplicationUserService
    {
        private readonly WineShopDbContext context;
        public ApplicationUserService(WineShopDbContext _context)
        {
            context = _context;
        }

        public async Task<string> UserFullName(string userId)
        {
             var user = await context.Users.FindAsync(userId);

            if (string.IsNullOrEmpty(user.FirstName)
                || string.IsNullOrEmpty(user.LastName))
            {
                return null;
            }

            return user.FirstName + " " + user.LastName;
              
        }
    }
}

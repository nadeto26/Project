using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WineSite.Core.Contracts;
using WineSite.Core.Models.Admin;
using WineSite.Data.Data;
using WineSite.Data.Data.Models;

namespace WineSite.Core.Services
{
    public class UserService : IUserServices
    {
        private readonly WineShopDbContext _context;
        
        public UserService(WineShopDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<UserServiceModel>> All()
        {
            

            return  await _context.Users
                .Select(u=> new UserServiceModel()
                {
                    Email = u.Email,
                    FullName = $"{u.FirstName} {u.LastName}"
                }).ToListAsync();
                 
               
        }

        public async Task<string> UserFullName(string userId)
        {
            string result = string.Empty;
            var user = await _context.Set<ApplicationUser>().FindAsync(userId);
            if (user != null)
            {
                return $"{user.FirstName} {user.LastName}";
            }
            return result ; 
        }
    }
}

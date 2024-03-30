using System.Security.Claims;
using WineSite.Contracts;
using WineSite.Data;
using WineSite.Services.Wine.Models;
using Microsoft.AspNetCore.Identity;

namespace WineSite.Services
{
    public class VinarServices : IVinarServices
    {
        private readonly WineShopDbContext _db;

        public VinarServices(WineShopDbContext db)
        {
            _db = db;
        }
        public async Task<int> GetVinarId(string userId)
        {
            return _db.Vinar.FirstOrDefault(a => a.UserId == userId).Id;
        }

         
    }
}

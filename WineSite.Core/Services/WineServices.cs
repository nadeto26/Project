using WineSite.Core.Infrastructure;
using WineSite.Core.Models.Wine;
using WineSite.Data.Data;
using WineSite.Data.Data.Models;
using Microsoft.EntityFrameworkCore;
using WineSite.Core.Contracts;

namespace WineSite.Core.Services
{
    public class WineServices : IWineServices
    {
        private readonly WineShopDbContext _db;
        
        public WineServices(WineShopDbContext db)
        {
            _db = db;
        }

        public WineQueryServicesModel All(string type = null, string searchItem = null, WineSorting sorting = WineSorting.HighestPrice, int currentPage = 1, int wineperPage = 1)
        {
            var winesQuery = _db.Wines.AsQueryable();

            if(!string.IsNullOrEmpty(type))
            {
                winesQuery = _db.Wines
                    .Where(t => t.Type.Name == type);
            }

            if(!string.IsNullOrEmpty(searchItem))
            {
                winesQuery = winesQuery
                    .Where(w=> 
                    w.Name.ToLower().Contains(searchItem.ToLower())
                    || w.Description.ToLower().Contains(searchItem.ToLower())
                    || w.Country.ToLower().Contains(searchItem.ToLower()));
            }

            winesQuery = sorting switch
            {
                WineSorting.LowestPrice => winesQuery.OrderByDescending(f => f.Price),
                WineSorting.HighestPrice => winesQuery.OrderBy(f => f.Price),
            };

            var wines = winesQuery
                .Skip((currentPage - 1) * wineperPage)
                .Take(wineperPage)
                .Select(w => new WineServicesModel
                {
                    Id = w.Id,
                    Name = w.Name,
                    ImageUrl = w.ImageUrl,
                    Price = w.Price,
                    Year = w.Year,

                }).ToList();

            var totalWines = winesQuery.Count();

            return new WineQueryServicesModel()
            {
                TotalWinesCount = totalWines,
                Wines = wines
            };
               
        }
        public async Task<IEnumerable<WineTypeServicesModel>> AllTypes()
        {
            return await _db
                .Types.Select(w => new WineTypeServicesModel
                {
                    Name = w.Name,
                    Id = w.Id,
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<string>> AllTypesName()
        {
             return await _db.Types
                .Select(t=>t.Name)
                .Distinct()
                .ToListAsync();
        }

         

        public async Task Edit(int wineId, string name, int typeId, int year, string imageUrl, string description, 
            string country, string manufucturer, decimal price, string sort, int harvest, int alcoholcontent, int bottle, string importer)
        {
             var wine = _db.Wines.Find(wineId);

             
             wine.Name = name;
             wine.TypeId = typeId;
             wine.Year = year;
             wine.ImageUrl = imageUrl;
             wine.Description = description;
             wine.Country = country;
             wine.Manufucturer = manufucturer;
             wine.Price = price;
             wine.Sort = sort;
             wine.Harvest = harvest;
             wine.Bottle = bottle;
             wine.AlcoholContent = alcoholcontent;
             wine.Importer = importer;

            await _db.SaveChangesAsync();

        }

        public async Task<bool> Exist(int id)
        {
            return await _db.Wines.AnyAsync(wine => wine.Id == id);
        }

        public async Task<bool> TypeExist(int typeId)
        {
           return await _db.Types.AnyAsync(c=>c.Id == typeId);
        }

        public async Task<WineDetailsSevicesModel> WineDetailsById(int id)
        {
            return await _db.Wines
               .Where(w => w.Id == id)
               .Select(w => new WineDetailsSevicesModel()
               {
                   Id = w.Id,
                   Name = w.Name,
                   Type = w.Type.Name,
                   Description = w.Description,
                   Country = w.Country,
                   Manufucturer = w.Manufucturer,
                   Year = w.Year,
                   Harvest = w.Harvest,
                   Bottle = w.Bottle,
                   AlcoholContent = w.AlcoholContent,
                   ImageUrl = w.ImageUrl,
                   Importer = w.Importer,
                   Price = w.Price

               }).FirstOrDefaultAsync();
                
        }

        public async Task<int> GetWineTypeId(int wineId)
        {
            var wine = await _db.Wines.FindAsync(wineId);
            if (wine != null)
            {
                return wine.TypeId;
            }
            return -1;  
        }

        public async Task<bool> DeleteWineAsync(int id)
        {
            var wineToDelete = await _db.Wines.FindAsync(id);
            if (wineToDelete == null)
            {
                return false; // Връщаме false, ако събитието не е намерено
            }

            _db.Wines.Remove(wineToDelete);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AddWineToCartAsync(int wineId, string userId)
        {
            var adToAdd = await _db.Wines.FindAsync(wineId);

            if (adToAdd == null)
            {
                return false;  
            }

            var entry = new WineBuyers()
            {
                BuyerId = userId,
                WineId = adToAdd.Id
            };

            _db.WineBuyers.Add(entry);
            await _db.SaveChangesAsync();

            return true;
        }

        public async Task<List<WineCart>> GetUserWineAsync(string userId)
        {
            var userBuyer = await _db.WineBuyers
               .Where(ab => ab.BuyerId == userId /*&& ab.IsPurchased*/) // Само закупените билети
               .Select(ab => new WineCart()
               {
                   Id = ab.Wine.Id,
                   Name = ab.Wine.Name,
                   Price = ab.Wine.Price,
                   ImageUrl = ab.Wine.ImageUrl,

               })
               .ToListAsync();

            return userBuyer;

           
        }

        public async Task<bool> RemoveWineFromCartAsync(int wineId, string userId)
        {
            var entryToRemove = await _db.WineBuyers.FirstOrDefaultAsync(e => e.WineId == wineId && e.BuyerId == userId);

            if (entryToRemove == null)
            {
                return false; // Върнете подходящ резултат или хвърлете изключение
            }

            _db.WineBuyers.Remove(entryToRemove);
            await _db.SaveChangesAsync();

            return true;
        }

        public async Task ConfirmOrderAsync(string currentUserId)
        {
            var user = await _db.Users.FirstOrDefaultAsync(u => u.Id == currentUserId);

            if (user == null)
            {
                throw new Exception("User not found");
            }

            var deliveryDetails = await _db.WineDeliveries.FirstOrDefaultAsync(dd => dd.Email == user.Email);
            if (deliveryDetails == null)
            {
                throw new Exception("Delivery details not found");
            }

            var cartEvents = await _db.WineBuyers
                .Include(eb => eb.Wine)
                .Where(eb => eb.BuyerId == currentUserId)
                .ToListAsync();

            foreach (var wineBuyer in cartEvents)
            {
                var order = new OrderWines
                {
                    FullName = deliveryDetails.FullName,
                    Address = deliveryDetails.Address,
                    City = deliveryDetails.City,
                    Email = deliveryDetails.Email,
                    PostCode = deliveryDetails.PostCode,
                    Phonenumber = deliveryDetails.PhoneNumber,
                    WineId = wineBuyer.WineId,
                    WineName = wineBuyer.Wine.Name,
                    BuyerId = wineBuyer.BuyerId,
                    QuentityWine = wineBuyer.Quantity 
                };

                _db.OrderWines.Add(order);


            }

            _db.WineBuyers.RemoveRange(cartEvents);

            await _db.SaveChangesAsync();
        }

        public async Task WineDeliveryAsync(WineDeliveryDetailsViewModel deliveryDetails)
        {
            var adDelivery = new WineDelivery()
            {
                FullName = deliveryDetails.FullName,
                Address = deliveryDetails.Address,
                City = deliveryDetails.City,
                PostCode = deliveryDetails.PostalCode,
                PhoneNumber = deliveryDetails.PhoneNumber,
                Email = deliveryDetails.Email
            };

            await _db.WineDeliveries.AddAsync(adDelivery);
            await _db.SaveChangesAsync();
        }


    }
}

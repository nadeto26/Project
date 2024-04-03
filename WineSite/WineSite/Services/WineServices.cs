using EventsWebsite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WineSite.Contracts;
using WineSite.Data;
using WineSite.Data.Migrations;
using WineSite.Data.Models;
using WineSite.Infrastructure;
using WineSite.Models.Wine;
using WineSite.Services.Wine.Models;
using WineBuyer = WineSite.Data.Models.WineBuyer;

namespace WineSite.Services
{
    public class WineServices : IWineServices
    {
        private readonly WineShopDbContext _db;

        public WineServices(WineShopDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<WineTypeServicesModel>> AllTypes()
        {
            return await _db
                .Wines.Select(w => new WineTypeServicesModel
                {
                    TypeName = w.Type.Name,
                    Id = w.Id,
                }).ToListAsync();
        }

        public async Task<bool> TypeExist(int typeId)
        {
            return await _db.Types.AnyAsync(c => c.Id == typeId);
        }

        public async Task<int> Create(string name, int typeId, int year, string imageUrl, string description, string country,
           string manufucturer, decimal price, string sort, int harvest, int alcoholcontent, int bottle, string importer, int quantity)
        {
            var wine = new WineSite.Data.Models.Wine()
            {
                Name = name,
                TypeId = typeId,
                Year = year,
                ImageUrl = imageUrl,
                Description = description,
                Country = country,
                Manufucturer = manufucturer,
                Price = price,
                Sort = sort,
                Harvest = harvest,
                Bottle = bottle,
                AlcoholContent = alcoholcontent,
                Importer = importer,
                Quantity = quantity
            };

            await _db.Wines.AddAsync(wine);
            await _db.SaveChangesAsync();

            return wine.Id;
        }



        public async Task AddToCart(string userId, WineViewModel model)
        {
            bool isAlreadyAdd = await _db.WineBuyers
                .AnyAsync(e => e.BuyerId == userId && e.WineId == model.Id);

            if (!isAlreadyAdd)
            {
                var wine = new WineBuyer()
                {
                    BuyerId = userId,
                    WineId = model.Id,
                    Quantity = 1

                };


                await _db.WineBuyers.AddAsync(wine);
                await _db.SaveChangesAsync();
            }

        }

        public WineQueryServicesModel All(string type = null, string searchItem = null, WineSorting sorting = WineSorting.Newest, int currentPage = 1, int wineperPage = 1)
        {
            var winesQuery = _db.Wines.AsQueryable();

            if (!string.IsNullOrEmpty(type))
            {
                winesQuery = _db.Wines
                    .Where(t => t.Type.Name == type);
            }

            if (!string.IsNullOrEmpty(searchItem))
            {
                winesQuery = winesQuery
                    .Where(w =>
                    w.Name.ToLower().Contains(searchItem.ToLower())
                    || w.Description.ToLower().Contains(searchItem.ToLower())
                    || w.Country.ToLower().Contains(searchItem.ToLower()));
            }

            winesQuery = sorting switch
            {
                WineSorting.Price => winesQuery
                .OrderBy(t => t.Price),
                WineSorting.Newest => winesQuery
                .OrderBy(w => w.Name)
                .ThenByDescending(w => w.Id),
                _ => winesQuery.OrderByDescending(w => w.Id)
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



        public async Task<IEnumerable<string>> AllTypesName()
        {
            return await _db.Types
               .Select(t => t.Name)
               .Distinct()
               .ToListAsync();
        }


        public async Task Edit(int wineId, string name, int typeId, int year, string imageUrl, string description,
            string country, string manufucturer, decimal price, string sort, int harvest, int alcoholcontent, int bottle)
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
            wine.Harvest = harvest;
            wine.AlcoholContent = alcoholcontent;
            wine.Bottle = bottle;

            await _db.SaveChangesAsync();

        }

        public async Task<bool> Exist(int id)
        {
            return await _db.Wines.AnyAsync(wine => wine.Id == id);
        }

        public async Task<IEnumerable<WineCart>> GetWinesAsync(string userId)
        {
            return await _db.WineBuyers
              .AsNoTracking()
              .Where(iub => iub.BuyerId == userId)
              .Select(iub => new WineCart()
              {
                  Id = iub.Wine.Id,
                  Name = iub.Wine.Name,
                  ImageUrl = iub.Wine.ImageUrl,
                  Price = iub.Wine.Price,
                  Quenitity = iub.Wine.Quantity
              })
              .ToListAsync();
        }

        public async Task<WineViewModel?> GetWineByIdAsync(int id)
        {
            return await _db.Wines
               .AsNoTracking()
               .Where(b => b.Id == id)
               .Select(b => new WineViewModel()
               {
                   Id = b.Id,
                   Name = b.Name,
                   AlcoholContent = b.AlcoholContent,
                   Bottle = b.Bottle,
                   Harvest = b.Harvest,
                   TypeId = b.TypeId,
                   Description = b.Description,
                   Country = b.Country,
                   Manufucturer = b.Manufucturer,
                   ImageUrl = b.ImageUrl,
                   Importer = b.Importer,
                   Sort = b.Sort,
                   Price = b.Price,
                   Year = b.Year,
               })
               .FirstOrDefaultAsync();
        }



        public async Task<WineDetailsSevicesModel?> WineDetailsById(int id)
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

        public async Task RemoveWineFromCartAsync(string userId, WineViewModel model)
        {
            var wine = new WineBuyer()
            {
                BuyerId = userId,
                WineId = model.Id
            };

            _db.WineBuyers.Remove(wine);
            await _db.SaveChangesAsync();
        }

        public async Task<int> GetWineTypeId(int wineId)
        {
            var wine = await _db.Wines.FindAsync(wineId);
            if (wine != null)
            {
                return wine.TypeId;
            }
            // Връщаме -1 като стойност по подразбиране за случай, че не намерим вино с даденото ID
            return -1;
        }

        public async Task Delete(int wineId)
        {
            var wine = await _db.Wines.FindAsync(wineId);
            _db.Remove(wine);
            await _db.SaveChangesAsync();
        }

        public async Task AddDeliveryDetails(DeliveryDetailsViewModel admode)
        {
            var adDelivery = new OrderWine
            {
                FullName = admode.FullName,
                Address = admode.Address,
                City = admode.City,
                PostCode = admode.PostalCode,
                Email = admode.Email,
                Phonenumber = admode.PhoneNumber
            };

            await _db.OrderWines.AddAsync(adDelivery);
            await _db.SaveChangesAsync();
        }

        public async Task ConfirmOrder(string userId)
        {
            var user = await _db.Users.FirstOrDefaultAsync(u => u.Id == userId);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            var deliveryDetails = await _db.WineDeliveries.FirstOrDefaultAsync(dd => dd.Email == user.Email);
            if (deliveryDetails == null)
            {
                throw new Exception("Delivery details not found");
            }

            var cartWines = await _db.WineBuyers
                .Include(eb => eb.Wine)
                .Where(eb => eb.BuyerId == userId)
                .ToListAsync();

            foreach (var wineBuyer in cartWines)
            {
                var order = new OrderWine
                {
                    FullName = deliveryDetails.FullName,
                    Address = deliveryDetails.Address,
                    Email = deliveryDetails.Email,
                    City = deliveryDetails.City,
                    PostCode = deliveryDetails.PostCode,
                    Phonenumber = deliveryDetails.PhoneNumber,
                    BuyerId = userId,
                    WineId = wineBuyer.Wine.Id,
                    WineName = wineBuyer.Wine.Name,
                    QuentityWine = 1
                };

                _db.OrderWines.Add(order);
            }

            _db.WineBuyers.RemoveRange(cartWines);

            await _db.SaveChangesAsync();
        }

        
    }
}

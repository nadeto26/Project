 
using WineSite.Core.Contracts;
using WineSite.Data;
 
 
using Events = WineSite.Data.Data.Models.Events;
 
using WineSite.Core.Models.Receipt;
using WineSite.Data.Data;
using WineSite.Core.Models.Event;
using WineSite.Data.Data.Models;
using WineSite.Core.Models.Wine;
using WineSite.Core.Models.Admin;
using Microsoft.EntityFrameworkCore;
using WineSite.Core.Models.Contact;

namespace WineSite.Core.Services
{
    public class AdminServices : IAdminServices
    {
        private readonly WineShopDbContext _context;
        public AdminServices(WineShopDbContext context)
        {
            _context = context;
        }

        //Добаняте та събития
        public async Task AddEventAsync(EventsViewModel model)
        {
            var adEvent = new Events()
            {
                Name = model.Name,
                HostName = model.HostName,
                Address = model.Address,
                DateTime = model.DateTime,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                PriceTicket = model.PriceTicket,
                WineList = model.WineList,
                Features = model.Features,
                Preferences = model.Preferences,
                MoreInformation = model.MoreInformation,
                Duration = model.Duration,
            };

            _context.Events.Add(adEvent);
            await _context.SaveChangesAsync();
        }

        //Добавяне на рецепти 
        public async Task AddRecipeAsync(ReceiptViewModel model)
        {
            var adModel = new Recipe()
            {
                Name = model.Name,
                Notes = model.Notes,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
            };

            await _context.Recipes.AddAsync(adModel);
            await _context.SaveChangesAsync();
        }

        //Добавяне на вино

        public async Task<int> Create(string name, int typeId, int year, string imageUrl, string description, string country,
            string manufucturer, decimal price, string sort, int harvest, int alcoholcontent, int bottle, string importer)
        {
            var wine = new WineSite.Data.Data.Models.Wine()
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
                Importer = importer
            };

            await _context.Wines.AddRangeAsync(wine);
            await _context.SaveChangesAsync();

            return wine.Id;
        }

        public async Task<IEnumerable<WineTypeServicesModel>> AllTypes()
        {
            return await _context
                .Types.Select(w => new WineTypeServicesModel
                {
                    Name = w.Name,
                    Id = w.Id,
                })
                .ToListAsync();
        }

        public async Task<bool> TypeExist(int typeId)
        {
           return await _context.Types.AnyAsync(c => c.Id == typeId);
        }

        public async Task<List<OrderViewModel>> GetOrdersForTicketsAsync()
        {
            return await _context.Orders
           .Select(d => new OrderViewModel
           {
               Id = d.Id,
               FullName = d.FullName,
               PostCode = d.PostCode,
               Address = d.Address,
               City = d.City,
               QuentityEvent = d.QuentityEvent,
               EventName = d.EventName,
               Phonenumber = d.Phonenumber
           })
           .ToListAsync();
        }

        
        public async Task<bool> DeleteTicketOrderAsync(int id)
        {
            var order = await _context.TicketDeliveries.FirstOrDefaultAsync(o => o.Id == id);
            if (order == null)
            {
                return false; // Или може да хвърлите изключение, в зависимост от изискванията на вашето приложение.
            }

            _context.TicketDeliveries.Remove(order);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<WineOrderViewModel>> GetWinesOrdersAsync()
        {
            return await _context.OrderWines
           .Select(d => new WineOrderViewModel 
           {
               Id = d.Id,
               FullName = d.FullName,
               PostCode = d.PostCode,
               Address = d.Address,
               City = d.City,
               QuentityWine = d.QuentityWine,
               WineName = d.WineName,
               Phonenumber = d.Phonenumber
           })
           .ToListAsync();
        }

        public async Task<bool> DeleteWineOrderAsync(int id)
        {
            var order = await _context.WineDeliveries.FirstOrDefaultAsync(o => o.Id == id);
            if (order == null)
            {
                return false; // Или може да хвърлите изключение, в зависимост от изискванията на вашето приложение.
            }

            _context.WineDeliveries.Remove(order);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<AddMessage>> GetAllMessagesAsync()
        {
            var messages = await _context.Messages
           .Select(d => new AddMessage
           {
               Id = d.Id,
               Name = d.Name,
               Message = d.Message,
               About = d.About,
               Email = d.Email,
               PhoneNumber = d.PhoneNumber
           })
           .ToListAsync();

            return messages;
        }

        public async Task DeleteMessageAsync(int id)
        {
            var message = await _context.Messages.FirstOrDefaultAsync(o => o.Id == id);
            if (message != null)
            {
                _context.Messages.Remove(message);
                await _context.SaveChangesAsync();
            }
        }
    }
}


using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Xml.Linq;
using WineSite.Core.Contracts;
using WineSite.Core.Models.Event;
using WineSite.Data;
using WineSite.Data.Data;
using WineSite.Data.Data.Models;

namespace WineSite.Core.Services
{
    public class EventServices : IEventServices
    {
        private readonly WineShopDbContext _context;
        public EventServices(WineShopDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddEventToCartAsync(int eventId, string userId)
        {
            var adToAdd = await _context.Events.FindAsync(eventId);

            if (adToAdd == null)
            {
                return false;  
            }

            var entry = new TicketBuyer()
            {
                BuyerId = userId,
                EventId = adToAdd.Id
            };

            _context.TicketBuyers.Add(entry);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task AddTicketDeliveryAsync(DeliveryDetailsViewModel deliveryDetails)
        {
            var adDelivery = new TicketDelivery()
            {
                FullName = deliveryDetails.FullName,
                Address = deliveryDetails.Address,
                City = deliveryDetails.City,
                PostCode = deliveryDetails.PostalCode,
                PhoneNumber = deliveryDetails.PhoneNumber,
                Email = deliveryDetails.Email
            };

            await _context.TicketDeliveries.AddAsync(adDelivery);
            await _context.SaveChangesAsync();
        }

        public async Task ConfirmOrderAsync(string currentUserId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == currentUserId);

            if (user == null)
            {
                throw new Exception("User not found");
            }

            var deliveryDetails = await _context.TicketDeliveries.FirstOrDefaultAsync(dd => dd.Email == user.Email);
            if (deliveryDetails == null)
            {
                throw new Exception("Delivery details not found");
            }

            var cartEvents = await _context.TicketBuyers
                .Include(eb => eb.Events)
                .Where(eb => eb.BuyerId == currentUserId)
                .ToListAsync();

            foreach (var eventBuyer in cartEvents)
            {
                var order = new Orders
                {
                    FullName = deliveryDetails.FullName,
                    Address = deliveryDetails.Address,
                    City = deliveryDetails.City,
                    Email = deliveryDetails.Email,
                    PostCode = deliveryDetails.PostCode,
                    Phonenumber = deliveryDetails.PhoneNumber,
                    EventId = eventBuyer.EventId,
                    EventName = eventBuyer.Events.Name,
                    BuyerId = eventBuyer.BuyerId,
                    QuentityEvent = eventBuyer.Quantity // Set the default quantity here, or adjust as needed
                };

                _context.Orders.Add(order);

                
            }

            _context.TicketBuyers.RemoveRange(cartEvents);

            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistAsync(int id)
        {
            return await _context.Events.AnyAsync(e => e.Id == id);
        }

        public async Task<List<EventsViewModel>> GetAllEventsAsync()
        {
            var eventsToDisplay = await _context.Events
           .Select(e => new EventsViewModel
           {
               Id = e.Id,
               Name = e.Name,
               Address = e.Address,
               HostName = e.HostName,
               DateTime = e.DateTime,
               Description = e.Description,
               ImageUrl = e.ImageUrl,
               PriceTicket = e.PriceTicket,
               WineList = e.WineList,
               Features = e.Features,
               Preferences = e.Preferences,
               MoreInformation = e.MoreInformation,
               Duration = e.Duration
           })
           .ToListAsync();

            return eventsToDisplay;
        }

        public async Task<EventsViewModel> GetEventAsync(int id)
        {
            var eventToEdit = await _context.Events.FindAsync(id);

            if (eventToEdit == null)
            {
                throw new ArgumentException("Event not found");
            }

            return new EventsViewModel()
            {
                Name = eventToEdit.Name,
                DateTime = eventToEdit.DateTime,
                Preferences = eventToEdit.Preferences,
                Features = eventToEdit.Features,
                Description = eventToEdit.Description,
                PriceTicket = eventToEdit.PriceTicket,
                WineList = eventToEdit.WineList,
                Address = eventToEdit.Address,
                HostName = eventToEdit.HostName,
                Duration = eventToEdit.Duration,
                ImageUrl = eventToEdit.ImageUrl,
                MoreInformation = eventToEdit.MoreInformation,
            };

        }

        public async Task<EventsViewModel?> GetEventDetailsByIdAsync(int id)
        {
            return await _context.Events
           .Where(e => e.Id == id)
           .Select(e => new EventsViewModel
           {
               Id = e.Id,
               Name = e.Name,
               HostName = e.HostName,
               Address = e.Address,
               DateTime = e.DateTime,
               Description = e.Description,
               Duration = e.Duration,
               Features = e.Features,
               ImageUrl = e.ImageUrl,
               MoreInformation = e.MoreInformation,
               WineList = e.WineList,
               Preferences = e.Preferences,
               PriceTicket = e.PriceTicket
           })
           .FirstOrDefaultAsync();
        }

        public async Task<int> GetEventTicketBuyersCountAsync(int id)
        {
            return await Task.FromResult(0);
        }

        public async Task<List<AddToCartViewModel>> GetUserTicketsAsync(string userId)
        {
            var userTickets = await _context.TicketBuyers
                .Where(ab => ab.BuyerId == userId ) 
                .Select(ab => new AddToCartViewModel()
                {
                    Id = ab.Events.Id,
                    TicketName = ab.Events.Name,
                    PricePerTicket = ab.Events.PriceTicket,
                    ImageUrl = ab.Events.ImageUrl,
                    Quentity = ab.Quantity
                })
                .ToListAsync();

            return userTickets;
        }

        public async Task<bool> IncreaseQuantityAsync(int eventId, string userId)
        {
            var cartItem = await _context.TicketBuyers.FirstOrDefaultAsync(item =>
                item.EventId == eventId && item.BuyerId == userId);

            if (cartItem == null)
            {
                return false;
            }

            cartItem.Quantity++; // Увеличаване на количеството

            await _context.SaveChangesAsync(); // Запазване на промените в базата данни

            return true;
        }

        public async Task<bool> DeleteEventAsync(int id)
        {
            var eventToDelete = await _context.Events.FindAsync(id);
            if (eventToDelete == null)
            {
                return false;  
            }

            _context.Events.Remove(eventToDelete);
            await _context.SaveChangesAsync();
            return true;  
        }

        public async Task<bool> RemoveEventFromCartAsync(int eventId, string userId)
        {
            var entryToRemove = await _context.TicketBuyers.FirstOrDefaultAsync(e => e.EventId == eventId && e.BuyerId == userId);

            if (entryToRemove == null)
            {
                return false;  
            }

            _context.TicketBuyers.Remove(entryToRemove);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task UpdateEventAsync(int id, EventsViewModel events)
        {
            var eventToEdit = await _context.Events.FindAsync(id);

            if (eventToEdit == null)
            {
                throw new ArgumentException("Event not found");
            }

            eventToEdit.Name = events.Name;
            eventToEdit.Features = events.Features;
            eventToEdit.Description = events.Description;
            eventToEdit.PriceTicket = events.PriceTicket;
            eventToEdit.WineList = events.WineList;
            eventToEdit.Address = events.Address;
            eventToEdit.DateTime = events.DateTime;
            eventToEdit.HostName = events.HostName;
            eventToEdit.Duration = events.Duration;
            eventToEdit.ImageUrl = events.ImageUrl;
            eventToEdit.Preferences = events.Preferences;
            eventToEdit.MoreInformation = events.MoreInformation;

            await _context.SaveChangesAsync();
        }


    }
}

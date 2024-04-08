using EventsWebsite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WineSite.Contracts;
using WineSite.Data;
using WineSite.Data.Models;
using WineSite.Models.Event;

namespace WineSite.Services
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
                return false; // Можете да хвърлите изключение или върнете подходящ резултат
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
            var user = await _context.Users.FindAsync(currentUserId);

            //FirstOrDefaultAsync(u => u.Id == currentUserId);
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
                    PostCode = deliveryDetails.PostCode,
                    Phonenumber = deliveryDetails.PhoneNumber,
                    BuyerId = currentUserId,
                    EventId = eventBuyer.Events.Id,
                    EventName = eventBuyer.Events.Name,
                    QuentityEvent = 1 // Set the default quantity here, or adjust as needed
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
                .Where(ab => ab.BuyerId == userId /*&& ab.IsPurchased*/) // Само закупените билети
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

        
    }
}

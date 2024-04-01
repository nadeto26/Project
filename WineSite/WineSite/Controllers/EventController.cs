using EventsWebsite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Security.Claims;
using WineSite.Data;
using WineSite.Data.Models;
using WineSite.Models.Event;

namespace WineSite.Controllers
{
    public class EventController : Controller
    {
        private readonly WineShopDbContext context;
        public EventController(WineShopDbContext _context)
        {
            context = _context;
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            EventsViewModel model = new EventsViewModel()
            {

            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(EventsViewModel mode)
        {
            var adEvent = new Events()
            {
                Name = mode.Name,
                HostName = mode.HostName,
                Address = mode.Address,
                DateTime = mode.DateTime,
                Description = mode.Description,
                ImageUrl = mode.ImageUrl,
                PriceTicket = mode.PriceTicket,
                WineList = mode.WineList,
                Features = mode.Features,
                Preferences = mode.Preferences,
                MoreInformation = mode.MoreInformation,
                Duration = mode.Duration,
            };

            context.Events.Add(adEvent);
            await context.SaveChangesAsync();

            return RedirectToAction("Add", "Event");
        }

        public async Task<bool> Exist(int id)
        {
            return await context.Events.AnyAsync(i=> i.Id == id);
        }

        public async Task<EventsViewModel?> EventDetailsId(int id)
        {
            return await context.Events.
                Where(w => w.Id == id)
                .Select(w => new EventsViewModel()
                {
                    Id = w.Id,
                    Name = w.Name,
                    HostName = w.HostName,
                    Address = w.Address,
                    DateTime = w.DateTime,
                    Description = w.Description,
                    Duration = w.Duration,
                    Features = w.Features,
                    ImageUrl = w.ImageUrl,
                    MoreInformation = w.MoreInformation,
                    WineList = w.WineList,
                    Preferences = w.Preferences,
                    PriceTicket = w.PriceTicket,
                })

                .FirstOrDefaultAsync();
        }

        public async Task<IActionResult>Details (int id)
        {
            if(await  Exist(id)==false)
            {
                return BadRequest();
            }

            var eventModel = await EventDetailsId(id);

            return View(eventModel);
        }

        

        public async Task<IActionResult> All()
        {
            var eventsToDisplay = await context.Events
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

            return View(eventsToDisplay);
        }


        //public async Task Delete(int eventId)
        //{
        //    var events = await context.Events
        //        .FindAsync(eventId);

        //    context.Events.Remove(events);
        //    await context.SaveChangesAsync();
        //}

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var searchedevent = await context.Events
                .Where(s => s.Id == id)
                .FirstOrDefaultAsync();

            //Checking if there is not a Seminar with that Id
            if (searchedevent == null)
            {
                return BadRequest();
            }
            var events = new EventDeleteViewModel()
            {
                Id = id,
                ImageUrl = searchedevent.ImageUrl,
                Name = searchedevent.Name,
            };

             
            return View(events);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            
            var currentEvent = await context.Events
                .Where(s => s.Id == id)
                .FirstOrDefaultAsync();

             
            if (currentEvent == null)
            {
                return BadRequest();
            }

            context.Events.Remove(currentEvent);
            await context.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> DetailsDelivery()
        {
            DeliveryDetailsViewModel admodel = new DeliveryDetailsViewModel()
            {

            };

            return View(admodel);
        }

        [HttpPost]
        public async Task<IActionResult> DetailsDelivery(DeliveryDetailsViewModel admode)
        {
            var adDelivery = new TicketDelivery()
            {
                FullName = admode.FullName,
                Address = admode.Address,
                City = admode.City,
                PostCode = admode.PostalCode,
                PhoneNumber = admode.PhoneNumber
            };
            await context.TicketDeliveries.AddAsync(adDelivery);
            await context.SaveChangesAsync();
            return RedirectToAction("Confirmation");
        }

        public IActionResult Confirmation()
        {
            return View();
        }

        // за записване за билети 
        public async Task<IActionResult> AddToCart(int id)
        {
            var adToAdd = await context.Events.FindAsync(id);

            if (adToAdd == null)
            {
                return BadRequest();
            }

            string currentUserId = GetUserId();

            var entry = new TicketBuyer()
            {
                BuyerId =  currentUserId,
                EventId = adToAdd.Id
            };

            context.TicketBuyers.Add(entry);
            await context.SaveChangesAsync();

           
            return RedirectToAction("CartTickets", "Event");

        }

        public async Task<IActionResult> CartTickets()
        {
            string currentUserId = GetUserId();

            var userTicket = await context
                .TicketBuyers
                .Where(ab => ab.BuyerId == currentUserId)
                .Select(ab => new AddToCartViewModel()
                {
                    Id = ab.Events.Id,
                    TicketName = ab.Events.Name,
                    PricePerTicket = ab.Events.PriceTicket,
                    ImageUrl = ab.Events.ImageUrl,
                    Quentity = ab.Quantity
                })
            .ToListAsync();

             

            return View(userTicket);
        }

        

        
        public async Task<IActionResult> AdminOrders()
        {
            var toDisplay = await context
                .AdminTicketBasket.Select(d => new AdminOrdersViewModel
                {
                    EventName = d.TicketBuyer.Events.Name,
                    Adress = d.Delivery.Address,
                    FullName = d.Delivery.FullName,
                    PhoneNumber = d.Delivery.PhoneNumber,
                    PostCode = d.Delivery.PostCode,
                    Quantity = d.TicketBuyer.Quantity,
                    WholePrice= d.TicketBuyer.WholePrice,

                })
                .ToListAsync();

            return View(toDisplay);
        }

        public async Task AddToAdminTicketBasket(int ticketDeliveryId, int eventId, string buyerId)
        {
            var adminTicketBasket = new AdminTicketBasket
            {
                TicketDeliveryId = ticketDeliveryId,
                EventId = eventId,
                BuyerId = buyerId
            };

            context.AdminTicketBasket.Add(adminTicketBasket);
            await context.SaveChangesAsync();
        }


        private string GetUserId()
         => User.FindFirstValue(ClaimTypes.NameIdentifier);

    }
}

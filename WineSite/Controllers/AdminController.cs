using EventsWebsite.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Data;
using System.Security.Claims;
using WineSite.Data;
using WineSite.Data.Models;
using WineSite.Models.Admin;
using WineSite.Models.Event;
using WineSite.Models.Receipt;

namespace WineSite.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AdminController : Controller
    {
        private readonly WineShopDbContext context;
        public AdminController(WineShopDbContext _context)
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

        public async Task<IActionResult> Orders()
        {
            var toDisplay = await context.Orders
                .Select(d => new OrderViewModel
                {
                    Id = d.Id,
                    FullName = d.FullName,
                    PostCode = d.PostCode,
                    Address = d.Address,
                    City = d.City,
                    QuentityEvent = d.QuentityEvent,
                    EventName = d.EventName,
                    Phonenumber = d.Phonenumber,
                })
                .ToListAsync();

            return View(toDisplay);
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

            return RedirectToAction("Recipe", "Admin");
        }

        //recipes
        [HttpGet]
        public async Task<IActionResult> AddRecipe()
        {
            ReceiptViewModel receiptViewModel = new ReceiptViewModel();
            return View(receiptViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ReceiptViewModel model)
        {
            var adModel = new Recipe()
            {
                Name = model.Name,
                Notes = model.Notes,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
            };

            await context.Recipes.AddAsync(adModel);
            await context.SaveChangesAsync();

            return RedirectToAction("Add", "Recipe");
        }

        //изтринате на рецепта 

        private string GetUserId()
        => User.FindFirstValue(ClaimTypes.NameIdentifier);
    }
}

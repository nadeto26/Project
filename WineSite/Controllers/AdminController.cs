using EventsWebsite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Security.Claims;
using WineSite.Data;
using WineSite.Models.Admin;
using WineSite.Models.Event;

namespace WineSite.Controllers
{
    public class AdminController : Controller
    {
        private readonly WineShopDbContext context;
        public AdminController(WineShopDbContext _context)
        {
            context = _context;
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

        private string GetUserId()
        => User.FindFirstValue(ClaimTypes.NameIdentifier);
    }
}

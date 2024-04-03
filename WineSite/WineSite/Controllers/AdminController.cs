using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WineSite.Data;
using WineSite.Models.Admin;
 

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
                    Email = d.Email,
                    City = d.City,
                    QuentityEvent = d.QuentityEvent,
                    EventName = d.EventName,
                    Phonenumber = d.Phonenumber,
                })
                .ToListAsync();

            return View(toDisplay);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteOrder(int orderId)
        {
            var order = await context.Orders.FirstOrDefaultAsync(o => o.Id == orderId);
            if (order == null)
            {
                return NotFound();
            }

            context.Orders.Remove(order);
            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Orders));
        }


        private string GetUserId()
        => User.FindFirstValue(ClaimTypes.NameIdentifier);
    }
}

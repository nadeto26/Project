using EventsWebsite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Security.Claims;
using WineSite.Contracts;
using WineSite.Data;
using WineSite.Data.Models;
using WineSite.Models.Event;

namespace WineSite.Controllers
{
    public class EventController : Controller
    {
        private readonly IEventServices eventServices;
        public EventController(IEventServices services)
        {
            eventServices = services;
        }

        public async Task<IActionResult> EventDetails(int id)
        {
            var eventModel = await eventServices.GetEventDetailsByIdAsync(id);

            if (eventModel == null)
            {
                return NotFound();
            }

            return View(eventModel);
        }

        public async Task<IActionResult> Details(int id)
        {
            if (!await eventServices.ExistAsync(id))
            {
                return BadRequest();
            }

            var eventCountInTicketBuyers = await eventServices.GetEventTicketBuyersCountAsync(id);

            if (eventCountInTicketBuyers > 3)
            {
                return RedirectToAction("All");
            }

            var eventModel = await eventServices.GetEventDetailsByIdAsync(id);

            if (eventModel == null)
            {
                return NotFound();
            }

            return View(eventModel);
        }

        public async Task<IActionResult> All()
        {
            var eventsToDisplay = await eventServices.GetAllEventsAsync();
            return View(eventsToDisplay);
        }

        [HttpGet]
        public IActionResult DetailsDelivery()
        {
            var admodel = new DeliveryDetailsViewModel();
            return View(admodel);
        }

        [HttpPost]
        public async Task<IActionResult> DetailsDelivery(DeliveryDetailsViewModel admode)
        {
            if (ModelState.IsValid)
            {
                await eventServices.AddTicketDeliveryAsync(admode);
                return RedirectToAction("Confirmation");
            }

            // Ако моделът не е валиден, връщаме грешка
            return View(admode);
        }

        public async Task<IActionResult> Confirmation()
        {
            string currentUserId = GetUserId();

            if (string.IsNullOrEmpty(currentUserId))
            {
                return BadRequest("User not found");
            }

            try
            {
                await eventServices.ConfirmOrderAsync(currentUserId); // Предполагаме, че имате достъп до инстанцията на вашия сервис (_yourService) в контролера
                return View(); // Извършването на поръчката завърши успешно
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); // Прихващане на възникналите грешки при изпълнение на ConfirmOrderAsync
            }
        }

        public async Task<IActionResult> AddToCart(int id)
        {
            string currentUserId = GetUserId();

            bool addedToCart = await eventServices.AddEventToCartAsync(id, currentUserId);

            if (!addedToCart)
            {
                ModelState.AddModelError(string.Empty, "Неуспешно добавяне на билет в кошницата.");
            }

            return RedirectToAction("CartTickets", "Event");
        }

        public async Task<IActionResult> CartTickets()
        {
            string currentUserId = GetUserId();

            var userTickets = await eventServices.GetUserTicketsAsync(currentUserId);

            return View(userTickets);
        }


        private string GetUserId()
         => User.FindFirstValue(ClaimTypes.NameIdentifier);

    }
}

﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WineSite.Core.Contracts;
using WineSite.Core.Models.Event;
 

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

            if (eventCountInTicketBuyers > 10)
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
            return View(admode);
        }

        public async Task<IActionResult> Confirmation()
        {
            string currentUserId = GetUserId();

            if (string.IsNullOrEmpty(currentUserId))
            {
                return BadRequest("User not found");
            }
            await eventServices.ConfirmOrderAsync(currentUserId);

            return View();
        }

        public async Task<IActionResult> RemoveFromCart(int id)
        {
            string currentUserId = GetUserId();

            bool removedFromCart = await eventServices.RemoveEventFromCartAsync(id, currentUserId);

            if (!removedFromCart)
            {
                ModelState.AddModelError(string.Empty, "Неуспешно премахване на събитието от количката.");
            }

            return RedirectToAction("CartTickets", "Event");
        }

        [Authorize]
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

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var eventModel = await eventServices.GetEventAsync(id);
                return View(eventModel);
            }
            catch (ArgumentException)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EventsViewModel events)
        {
            try
            {
                await eventServices.UpdateEventAsync(id, events);
                return RedirectToAction("All", "Event");
            }
            catch (ArgumentException)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            bool result = await eventServices.DeleteEventAsync(id);
            if (!result)
            {
                return NotFound();  
            }

            return RedirectToAction("All"); 
        }

        [HttpPost]
        public async Task<IActionResult> IncreaseCartItemQuantity(int eventId, string userId)
        {
            bool success = await eventServices.IncreaseQuantityAsync(eventId, userId);
            if (!success)
            {
                
                return BadRequest();
            }

           
            return RedirectToAction("CartTickets");
        }

        public async Task<IActionResult> DecreaseQuantity(int id)
        {
            string currentUserId = GetUserId();
            var wineCartItem = await eventServices.GetCartItemByIdAsync(currentUserId, id);

            if (wineCartItem != null)
            {
                if (wineCartItem.Quantity > 1)
                {
                    wineCartItem.Quantity--;
                    await eventServices.UpdateCartItemAsync(wineCartItem);
                }
                else
                {
                    await eventServices.RemoveEventFromCartAsync(id, currentUserId);
                }
            }

            return RedirectToAction(nameof(CartTickets));
        }

        public async Task<IActionResult> IncreaseQuantity(int id)
        {
            string currentUserId = GetUserId();
            var wineCartItem = await eventServices.GetCartItemByIdAsync(currentUserId, id);

            if (wineCartItem != null)
            {
                wineCartItem.Quantity++;
                await eventServices.UpdateCartItemAsync(wineCartItem);
            }

            return RedirectToAction(nameof(CartTickets));
        }




        private string GetUserId()
         => User.FindFirstValue(ClaimTypes.NameIdentifier);

    }
}

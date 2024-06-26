﻿ 
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
 
using System.Security.Claims;
using WineSite.Core.Contracts;
 
using WineSite.Core.Models.Wine;
 

namespace WineSite.Controllers
{
   
    public class WineController : Controller
    {
        private readonly IWineServices _wines;
    
        
        public WineController(IWineServices wines)
        {
            _wines = wines;
          
             
        }
        [HttpPost]
        
        public async Task<IActionResult> Delete(int id)
        {
            bool result = await _wines.DeleteWineAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return RedirectToAction("All");
            
        }
        public async Task<IActionResult> All([FromQuery] AllWinesQuaryModel query)
        {
            var queryResult = _wines.All(
                query.Type,
                query.SearchItem,
                query.Sorting,
                query.CurrentPage,
                AllWinesQuaryModel.WinePerPage
                );

            query.TotalWinesCount = queryResult.TotalWinesCount;
            query.Wines = (IEnumerable<WineServicesModel>)queryResult.Wines;

            var winesTypes = await _wines.AllTypesName();
            query.Types = (IEnumerable<string>)winesTypes;
            return View(query);
        }

        public async Task<IActionResult> Details(int id)
        {
            if(await _wines.Exist(id) == false)
            {
                return BadRequest();
            }
            
            var wineModel = await _wines.WineDetailsById(id);

            return View(wineModel);
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if(await _wines.Exist(id)== false)
            {
                return BadRequest();
            }

            var wine = await _wines.WineDetailsById(id);

            var wineTypeId = await _wines.GetWineTypeId(wine.Id);

            var wineModel = new WineFormModel()
            {
                Name = wine.Name,
                TypeId = wineTypeId,
                Year = wine.Year,
                ImageUrl = wine.ImageUrl,
                Description = wine.Description,
                Country = wine.Country,
                Importer = wine.Importer,
                AlcoholContent = wine.AlcoholContent,
                Bottle = wine.Bottle,
                Harvest = wine.Harvest,
                Manufucturer = wine.Manufucturer,
                Price = wine.Price,
                Types = await _wines.AllTypes()
            };
            return View(wineModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, WineFormModel wine)
        {
            if(await _wines.Exist(id) == false)
            {
                return this.View();
            }

            if(await _wines.TypeExist(wine.TypeId) == false)
            {
                this.ModelState.AddModelError(nameof(wine.TypeId),
                    "Type does not exist");
            }

            if(!ModelState.IsValid)
            {
                wine.Types = await _wines.AllTypes();

                return View(wine);
            }

            _wines.Edit(id, wine.Name, wine.TypeId, wine.Year, wine.ImageUrl, wine.Description,
                wine.Country, wine.Manufucturer, wine.Price, wine.Harvest, wine.AlcoholContent,
                wine.Bottle, wine.Importer);

            return RedirectToAction(nameof(All));
        }


        [Authorize]
        public async Task<IActionResult> Cart()
        {
            string currentUserId = GetUserId();
            var userCartItems = await _wines.GetUserWineAsync(currentUserId);

            return View(userCartItems);
        }



        public async Task<IActionResult> DecreaseQuantity(int id)
        {
            string currentUserId = GetUserId();
            var wineCartItem = await _wines.GetCartItemByIdAsync(currentUserId, id);

            if (wineCartItem != null)
            {
                if (wineCartItem.Quantity > 1)
                {
                    wineCartItem.Quantity--;
                    await _wines.UpdateCartItemAsync(wineCartItem);
                }
                else
                {
                    await _wines.RemoveWineFromCartAsync(currentUserId, id);
                }
            }

            return RedirectToAction(nameof(Cart));
        }

        public async Task<IActionResult> IncreaseQuantity(int id)
        {
            string currentUserId = GetUserId();
            var wineCartItem = await _wines.GetCartItemByIdAsync(currentUserId, id);

            if (wineCartItem != null)
            {
                wineCartItem.Quantity++;
                await _wines.UpdateCartItemAsync(wineCartItem);
            }

            return RedirectToAction(nameof(Cart));
        }


        [Authorize]
        public async Task<IActionResult> AddToCart(int id)
        {
            string currentUserId = GetUserId();

            bool addedToCart = await _wines.AddWineToCartAsync(id, currentUserId);

            if (!addedToCart)
            {
                ModelState.AddModelError(string.Empty, "Неуспешно добавяне на вино в кошницата.");
            }
             
            return RedirectToAction(nameof(Cart)) ;
        }

        [HttpPost]
        public async Task<IActionResult> DeleteFromCart(int id)
        {
            string currentUserId = GetUserId();

            bool removedFromCart = await _wines.RemoveWineFromCartAsync(currentUserId, id);

            if (!removedFromCart)
            {
                ModelState.AddModelError(string.Empty, "Неуспешно премахване на виното от количката.");
            }

            return RedirectToAction("Cart", "Wine");
        }

        public async Task<IActionResult> Confirmation()
        {
            string currentUserId = GetUserId();

            if (string.IsNullOrEmpty(currentUserId))
            {
                return BadRequest("User not found");
            }

            await _wines.ConfirmOrderAsync(currentUserId);

            return View();
        }

        [HttpGet]
        public IActionResult DetailsDelivery()
        {
            var admodel = new WineDeliveryDetailsViewModel();
            return View(admodel);
        }

        [HttpPost]
        public async Task<IActionResult> DetailsDelivery(WineDeliveryDetailsViewModel admode)
        {
            if (ModelState.IsValid)
            {
                await _wines.WineDeliveryAsync(admode);
                return RedirectToAction("Confirmation");
            }
 
            return View(admode);
        }

       
        private string GetUserId()
       => User.FindFirstValue(ClaimTypes.NameIdentifier);





    }
}

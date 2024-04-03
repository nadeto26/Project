using EventsWebsite.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Data;
using System.Security.Claims;
using WineSite.Contracts;
using WineSite.Data.Models;
using WineSite.Models.Wine;
using WineSite.Services;
using WineSite.Services.Wine.Models;

namespace WineSite.Controllers
{
    //[Authorize(Roles = "Administrator")]
    public class WineController : Controller
    {
        private readonly IWineServices _wines;
        private readonly IVinarServices _vinar;
        public WineController(IWineServices wines,IVinarServices vinar)
        {
            _wines = wines;
            _vinar = vinar;
        }

        [HttpGet]
        public async Task<IActionResult> Add() //само винаря може да добавя 
        {
            return View(new WineFormModel
            {
                Types = await _wines.AllTypes()
            });

        }

        [HttpPost]
        public async Task<IActionResult> Add(WineFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (await _wines.TypeExist(model.TypeId) == false)
            {
                ModelState.AddModelError(nameof(model.TypeId),
                    "Type does not exist");
                return BadRequest(ModelState);
            }

            var newWineId = await _wines.Create(model.Name, model.TypeId, model.Year,
                model.ImageUrl, model.Description, model.Country, model.Manufucturer, model.Price,
                model.Sort, model.Harvest, model.AlcoholContent, model.Bottle,model.Importer,model.Quantity);

            return RedirectToAction(nameof(Details), new { id = newWineId });
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
            query.Wines = queryResult.Wines;

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

       
        public async Task<IActionResult> Edit(int id)
        {
            if (!(await _wines.Exist(id)))
            {
                return BadRequest();
            }
            var wine = await _wines.WineDetailsById(id);
            var houseCategoryId = await _wines.GetWineTypeId(wine.Id);
            var wineModel = new WineFormModel
            {
                Name = wine.Name,
                Price = wine.Price,
                ImageUrl = wine.ImageUrl,
                Country = wine.Country,
                Description = wine.Description,
                Types = await _wines.AllTypes()
            };

            return View(wineModel);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(int id, WineFormModel wine)
        {
            if (!(await _wines.Exist(id)))
            {
                return View();
            }
            if (!(await _wines.TypeExist(wine.TypeId)))
            {
                ModelState.AddModelError(nameof(wine.TypeId), "Type does not exist.");
            }

            if (!ModelState.IsValid)
            {
                wine.Types = await _wines.AllTypes();
                return View(wine);
            }

           await _wines.Edit(id, wine.Name, wine.TypeId, wine.Year, wine.ImageUrl, wine.Description,
                wine.Country, wine.Manufucturer, wine.Price, wine.Sort, wine.Harvest, wine.AlcoholContent,
                wine.Bottle);
            //return RedirectToAction(nameof(Details), new { id = "1" });

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if(await _wines.Exist(id) == false)
            {
                return BadRequest();
            }

            var wine = await _wines.WineDetailsById(id);

            var model = new WineDetailsViewModel()
            {
                Name = wine.Name,
                Description = wine.Description,
                ImageUrl = wine.ImageUrl
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(WineDetailsViewModel wine)
        {
            if(await _wines.Exist(wine.Id))
            {
                return BadRequest();
            }
            _wines.Delete(wine.Id);
            return RedirectToAction(nameof(All));
        }

        public async Task<IActionResult> Cart()
        {
            var mineWines = await _wines.GetWinesAsync(GetUserId());

            return View(mineWines);
        }

        [Authorize]
        public async Task<IActionResult> AddToCart(int id)
        {
           var wine = await _wines.GetWineByIdAsync(id);
           if(wine == null)
           {
                return BadRequest();
           }
           string currentUserId = GetUserId();
           await _wines.AddToCart(currentUserId,wine);

          return RedirectToAction(nameof(Cart));
        }

        public async Task<IActionResult> DeleteFromCart(int id)
        {
            var book = await _wines.GetWineByIdAsync(id);
            var userId = GetUserId();

            await _wines.RemoveWineFromCartAsync(userId, book);

            return RedirectToAction(nameof(Cart));
        }

        [HttpGet]
        public async Task<IActionResult> DetailsDelivery()
        {
            DeliveryDetailsViewModel admodel = new DeliveryDetailsViewModel()
            {

            };

            return View(admodel);
        }

        public async Task<IActionResult> DetailsDelivery(DeliveryDetailsViewModel admode)
        {
            if (!ModelState.IsValid)
            {
                return View(admode);
            }

            await _wines.AddDeliveryDetails(admode);

            return RedirectToAction("Confirmation");
        }
        [HttpPost]
        public async Task<IActionResult> Confirmation()
        {
            string userId = GetUserId();

            if (string.IsNullOrEmpty(userId))
            {
                return BadRequest("User not found");
            }

            await _wines.ConfirmOrder(userId);
            return View();
        }


        private string GetUserId()
       => User.FindFirstValue(ClaimTypes.NameIdentifier);





    }
}

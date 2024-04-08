using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Data;
using System.Security.Claims;
using WineSite.Contracts;
using WineSite.Infrastructure;
using WineSite.Models.Wine;
using WineSite.Services;
using WineSite.Services.Wine.Models;

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
            if(await _wines.TypeExist(model.TypeId) == false)
            {
                this.ModelState.AddModelError(nameof(model.TypeId),
                    "Type does not exist");
            }

            if(!ModelState.IsValid)
            {
                model.Types = await _wines.AllTypes();
                return View(model);
            }
            

            var newWineId = await _wines.Create(model.Name, model.TypeId,model.Year,
                model.ImageUrl,model.Description,model.Country,model.Manufucturer,model.Price,
                model.Sort,model.Harvest,model.AlcoholContent,model.Bottle,model.Importer);

            return RedirectToAction(nameof(Details), new {id=newWineId});
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
                Sort = wine.Sort,
                Price  = wine.Price,
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
                wine.Country, wine.Manufucturer, wine.Price, wine.Sort, wine.Harvest, wine.AlcoholContent,
                wine.Bottle, wine.Importer);

            return RedirectToAction(nameof(Details), new { id = "1" });
        }

         

        public async Task<IActionResult> Cart()
        {
            return View(new AllWinesQuaryModel());
        }

        public async Task<IActionResult> AddToCart(int id)
        {
            return RedirectToAction(nameof(Cart));
        }

        public async Task<IActionResult> DeleteFromCart(int id)
        {
            return RedirectToAction(nameof(Cart));
        }

        

        private string GetUserId()
       => User.FindFirstValue(ClaimTypes.NameIdentifier);





    }
}

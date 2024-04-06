using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Data;
using System.Security.Claims;
using WineSite.Contracts;
using WineSite.Models.Wine;
using WineSite.Services.Wine.Models;

namespace WineSite.Controllers
{
    public class WineController : Controller
    {
        private readonly IWineServices _wines;
        private readonly IVinarServices _vinar;
        public WineController(IWineServices wines,IVinarServices vinar)
        {
            _wines = wines;
            _vinar = vinar;
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
            var vinarId = await _vinar.GetVinarId(GetUserId());

            var newWineId = await _wines.Create(model.Name, model.TypeId,model.Year,
                model.ImageUrl,model.Description,model.Country,model.Manufucturer,model.Price,
                model.Sort,model.Harvest,model.AlcoholContent,model.Bottle,vinarId);

            return RedirectToAction(nameof(Details), new {id=newWineId});
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            
            return View(new WineFormModel());
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, WineFormModel wine)
        {
            return RedirectToAction(nameof(Details), new { id = "1" });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            return View(new WineFormModel());
        }

        [HttpPost]
        public async Task<IActionResult> Delete(WineFormModel wine)
        {
            return View(nameof(All));
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

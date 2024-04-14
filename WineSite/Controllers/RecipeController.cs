using Microsoft.AspNetCore.Mvc;
using WineSite.Core.Contracts;
using WineSite.Core.Models.Receipt;

namespace WineSite.Controllers
{
     
    public class RecipeController : Controller
    {
        private readonly IRecipeServices recipeServices;
        public RecipeController(IRecipeServices services)
        {
            recipeServices = services;
        }

        public async Task<IActionResult> All()
        {
            var recipesToDisplay = await recipeServices.GetAllRecipesAsync();
            return View(recipesToDisplay);
        }

        public async Task<IActionResult> Details(int id)
        {
            if (!await recipeServices.ExistAsync(id))
            {
                return BadRequest();
            }

            var recipeModel = await recipeServices.GetRecipeDetailsByIdAsync(id);

            if (recipeModel == null)
            {
                return NotFound();
            }

            return View(recipeModel);
        }
 
           

        [HttpPost]
        public async Task<IActionResult> Edit(int id, ReceiptViewModel events)
        {
            try
            {
                await recipeServices.UpdateRecipeAsync(id, events);
                return RedirectToAction("All", "Recipe");
            }
            catch (ArgumentException)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var eventModel = await recipeServices.GetRecipeAsync(id);
                return View(eventModel);
            }
            catch (ArgumentException)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            bool result = await recipeServices.DeleteRecipeAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return RedirectToAction("All");
        }


    }

}
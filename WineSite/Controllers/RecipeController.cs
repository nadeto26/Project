using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using WineSite.Contracts;
using WineSite.Data;
using WineSite.Data.Models;
using WineSite.Models.Receipt;

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

    }

}
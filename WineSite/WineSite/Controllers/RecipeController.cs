using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WineSite.Data;
using WineSite.Data.Models;
using WineSite.Models.Receipt;

namespace WineSite.Controllers
{
    public class RecipeController : Controller
    {
        private readonly WineShopDbContext context;

        public RecipeController(WineShopDbContext _context)
        {
            context = _context;
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            ReceiptViewModel receiptViewModel = new ReceiptViewModel();
            return View(receiptViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ReceiptViewModel model)
        {
            var adModel = new Recipe()
            {
                Name = model.Name,
                Notes = model.Notes,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
            };

            await context.Recipes.AddAsync(adModel);
            await context.SaveChangesAsync();

            return RedirectToAction("Add", "Recipe");
        }

        public async Task<IActionResult> All()
        {
            var recipesToDisplay = await context
                .Recipes
                .Select(r => new AllRecipeViewModel
                {
                    Id = r.Id,
                    Name = r.Name,
                    Description = r.Description,
                    ImageUrl = r.ImageUrl,
                    Notes = r.Notes,
                }).ToListAsync();

            return View(recipesToDisplay);
        }

        public async Task<bool> Exist(int id)
        {
            return await context.Recipes.AnyAsync(i => i.Id == id);
        }

        public async Task<AllRecipeViewModel?> RecipeDetailsId(int id)
        {
            return await context.Recipes.
                Where(w => w.Id == id)
                .Select(w => new AllRecipeViewModel()
                {
                    Id = w.Id,
                    Name = w.Name,
                    Notes = w.Notes,
                    Description = w.Description,
                    ImageUrl = w.ImageUrl,
                })

                .FirstOrDefaultAsync();
        }

        public async Task<IActionResult> Details(int id)
        {
            if (await Exist(id) == false)
            {
                return BadRequest();
            }

            var recipeModel = await RecipeDetailsId(id);

            return View(recipeModel);
        }


    }

}
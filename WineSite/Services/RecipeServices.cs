using EventsWebsite.Models;
using Microsoft.EntityFrameworkCore;
using WineSite.Contracts;
using WineSite.Data;
using WineSite.Data.Models;
using WineSite.Models.Receipt;

namespace WineSite.Services
{
    public class RecipeServices : IRecipeServices
    {
        private readonly WineShopDbContext _dbcontext;
        public RecipeServices(WineShopDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public async Task AddRecipeAsync(ReceiptViewModel model)
        {
            var adRecipe = new Recipe()
            {
                Name = model.Name,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                Notes = model.Notes,
            };

            _dbcontext.Recipes.Add(adRecipe);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<bool> DeleteRecipeAsync(int id)
        {
            var recipeToDelete = await _dbcontext.Recipes.FindAsync(id);
            if (recipeToDelete == null)
            {
                return false;  
            }

            _dbcontext.Recipes.Remove(recipeToDelete);
            await _dbcontext.SaveChangesAsync();
            return true;  
        }

        public async  Task<bool> ExistAsync(int id)
        {
            return await _dbcontext.Recipes.AnyAsync(i => i.Id == id);
        }

        public async Task<List<AllRecipeViewModel>> GetAllRecipesAsync()
        {
            return await _dbcontext.Recipes
           .Select(r => new AllRecipeViewModel
           {
               Id = r.Id,
               Name = r.Name,
               Description = r.Description,
               ImageUrl = r.ImageUrl,
               Notes = r.Notes,
           })
           .ToListAsync();
        }

        public async Task<ReceiptViewModel> GetRecipeAsync(int id)
        {
            var recipeToEdit = await _dbcontext.Recipes.FindAsync(id);

            if (recipeToEdit == null)
            {
                throw new ArgumentException("Recipe not found");
            }

            return new ReceiptViewModel()
            {
                Name = recipeToEdit.Name,
                Description = recipeToEdit.Description,
                Notes = recipeToEdit.Notes,
                ImageUrl = recipeToEdit.ImageUrl
            };
        }

        public async Task<AllRecipeViewModel?> GetRecipeDetailsByIdAsync(int id)
        {
            return await _dbcontext.Recipes
           .Where(w => w.Id == id)
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

        public async Task UpdateRecipeAsync(int id, ReceiptViewModel recipe)
        {
            var recipeToEdit = await _dbcontext.Recipes.FindAsync(id);

            if (recipeToEdit == null)
            {
                throw new ArgumentException("Recipe not found");
            }

             recipeToEdit.Name = recipe.Name;
             recipeToEdit.Notes = recipe.Notes;
             recipeToEdit.Description = recipe.Description;
             recipeToEdit.ImageUrl = recipe.ImageUrl;
           
            await _dbcontext.SaveChangesAsync();
        }
    }
}

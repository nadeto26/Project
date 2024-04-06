using Microsoft.EntityFrameworkCore;
using WineSite.Contracts;
using WineSite.Data;
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
    }
}

using WineSite.Models.Receipt;

namespace WineSite.Contracts
{
    public interface IRecipeServices
    {
        Task<List<AllRecipeViewModel>> GetAllRecipesAsync();

        Task<bool> ExistAsync(int id);

        Task<AllRecipeViewModel?> GetRecipeDetailsByIdAsync(int id);
    }
}

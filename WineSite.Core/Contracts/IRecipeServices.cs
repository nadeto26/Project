using WineSite.Core.Models.Receipt;

namespace WineSite.Core.Contracts
{
    public interface IRecipeServices
    {
        Task<List<AllRecipeViewModel>> GetAllRecipesAsync();

        Task<bool> ExistAsync(int id);

        Task<AllRecipeViewModel?> GetRecipeDetailsByIdAsync(int id);

        Task AddRecipeAsync(ReceiptViewModel model);

        Task<ReceiptViewModel> GetRecipeAsync(int id);

        Task UpdateRecipeAsync(int id, ReceiptViewModel events);

        Task<bool> DeleteRecipeAsync(int id);
    }
}

using WineSite.Core.Infrastructure;
using WineSite.Core.Models.Event;
using WineSite.Core.Models.Wine;
 

namespace WineSite.Core.Contracts
{
    public interface IWineServices
    {
        Task<IEnumerable<WineTypeServicesModel>> AllTypes();

        Task <bool> TypeExist(int typeId);

        WineQueryServicesModel All(string type = null,
            string searchItem = null,
            WineSorting sorting = WineSorting.HighestPrice,
            int currentPage = 1,
            int wineperPage = 1);

        Task<IEnumerable<string>> AllTypesName();

        Task<bool> Exist(int id);

        Task<WineDetailsSevicesModel> WineDetailsById(int id);

        Task Edit(int wineId, string name, int typeId, int year,
            string imageUrl, string description, string country,
            string manufucturer, decimal price,
            string sort, int harvest, int alcoholcontent,
            int bottle, string importer);

        Task<int> GetWineTypeId(int wineId);

        Task<bool> DeleteWineAsync(int id);

        Task<bool> AddWineToCartAsync(int wineId, string userId);

        Task<List<WineCart>> GetUserWineAsync(string userId);

        Task<bool> RemoveWineFromCartAsync(int wineId, string userId);

        Task ConfirmOrderAsync(string currentUserId);

        Task WineDeliveryAsync(WineDeliveryDetailsViewModel deliveryDetails);


    }
}

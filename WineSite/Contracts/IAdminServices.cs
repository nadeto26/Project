using EventsWebsite.Models;
using WineSite.Models.Admin;
using WineSite.Models.Receipt;
using WineSite.Services.Wine.Models;

namespace WineSite.Contracts
{
    public interface IAdminServices
    {
        Task AddEventAsync(EventsViewModel model);

        Task AddRecipeAsync(ReceiptViewModel model);

        Task<int> Create(string name, int typeId, int year,
        string imageUrl, string description, string country,
        string manufucturer, decimal price,
        string sort, int harvest, int alcoholcontent,
        int bottle, string importer);

        Task<IEnumerable<WineTypeServicesModel>> AllTypes();

        Task<bool> TypeExist(int typeId);

        Task<List<OrderViewModel>> GetOrdersForTicketsAsync();

        Task<List<WineOrderViewModel>> GetWinesOrdersAsync();

        Task<bool> DeleteTicketOrderAsync(int id);

        Task<bool> DeleteWineOrderAsync(int id);
    }
}

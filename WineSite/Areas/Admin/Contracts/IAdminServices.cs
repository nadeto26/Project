using WineSite.Core.Models.Admin;
using WineSite.Core.Models.Contact;
using WineSite.Core.Models.Event;
using WineSite.Core.Models.Receipt;
using WineSite.Core.Models.Wine;

namespace WineSite.Areas.Admin.Contracts
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

        Task DeleteWineOrderAsync(int id);

        Task<List<AddMessage>> GetAllMessagesAsync();

        Task DeleteMessageAsync(int id);
    }
}

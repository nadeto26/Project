using EventsWebsite.Models;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using WineSite.Infrastructure;
using WineSite.Models.Wine;
using WineSite.Services.Wine.Models;

namespace WineSite.Contracts
{
    public interface IWineServices
    {
        Task<IEnumerable<WineTypeServicesModel>> AllTypes();

        //Task<IEnumerable<WineTypeServicesModel>> LastTreeWines();

        Task <bool> TypeExist(int typeId);

        Task<int> Create(string name, int typeId, int year,
            string imageUrl, string description, string country,
            string manufucturer, decimal price,
            string sort, int harvest, int alcoholcontent,
            int bottle, string importer, int quantity);

        WineQueryServicesModel All(string type = null,
            string searchItem = null,
            WineSorting sorting = WineSorting.Newest,
            int currentPage = 1,
            int wineperPage = 1);

        Task<IEnumerable<string>> AllTypesName();

        Task<bool> Exist(int id);

        Task<int> GetWineTypeId(int wineId);

        Task<WineDetailsSevicesModel> WineDetailsById(int id);

        Task Edit(int wineId, string name, int typeId, int year,
            string imageUrl, string description, string country,
            string manufucturer, decimal price,
            string sort, int harvest, int alcoholcontent,
            int bottle);

        Task AddToCart(string userId, WineViewModel model); 

        Task<WineViewModel> GetWineByIdAsync(int id);

        Task<IEnumerable<WineCart>> GetWinesAsync(string userId);

        Task RemoveWineFromCartAsync(string userId, WineViewModel model);

        Task Delete(int wineId);

        Task AddDeliveryDetails(DeliveryDetailsViewModel admode);

        Task ConfirmOrder(string userId);


    }
}

using WineSite.Infrastructure;
using WineSite.Models.Wine;
using WineSite.Services.Wine.Models;

namespace WineSite.Contracts
{
    public interface IWineServices
    {
        Task<IEnumerable<WineTypeServicesModel>> AllTypes();

        Task <bool> TypeExist(int typeId);

        Task<int> Create(string name, int typeId, int year,
            string imageUrl, string description, string country,
            string manufucturer, decimal price,
            string sort, int harvest, int alcoholcontent,
            int bottle, string importer);

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




    }
}

using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WineSite.Areas.Admin.Contracts;
using WineSite.Core.Models.Event;
using WineSite.Core.Models.Receipt;
using WineSite.Core.Models.Wine;

namespace WineSite.Areas.Admin.Controllers
{
    public class HomesController : AdminBaseController
    {
        private readonly IAdminServices _adminService;

        public HomesController(IAdminServices adminService)
        {
            _adminService = adminService;
        }

        public IActionResult Index()
        {
            return View();
        }

        //Добавяне на събитие
        [HttpGet]
        public IActionResult AddЕvent()
        {
            EventsViewModel model = new EventsViewModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddЕvent(EventsViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _adminService.AddEventAsync(model);

            return RedirectToAction("AddЕvent");

        }

        //Добавяне на рецепта
        [HttpGet]
        public IActionResult AddRecipe()
        {
            ReceiptViewModel receiptViewModel = new ReceiptViewModel();
            return View(receiptViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddRecipe(ReceiptViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            await _adminService.AddRecipeAsync(model);

            return RedirectToAction("AddRecipe");
        }

        //Добавяне на вино
        [HttpGet]
        public async Task<IActionResult> AddWine() //само винаря може да добавя 
        {
            return View(new WineFormModel
            {
                Types = await _adminService.AllTypes()
            });

        }

        [HttpPost]
        public async Task<IActionResult> AddWine(WineFormModel model)
        {
            if (await _adminService.TypeExist(model.TypeId) == false)
            {
                this.ModelState.AddModelError(nameof(model.TypeId),
                    "Type does not exist");
            }

            if (!ModelState.IsValid)
            {
                model.Types = await _adminService.AllTypes();
                return View(model);
            }


            var newWineId = await _adminService.Create(model.Name, model.TypeId, model.Year,
                model.ImageUrl, model.Description, model.Country, model.Manufucturer, model.Price,
                 model.Harvest, model.AlcoholContent, model.Bottle, model.Importer);

            return RedirectToAction("AddWine");
        }

        //Поръчки за билети
        public async Task<IActionResult> TicketOrders()
        {
            var orders = await _adminService.GetOrdersForTicketsAsync();
            return View(orders);
        }

        //Поръчки за вино
        public async Task<IActionResult> WineOrders()
        {
            var orders = await _adminService.GetWinesOrdersAsync();
            return View(orders);
        }

        //Събощения - от контаки 
        public async Task<IActionResult> AllMessages()
        {
            var messages = await _adminService.GetAllMessagesAsync();
            return View(messages);
        }

        //Изтриване - от контакти 
        public async Task<IActionResult> DeleteMessage(int id)
        {
            await _adminService.DeleteMessageAsync(id);
            return RedirectToAction(nameof(AllMessages));
        }

        //Изтриване на поръчка
        [HttpPost]
        public async Task<IActionResult> DeleteTicketOrder(int id)
        {
              await _adminService.DeleteTicketOrderAsync(id);
           
            return RedirectToAction("TicketOrders");
        }

        //Изтриване на вино
    
        public async Task<IActionResult> DeleteWineOrder(int id)
        {
            await _adminService.DeleteWineOrderAsync(id);
            return RedirectToAction("WineOrders");
        }
 
        ////изтринате на рецепта 

        private string GetUserId()
        => User.FindFirstValue(ClaimTypes.NameIdentifier);

    }
}

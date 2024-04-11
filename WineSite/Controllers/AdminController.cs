 

namespace WineSite.Controllers
{
    //[Authorize(Roles = "Administrator")]
    //public class AdminController : Controller
    //{
        //private readonly IAdminServices _adminService;

        //public AdminController(IAdminServices adminService)
        //{
        //    _adminService = adminService;
        //}
        
        ////Добавяне на събитие
        //[HttpGet]
        //public IActionResult AddЕvent()
        //{
        //    EventsViewModel model = new EventsViewModel();

        //    return View(model);
        //}

        //[HttpPost]
        //public async Task<IActionResult> AddEvent(EventsViewModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(model);
        //    }

        //    await _adminService.AddEventAsync(model);

        //    return RedirectToAction("Add");
        //}

        ////Добавяне на рецепта
        //[HttpGet]
        //public IActionResult AddRecipe()
        //{
        //    ReceiptViewModel receiptViewModel = new ReceiptViewModel();
        //    return View(receiptViewModel);
        //}

        //[HttpPost]
        //public async Task<IActionResult> AddRecipe(ReceiptViewModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(model);
        //    }
        //    await _adminService.AddRecipeAsync(model);

        //    return RedirectToAction("AddRecipe");
        //}

        ////Добавяне на вино
        //[HttpGet]
        //public async Task<IActionResult> AddWine() //само винаря може да добавя 
        //{
        //    return View(new WineFormModel
        //    {
        //        Types = await _adminService.AllTypes()
        //    });

        //}

        //[HttpPost]
        //public async Task<IActionResult> AddWine(WineFormModel model)
        //{
        //    if (await _adminService.TypeExist(model.TypeId) == false)
        //    {
        //        this.ModelState.AddModelError(nameof(model.TypeId),
        //            "Type does not exist");
        //    }

        //    if (!ModelState.IsValid)
        //    {
        //        model.Types = await _adminService.AllTypes();
        //        return View(model);
        //    }


        //    var newWineId = await _adminService.Create(model.Name, model.TypeId, model.Year,
        //        model.ImageUrl, model.Description, model.Country, model.Manufucturer, model.Price,
        //        model.Sort, model.Harvest, model.AlcoholContent, model.Bottle, model.Importer);

        //    return RedirectToAction("Admin" ,"Add");
        //}

        ////Поръчки за билети
        //public async Task<IActionResult> TicketOrders()
        //{
        //    var orders = await _adminService.GetOrdersForTicketsAsync();
        //    return View(orders);
        //}

        ////Поръчки за вино
        //public async Task<IActionResult> WineOrders()
        //{
        //    var orders = await _adminService.GetWinesOrdersAsync();
        //    return View(orders);
        //}

        ////Изтриване на поръчка
        //[HttpPost]
        //public async Task<IActionResult> DeleteTicketOrder(int id)
        //{
        //    var isDeleted = await _adminService.DeleteTicketOrderAsync(id);
        //    if (!isDeleted)
        //    {
        //        return NotFound();
        //    }

        //    return RedirectToAction("TicketOrders");
        //}

        ////Изтриване на вино
        //public async Task<IActionResult> DeleteWineOrder(int id)
        //{
        //    var isDeleted = await _adminService.DeleteWineOrderAsync(id);
        //    if (!isDeleted)
        //    {
        //        return NotFound();
        //    }

        //    return RedirectToAction("WineOrders");
        //}


        //////изтринате на рецепта 

        //private string GetUserId()
        //=> User.FindFirstValue(ClaimTypes.NameIdentifier);
    }


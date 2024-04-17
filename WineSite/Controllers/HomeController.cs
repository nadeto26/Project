using Microsoft.AspNetCore.Mvc;
using WineSite.Core.Models.Home;

namespace WineSite.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View(new IndexViewModel());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]

        public IActionResult Error(int statusCode)
        {
            if (statusCode == 404)
            {
                return View("Error404");
            }
            if (statusCode == 401)
            {
                return View("Error401");
            }
            if (statusCode == 500)
            {
                return View("Error500");
            }
            return View();
        }
    }
}
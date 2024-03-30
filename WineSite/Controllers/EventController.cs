using Microsoft.AspNetCore.Mvc;

namespace WineSite.Controllers
{
    public class EventController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

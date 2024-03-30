using Microsoft.AspNetCore.Mvc;

namespace WineSite.Controllers
{
    public class VinarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace WineSite.Controllers
{
    public class ReceiptController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

 
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WineSite.Core.Contracts;
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
    }
}

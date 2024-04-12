using Microsoft.AspNetCore.Mvc;
using WineSite.Areas.Admin.Controllers;
using WineSite.Core.Contracts;

namespace WineSite.Web.Areas.Admin.Controllers
{
    public class UserController :  AdminBaseController
    {
        private readonly IUserServices _userServices;
        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }
        [Route("User/All")]
        public async Task<IActionResult> All()
        {
            var users = await _userServices.All();
            return View(users);
        }
    }
}

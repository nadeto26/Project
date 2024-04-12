using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using WineSite.Areas.Admin.Controllers;
using WineSite.Core.Contracts;
using WineSite.Core.Models.Admin;
using static WineSite.Data.Data.Common.AdminConstants;

namespace WineSite.Web.Areas.Admin.Controllers
{
    public class UserController :  AdminBaseController
    {
        private readonly IUserServices _userServices;
        private readonly IMemoryCache _memorycashe;

        public UserController(IUserServices userServices, IMemoryCache memoryCache)
        {
            _userServices = userServices;
            _memorycashe = memoryCache;
        }
        [Route("User/All")]
        public async Task<IActionResult> All()
        {
            var model = _memorycashe.Get<IEnumerable<UserServiceModel>>(UserCacheKey);

            if(model == null || model.Any() == false)
            {
                model = await _userServices.All();

                var casheOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(5));

                _memorycashe.Set(UserCacheKey,model, casheOptions);
            }
            var users = await _userServices.All();
            return View(users);
        }
    }
}

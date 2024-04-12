 
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static WineSite.Data.Data.Common.AdminConstants;

namespace WineSite.Areas.Admin.Controllers
{
    [Area(AdminAreaName)]
    [Authorize(Roles = "Administrator")]
    public class AdminBaseController : Controller
    {
        
    }
}

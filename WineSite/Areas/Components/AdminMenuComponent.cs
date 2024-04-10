using Microsoft.AspNetCore.Mvc;

namespace WineSite.Areas.Components
{
    public class AdminMenuComponent:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult<IViewComponentResult>(View());
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using WineSite.Core.Contracts;
using WineSite.Core.Models.Contact;

namespace WineSite.Web.Controllers
{
    public class ContactsController : Controller
    {
        private readonly IContactServices  _contacts;

        public ContactsController(IContactServices contacts)
        {
            _contacts = contacts;
        }

        [HttpGet]
        public IActionResult AddMessage()
        {
            var admodel = new ContactViewModel();
            return View(admodel);
        }

        [HttpPost]
        public async Task<IActionResult> AddMessage(ContactViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _contacts.AddMessageAsync(model);
            return RedirectToAction("AddMessage");
        }
    }
}

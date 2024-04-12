using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WineSite.Core.Models.Contact;

namespace WineSite.Core.Contracts
{
    public interface IContactServices
    {
        Task AddMessageAsync(ContactViewModel model);
    }
}

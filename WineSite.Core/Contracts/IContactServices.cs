using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WineSite.Core.Models.Contact;
using WineSite.Data.Data.Models;

namespace WineSite.Core.Contracts
{
    public interface IContactServices
    {
        Task AddMessageAsync(AddMessage model);
    }
}

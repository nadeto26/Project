using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WineSite.Core.Models.Admin;

namespace WineSite.Core.Contracts
{
    public interface IUserServices
    {
        Task<string> UserFullName(string userId);

        Task<IEnumerable<UserServiceModel>> All();
    }
}

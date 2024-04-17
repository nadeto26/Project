using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WineSite.Core.Contracts;

namespace WineSite.Core.Infrastructure
{
    public static class ModelExtensions
    {
        public static string GetInformation(this IWineModel wine)
        {
            return wine.Name.Replace(" ", "-");
        }
    }
}

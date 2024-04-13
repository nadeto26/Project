using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using NUnit.Framework.Constraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WineSite.Data.Data;

namespace WineSite.Tests.Mocks
{
    public static class DatabaseMock
    {
        public static WineShopDbContext Instance
        {
            get
            {
                var dbContextOptions = new DbContextOptionsBuilder<WineShopDbContext>()
                    .UseInMemoryDatabase("WineShopDbContextInMemoaryDb"
                    + DateTime.Now.Ticks.ToString())
                    .Options;

                return new WineShopDbContext(dbContextOptions, false);
            }
        }
    }
}

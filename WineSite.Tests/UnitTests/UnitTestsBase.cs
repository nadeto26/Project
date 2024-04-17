using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WineSite.Data.Data;
using WineSite.Data.Data.Models;
using WineSite.Data.Data.SeedDb;
using WineSite.Tests.Mocks;
namespace WineSite.Tests.UnitTests
{
    public class UnitTestsBase
    {
        protected WineShopDbContext _db;
        protected IMapper _mapper;

        [OneTimeSetUp]
        public void SetUpBase()
        {
            _db = DatabaseMock.Instance;
             
            SeedDataBase();
        }

        public ApplicationUser GuestUser { get; private set; }
        public Wine Wine { get; private set; }
       

        private void SeedDataBase()
        {

            GuestUser = new ApplicationUser()
            {
                Id = "GuestId",
                Email = "gu@g.bg",
                FirstName = "Guest",
                LastName = "User"
            };
            _db.Users.Add(GuestUser);

            Wine = new Wine()
            {
                Id = 1,
                Name = "Био бялов вино Сицилианско",
                Type = new Data.Data.Models.Type { Name = "Бяло вино"},
                Year = 2020,
                Description = "Сицилианско био бяло вино от Защитен географски регион (IGP)\r\n\r\nГрило съживява зрелият, бледо жълт цвят с прекрасни златисти оттенъци, интензивно флорално усещане, прекрасно съчетано с аромати на цитрусови плодове. Плътно, сочно и богато, виното разкрива приятен и балансиран вкус и перфектна, хармонична свежест.  Линията Био се отличава с органично отгледано грозде, отсъствието на серен диоксид и на добавени сулфити.",
                ImageUrl = "https://i0.wp.com/coopwine.bg/wp-content/uploads/2022/10/%D0%91%D0%98%D0%9E-%D0%91%D0%AF%D0%9B%D0%9E-%D0%92%D0%98%D0%9D%D0%9E-%D0%93%D0%A0%D0%98%D0%9B%D0%9E-1.png?resize=768%2C494&ssl=1",
                Price = 9.99M,
                Country = "Италия",
                Manufucturer = "Cantine Sociale Paolini Societa Cooperativa Agricola – Marsala, Italy",
                Importer = "„Кооп-търговия и туризъм“  АД",
                Harvest = 2020,
                AlcoholContent = 12,
                Bottle = 750,
            };
            _db.Wines.Add(Wine);
        }

        [OneTimeTearDown]
        public void TearDownBase()
            =>_db.Dispose();
    }
}

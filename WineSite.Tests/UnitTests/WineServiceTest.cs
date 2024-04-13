using Type = WineSite.Data.Data.Models.Type;
using WineSite.Core.Contracts;
using WineSite.Core.Services;
using Moq;
using WineSite.Data.Data.Models;
using WineSite.Core.Models.Wine;
using System.Linq;
using static WineSite.Data.Data.Common.Constants;
using Wine = WineSite.Data.Data.Models.Wine;
using Microsoft.EntityFrameworkCore;

namespace WineSite.Tests.UnitTests
{
    [TestFixture]
    public class WineServiceTest:UnitTestsBase
    {
        private IWineServices wineServices;
        private IUserServices userServices;

        [OneTimeSetUp]
        public void SetUp()
        {
            this.userServices = new UserService(this._db);
            this.wineServices = new WineServices(this._db);
        }

        [Test]
        public async Task AllTypesNames_ShouldReturnCorrectResult()
        {
            // Arrange
            var result = await wineServices.AllTypesName();

            // Act
            var dbTypes = _db.Types;
            Assert.That(result.Count(), Is.EqualTo(dbTypes.Count()));

            // Assert
            var typesNames = dbTypes.Select(t => t.Name).ToList();
            foreach (var typeName in result)
            {
                Assert.That(typesNames.Contains(typeName), $"{typeName} is not found in the list of type names.");
            }
        }

        [Test]
        public async Task Exist_ShouldReturnCorrectTrue_WithValidId()
        {
            // Arrange
            var validWineId = 1;
            var wineServicesMock = new Mock<IWineServices>();
            wineServicesMock.Setup(m => m.Exist(validWineId)).ReturnsAsync(true);

            // Act
            var result = await wineServicesMock.Object.Exist(validWineId);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public async Task WineIdDetailsById_ShouldReturnCorrectWineData()
        {
            // Arrange
            var wineId = Wine.Id;
            var wineServicesMock = new Mock<IWineServices>();

            
            wineServicesMock.Setup(m => m.WineDetailsById(wineId)).ReturnsAsync(new WineDetailsSevicesModel { });

            // Act
            var result = await wineServicesMock.Object.WineDetailsById(wineId); // Извикваме метода

            // Assert
            Assert.IsNotNull(result, "Expected result not to be null for valid wineId.");
            
        }
        [Test]



        public async Task Edit_ShouldReturnCorrect()
        {
            // Създаване на обект wine без да го добавяме към контекста
            var wine = new Wine()
            {
                Name = "Био бялов вино Сицилианско",
                Year = 2020,
                Description = "Сицилианско био бяло вино от Защитен географски регион (IGP)\r\n\r\nГрило съживява зрелият, бледо жълт цвят с прекрасни златисти оттенъци, интензивно флорално усещане, прекрасно съчетано с аромати на цитрусови плодове. Плътно, сочно и богато, виното разкрива приятен и балансиран вкус и перфектна, хармонична свежест.  Линията Био се отличава с органично отгледано грозде, отсъствието на серен диоксид и на добавени сулфити.",
                ImageUrl = "https://i0.wp.com/coopwine.bg/wp-content/uploads/2022/10/%D0%91%D0%98%D0%9E-%D0%91%D0%AF%D0%9B%D0%9E-%D0%92%D0%98%D0%9D%D0%9E-%D0%93%D0%A0%D0%98%D0%9B%D0%9E-1.png?resize=768%2C494&ssl=1",
                Price = 9.99M,
                Country = "Италия",
                Manufucturer = "Cantine Sociale Paolini Societa Cooperativa Agricola – Marsala, Italy",
                Importer = "„Кооп-търговия и туризъм“  АД",
                Sort = "Grillo",
                Harvest = 2020,
                AlcoholContent = 12,
                Bottle = 750,
            };

            // Извикване на метода Edit
            var changedCountry = "София Италия";
            await wineServices.Edit(1, wine.Name, wine.TypeId, wine.Year, wine.ImageUrl, wine.Description,
                changedCountry, wine.Manufucturer, wine.Price, wine.Sort, wine.Harvest, wine.AlcoholContent,
                wine.Bottle, wine.Importer);

            // Проверка на промените в базата данни
            var newWineInDb = await _db.Wines.FindAsync(1);  
            Assert.IsNotNull(newWineInDb);
            Assert.That(newWineInDb.Name, Is.EqualTo(wine.Name));
            Assert.That(newWineInDb.Country, Is.EqualTo(changedCountry));  
        }



    }











}

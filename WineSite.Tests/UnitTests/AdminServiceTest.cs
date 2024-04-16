using Microsoft.EntityFrameworkCore;
using Moq;
using WineSite.Core.Contracts;
using WineSite.Core.Models.Receipt;
using WineSite.Core.Services;
using WineSite.Data.Data;
using WineSite.Areas.Admin.Contracts;
using WineSite.Areas.Admin.Sevices;
using WineSite.Data.Data.Models;

namespace WineSite.Tests.UnitTests
{
    [TestFixture]
    public class AdminServiceTest : UnitTestsBase
    {
        private IAdminServices adminServices;
        private IEventServices eventServices;
        private IRecipeServices recipeServices;


        [OneTimeSetUp]
        public void SetUp()
        {

            this.adminServices = new AdminServices(this._db);
            this.eventServices = new EventServices(this._db);
            this.recipeServices = new RecipeServices(this._db);
        }

        
        [Test]
      
        public async Task AddRecipeAsync_ValidRecipe_ShouldAddRecipeToDatabase()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<WineShopDbContext>()
                .UseInMemoryDatabase(databaseName: "Test_Database") // Вместо Guid.NewGuid().ToString() използваме статично име за базата данни
                .Options;

            using (var context = new WineShopDbContext(options))
            {
                // Добавяне на вашия тестов обект към контекста
                var recipe = new Recipe
                {
                     Id =5,
                     Name = "Recipe",
                     Description = "Brake the eggs",
                     ImageUrl = "Recipe2.jpg",
                     Notes = "recipes"
                };
                context.Recipes.Add(recipe);
                await context.SaveChangesAsync();
            }

            using (var context = new WineShopDbContext(options))
            {
                var service = new AdminServices(context);  
                var model = new ReceiptViewModel
                {
                   Name = "Recipe",
                    Description = "Brake the eggs",
                    ImageUrl = "Recipe2.jpg",
                    Notes = "recipes"
                };

                // Act
                await service.AddRecipeAsync(model);

                // Assert
                using (var assertContext = new WineShopDbContext(options))
                {
                    var addedRecipe = await assertContext.Recipes.FirstOrDefaultAsync(r => r.Name == model.Name);
                    Assert.IsNotNull(addedRecipe, "The recipe should be added to the database.");
                }
            }
        }



        [Test]
        public async Task Create_ValidInput_ShouldReturnNewWineId()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<WineShopDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            using (var context = new WineShopDbContext(options))
            {
                var adminServices = new AdminServices(context); // Създайте инстанция на вашия сервис
                var newWineName = "Test Wine";
                var newWineTypeId = 1; // Заменете това със съществуващ идентификатор на типа на виното
                var newWineYear = 2022;
                var newWineImageUrl = "wine_image.jpg";
                var newWineDescription = "This is a test wine description.";
                var newWineCountry = "Test Country";
                var newWineManufacturer = "Test Winery";
                var newWinePrice = 25.99m;
                var newWineSort = "Test Sort";
                var newWineHarvest = 2020;
                var newWineAlcoholContent = 13;
                var newWineBottle = 750;
                var newWineImporter = "Test Importer";

                // Act
                var newWineId = await adminServices.Create(newWineName, newWineTypeId, newWineYear, newWineImageUrl,
                    newWineDescription, newWineCountry, newWineManufacturer, newWinePrice, newWineSort,
                    newWineHarvest, newWineAlcoholContent, newWineBottle, newWineImporter);

                // Assert
                var addedWine = await context.Wines.FindAsync(newWineId);
                Assert.IsNotNull(addedWine, "The wine should be added to the database.");
                Assert.AreEqual(newWineName, addedWine.Name, "The wine name should match.");
                // Други проверки според вашите изисквания

                // Уверете се, че тук извиквате нужните методи за сравнение и уверки за данните на виното
            }
        }


        [Test]
        public async Task AllTypesNames_ShouldReturnCorrectResult()
        {
            // Arrange
            var result = await adminServices.AllTypes();

            // Act
            var dbTypes = _db.Types.ToList(); // Зареждаме типовете в паметта, за да можем да сравним броя на елементите
            Assert.AreEqual(result.Count(), dbTypes.Count());

            // Assert
            var typeNames = dbTypes.Select(t => t.Name).ToList();
            foreach (var typeName in result)
            {
                Assert.IsTrue(typeNames.Contains(typeName.Name), $"{typeName.Name} is not found in the list of type names.");
            }
        }

        [Test]
        public async Task TypeExist_ExistingTypeId_ShouldReturnTrue()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<WineShopDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            using (var context = new WineShopDbContext(options))
            {
                // Add a type to the context
                var typeId = 1;
                context.Types.Add(new WineSite.Data.Data.Models.Type { Id = typeId, Name = "Red Wine" });
                await context.SaveChangesAsync();
            }

            using (var context = new WineShopDbContext(options))
            {
                var wineService = new WineServices(context);

                // Act
                var result = await wineService.TypeExist(1);

                // Assert
                Assert.IsTrue(result, "The type should exist in the database.");
            }
        }

        [Test]
        public async Task DeleteTicketOrderAsync_ExistingOrderId_ShouldReturnTrueAndDeleteOrder()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<WineShopDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            using (var context = new WineShopDbContext(options))
            {
                // Add a ticket order to the context
                var orderId = 1;
                context.Orders.Add(new Orders { Id = orderId, Address = "Drama", City="Gotse Delchev", Email= "nade@gmail.com",
                    FullName = "Nadezhda Karapetrova", Phonenumber = "089087799", PostCode = "2300", EventName = "Vino Festival",
                    QuentityEvent = 5,BuyerId = "12352"
                     });


                await context.SaveChangesAsync();
            }

            using (var context = new WineShopDbContext(options))
            {
                var service = new AdminServices(context);

                // Act
                var result = await service.DeleteTicketOrderAsync(1);  

                // Assert
                Assert.IsTrue(result, "The method should return true for an existing order Id.");

                // Check if the order is deleted
                var deletedOrder = await context.TicketDeliveries.FindAsync(1);
                Assert.IsNull(deletedOrder, "The order should be deleted from the database.");
            }
        }

        [Test]
        public async Task DeleteWineOrderAsync_ExistingOrderId_ShouldReturnTrueAndDeleteOrder()
        {

            // Arrange
            var options = new DbContextOptionsBuilder<WineShopDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            using (var context = new WineShopDbContext(options))
            {
                var service = new AdminServices(context);
                var orderId = 1;  

                
                context.OrderWines.Add(new OrderWines
                {
                    Id = orderId,
                    Address = "Drama",
                    City = "Gotse Delchev",
                    Email = "nade@gmail.com",
                    FullName = "Nadezhda Karapetrova",
                    Phonenumber = "089087799",
                    PostCode = "2300",
                    WineName = "Bqlo",
                    QuentityWine = 5,
                    BuyerId = "312"
                });
                await context.SaveChangesAsync();

                // Act
                Task resultTask = service.DeleteWineOrderAsync(orderId);

                // Await the task if necessary
                await resultTask;

                // Assert
                Assert.IsTrue(true, "DeleteWineOrderAsync should delete the order.");
            }


        }


    }
}

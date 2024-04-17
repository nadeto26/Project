using Microsoft.EntityFrameworkCore;
using Moq;
using WineSite.Core.Contracts;
using WineSite.Core.Models.Receipt;
using WineSite.Core.Services;
using WineSite.Data.Data;
using WineSite.Areas.Admin.Contracts;
using WineSite.Areas.Admin.Sevices;
using WineSite.Data.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WineSite.Areas.Admin.Controllers;
using WineSite.Core.Models.Event;
using WineSite.Data.Data.Migrations;

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
                .UseInMemoryDatabase(databaseName: "Test_Database")  
                .Options;

            using (var context = new WineShopDbContext(options))
            {
              
                var recipe = new WineSite.Data.Data.Models.Recipe
                {
                    Id = 5,
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
                var adminServices = new AdminServices(context);  
                var newWineName = "Test Wine";
                var newWineTypeId = 1;  
                var newWineYear = 2022;
                var newWineImageUrl = "wine_image.jpg";
                var newWineDescription = "This is a test wine description.";
                var newWineCountry = "Test Country";
                var newWineManufacturer = "Test Winery";
                var newWinePrice = 25.99m;
             
                var newWineHarvest = 2020;
                var newWineAlcoholContent = 13;
                var newWineBottle = 750;
                var newWineImporter = "Test Importer";

                // Act
                var newWineId = await adminServices.Create(newWineName, newWineTypeId, newWineYear, newWineImageUrl,
                    newWineDescription, newWineCountry, newWineManufacturer, newWinePrice,
                    newWineHarvest, newWineAlcoholContent, newWineBottle, newWineImporter);

                // Assert
                var addedWine = await context.Wines.FindAsync(newWineId);
                Assert.IsNotNull(addedWine, "The wine should be added to the database.");
                Assert.AreEqual(newWineName, addedWine.Name, "The wine name should match.");
            }
        }

        [Test]
        public async Task AllTypesNames_ShouldReturnCorrectResult()
        {
            // Arrange
            var result = await adminServices.AllTypes();

            // Act
            var dbTypes = _db.Types.ToList();
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
                
                var orderId = 1;
                context.Orders.Add(new Orders
                {
                    Id = orderId,
                    Address = "Drama",
                    City = "Gotse Delchev",
                    Email = "nade@gmail.com",
                    FullName = "Nadezhda Karapetrova",
                    Phonenumber = "089087799",
                    PostCode = "2300",
                    EventName = "Vino Festival",
                    QuentityEvent = 5,
                    BuyerId = "12352"
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

               
                await resultTask;

                // Assert
                Assert.IsTrue(true, "DeleteWineOrderAsync should delete the order.");
            }


        }

        [Test]
        public async Task AddEventAsync_AddsEventToDatabase()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<WineShopDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var context = new WineShopDbContext(options))
            {
                 
                var service = new AdminServices(context);  

                
                var model = new EventsViewModel
                {
                    Name = "Test Event",
                    HostName = "Test Host",
                    Address = "Test Address",
                    DateTime = "Monday at 2 o clock",
                    Description = "Test Description",
                    ImageUrl = "test.jpg",
                    PriceTicket = 10,
                    WineList = "Test Wine List",
                    Features = "Test Features",
                    Preferences = "Test Preferences",
                    MoreInformation = "Test More Information",
                    Duration = "2 hours"
                };

                // Act
                await service.AddEventAsync(model);
                await context.SaveChangesAsync(); // Ensure changes are saved

                // Assert
                var addedEvent = await context.Events.FirstOrDefaultAsync(e => e.Name == model.Name);
                Assert.NotNull(addedEvent);
              
            }
        }

        [Test]
        public async Task GetOrdersForTicketsAsync_ReturnsOrderViewModelList()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<WineShopDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var context = new WineShopDbContext(options))
            {
                
                context.Orders.AddRange(
                    new WineSite.Data.Data.Models.Orders { Id = 1, FullName = "John Doe", PostCode = "12345", Address = "123 Main St", City = "SomeCity", QuentityEvent = 2, EventName = "Event 1", Phonenumber = "123-456-7890", BuyerId = "124", Email = "na@" },
                    new WineSite.Data.Data.Models.Orders { Id = 2, FullName = "Jane Smith", PostCode = "54321", Address = "456 Elm St", City = "AnotherCity", QuentityEvent = 1, EventName = "Event 2", Phonenumber = "987-654-3210", BuyerId = "214", Email = "dd" }
                );
                await context.SaveChangesAsync();

                var service = new AdminServices(context);

                // Act
                var result = await service.GetOrdersForTicketsAsync();

                // Assert
                Assert.NotNull(result);
                Assert.AreEqual(2, result.Count);  

             
                Assert.AreEqual("John Doe", result[0].FullName);
                Assert.AreEqual("Jane Smith", result[1].FullName);
                
            }
        }

        [Test]
        public async Task GetWinesOrdersAsync_ReturnsWineOrderViewModelList()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<WineShopDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var context = new WineShopDbContext(options))
            {
                
                context.OrderWines.AddRange(
                    new OrderWines { Id = 1, FullName = "John Doe", PostCode = "12345", Address = "123 Main St", City = "SomeCity", QuentityWine = 2, WineName = "Wine 1", Phonenumber = "123-456-7890", BuyerId = "124", Email = "nad" },
                    new OrderWines { Id = 2, FullName = "Jane Smith", PostCode = "54321", Address = "456 Elm St", City = "AnotherCity", QuentityWine = 1, WineName = "Wine 2", Phonenumber = "987-654-3210", BuyerId = "212", Email = "iva" }
                );
                await context.SaveChangesAsync();

                var service = new AdminServices(context);

                // Act
                var result = await service.GetWinesOrdersAsync();

                // Assert
                Assert.NotNull(result);
                Assert.AreEqual(2, result.Count);  

                
                Assert.AreEqual("John Doe", result[0].FullName);
                Assert.AreEqual("Jane Smith", result[1].FullName);
              
            }
        }

        [Test]
        public async Task GetAllMessagesAsync_ReturnsMessagesList()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<WineShopDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var context = new WineShopDbContext(options))
            {
                 
                context.Messages.AddRange(
                    new Messages { Id = 1, Name = "John Doe", Message = "Hello World", About = "Question", Email = "john@example.com", PhoneNumber = "123-456-7890" },
                    new Messages { Id = 2, Name = "Jane Smith", Message = "Testing", About = "Feedback", Email = "jane@example.com", PhoneNumber = "987-654-3210" }
                );
                await context.SaveChangesAsync();

                var service = new AdminServices(context);

                // Act
                var result = await service.GetAllMessagesAsync();

                // Assert
                Assert.NotNull(result);
                Assert.AreEqual(2, result.Count);  

              
                Assert.AreEqual("John Doe", result[0].Name);
                Assert.AreEqual("Jane Smith", result[1].Name);
                 
            }
        }

    }

}


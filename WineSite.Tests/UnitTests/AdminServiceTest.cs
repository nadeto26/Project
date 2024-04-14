using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WineSite.Core.Contracts;
using WineSite.Core.Models.Event;
using WineSite.Core.Models.Receipt;
using WineSite.Core.Services;
using WineSite.Data.Data;
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
        public async Task AddEventAsync_ValidEvent_ShouldAddEventToDatabase()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<WineShopDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var context = new WineShopDbContext(options))
            {
                var eventService = new AdminServices(context);
                var model = new EventsViewModel()
                {
                    Name = "Test Event",
                    HostName = "Test Host",
                    Address = "Test Address",
                    DateTime = "Monday at 8.00",
                    Description = "Test Description",
                    ImageUrl = "test.jpg",
                    PriceTicket = 20.99M,
                    WineList = "Test Wines",
                    Features = "Test Features",
                    Preferences = "Test Preferences",
                    MoreInformation = "Test More Info",
                    Duration = "120 min"
                };

                // Act
                await adminServices.AddEventAsync(model);

                // Assert
                var addedEvent = await context.Events.FirstOrDefaultAsync(e => e.Name == "Test Event");
                Assert.IsNotNull(addedEvent, "The event should be added to the database.");  
            }
        }
        [Test]
        public async Task AddRecipeAsync_ValidRecipe_ShouldAddRecipeToDatabase()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<WineShopDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var context = new WineShopDbContext(options))
            {
                var recipeService = new RecipeServices(context); // Проверете името на създадения сервис
                var model = new ReceiptViewModel()
                {
                    Name = "Test Recipe",
                    Notes = "Two eggs with bread",
                    Description = "break the eggs",
                    ImageUrl = "image.1",
                };

                // Act
                await adminServices.AddRecipeAsync(model); // Проверете името на метода за добавяне

                // Assert
                var addedRecipe = await context.Recipes.FirstOrDefaultAsync(e => e.Name == "Test Recipe");
                Assert.IsNotNull(addedRecipe, "The recipe should be added to the database.");
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
                var wineService = new WineServices(context);
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
                context.Entry(newWineId).State = EntityState.Detached;
                // Assert
                var addedWine = await context.Wines.FindAsync(newWineId);
                Assert.IsNotNull(addedWine, "The wine should be added to the database.");


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
                context.TicketDeliveries.Add(new TicketDelivery { Id = orderId, Address = "Drama", City="Gotse Delchev", Email= "nade@gmail.com",
                    FullName = "Nadezhda Karapetrova", PhoneNumber = "089087799", PostCode = "2300" 
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
                var orderId = 1; // Replace with an existing order id in your test database

                // Add a test order to the database
                context.WineDeliveries.Add(new WineDelivery { Id = orderId,
                    Address = "Drama",
                    City = "Gotse Delchev",
                    Email = "nade@gmail.com",
                    FullName = "Nadezhda Karapetrova",
                    PhoneNumber = "089087799",
                    PostCode = "2300"
                });
                await context.SaveChangesAsync();

                // Act
                var result = await service.DeleteWineOrderAsync(orderId);

                // Assert
                Assert.IsTrue(result, "DeleteWineOrderAsync should return true for an existing order.");

                // Check if the order is deleted
                var deletedOrder = await context.WineDeliveries.FindAsync(orderId);
                Assert.IsNull(deletedOrder, "The order should be deleted from the database.");
            }
        }





    }
}

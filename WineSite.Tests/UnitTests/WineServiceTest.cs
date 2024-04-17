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
using WineSite.Data.Data;
using WineSite.Data.Data.Migrations;
using WineDelivery = WineSite.Data.Data.Models.WineDelivery;

namespace WineSite.Tests.UnitTests
{
    [TestFixture]
    public class WineServiceTest : UnitTestsBase
    {
        private IWineServices wineServices;

        [OneTimeSetUp]
        public void SetUp()
        {

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
            var wineId = Wine.Id;

            // Act
            var result = await wineServices.Exist(wineId);

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
            var result = await wineServicesMock.Object.WineDetailsById(wineId);  

            // Assert
            Assert.IsNotNull(result, "Expected result not to be null for valid wineId.");

        }

        [Test]
        public async Task Edit_ShouldReturnCorrect()
        {
           
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
                Harvest = 2020,
                AlcoholContent = 12,
                Bottle = 750,
            };
               
            var changedCountry = "София Италия";
            await wineServices.Edit(1, wine.Name, wine.TypeId, wine.Year, wine.ImageUrl, wine.Description,
                changedCountry, wine.Manufucturer, wine.Price, wine.Harvest, wine.AlcoholContent,
                wine.Bottle, wine.Importer);
 
            var newWineInDb = await _db.Wines.FindAsync(1);
            Assert.IsNotNull(newWineInDb);
            Assert.That(newWineInDb.Name, Is.EqualTo(wine.Name));
            Assert.That(newWineInDb.Country, Is.EqualTo(changedCountry));
        }

        [Test]
        public async Task DeleteWineAsync_ExistingId_ShouldDeleteWineAndReturnTrue()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<WineShopDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var context = new WineShopDbContext(options))
            {
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
                    Harvest = 2020,
                    AlcoholContent = 12,
                    Bottle = 750,
                };

                context.Wines.Add(wine);
                await context.SaveChangesAsync();
            }

            using (var context = new WineShopDbContext(options))
            {
                var wineService = new WineServices(context);

                // Act
                var result = await wineService.DeleteWineAsync(1);

                // Assert
                Assert.IsTrue(result, "DeleteWineAsync should return true for an existing wine.");

                var deletedWine = await context.Wines.FindAsync(1);
                Assert.IsNull(deletedWine, "The wine with Id=1 should be deleted from the database.");
            }
        }

        [Test]
        public async Task AddWineToCartAsync_ValidWineIdAndUserId_ShouldAddToCartAndReturnTrue()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<WineShopDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var context = new WineShopDbContext(options))
            {
                var wine = new Wine()
                {
                    Id = 100, 
                    Name = "Био бялов вино Сицилианско",
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

                context.Wines.Add(wine);
                await context.SaveChangesAsync();
            }

            using (var context = new WineShopDbContext(options))
            {
                var wineService = new WineServices(context);

                // Act
                var result = await wineService.AddWineToCartAsync(100, "testuser");  

                // Assert
                Assert.IsTrue(result, "AddWineToCartAsync should return true for a valid wineId and userId.");

                var cartEntry = await context.WineBuyers.FirstOrDefaultAsync(e => e.WineId == 100 && e.BuyerId == "testuser");  
                Assert.IsNotNull(cartEntry, "The wine should be added to the user's cart.");
            }
        }

        [Test]
        public async Task GetUserWineAsync_ShouldReturnUserWines()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<WineShopDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var context = new WineShopDbContext(options))
            {
                var userId = "testuser";

              
                context.Wines.AddRange(
                    new Wine() { Id = 50, Name = "Wine 1", Price = 10, ImageUrl = "wine1.jpg", Country = "Country1", Description = "Description1", Importer = "Importer1", Manufucturer = "Manufacturer1" },
                    new Wine() { Id = 51, Name = "Wine 2", Price = 20, ImageUrl = "wine2.jpg", Country = "Country2", Description = "Description2", Importer = "Importer2", Manufucturer = "Manufacturer2"},
                    new Wine() { Id = 52, Name = "Wine 3", Price = 30, ImageUrl = "wine3.jpg", Country = "Country3", Description = "Description3", Importer = "Importer3", Manufucturer = "Manufacturer3"}
                );

                await context.SaveChangesAsync();

                context.WineBuyers.AddRange(
                    new Data.Data.Models.WineBuyers() { WineId = 50, BuyerId = userId },
                    new WineSite.Data.Data.Models.WineBuyers() { WineId = 51, BuyerId = userId },
                    new WineSite.Data.Data.Models.WineBuyers() { WineId = 52, BuyerId = userId }
                );

                await context.SaveChangesAsync();
            }

            using (var context = new WineShopDbContext(options))
            {
                var wineService = new WineServices(context);

                // Act
                var userWines = await wineService.GetUserWineAsync("testuser");

                // Assert
                Assert.IsNotNull(userWines, "The returned list should not be null.");
                Assert.AreEqual(6, userWines.Count, "The user should have 6 wines in the cart.");
                Assert.IsTrue(userWines.Any(w => w.Id == 50 && w.Name == "Wine 1" && w.Price == 10 && w.ImageUrl == "wine1.jpg"), "Wine 1 should be in the user's cart.");
                Assert.IsTrue(userWines.Any(w => w.Id == 51 && w.Name == "Wine 2" && w.Price == 20 && w.ImageUrl == "wine2.jpg"), "Wine 2 should be in the user's cart.");
                Assert.IsTrue(userWines.Any(w => w.Id == 52 && w.Name == "Wine 3" && w.Price == 30 && w.ImageUrl == "wine3.jpg"), "Wine 3 should be in the user's cart.");
            }
        }

        [Test]
        public async Task GetWineTypeId_WithValidId_ReturnsTypeId()
        {
            
            int wineId = 10;
            int expectedTypeId = 123;  

            
            var options = new DbContextOptionsBuilder<WineShopDbContext>()
                .UseInMemoryDatabase(databaseName: "Test_Db")
                .Options;
            using var dbContext = new WineShopDbContext(options);

          
            var wineToAdd = new Wine
            {
                Id = wineId,
                TypeId = expectedTypeId,
                Country = "Bulgaria",
                Harvest = 2020,
                AlcoholContent = 12,
                Bottle = 750,
                Description = "description",
                ImageUrl = "image.png",
                Importer = "Bulgaria",
                Manufucturer = "Germany",
                Name = "Wine",
                Price = 20,
                Year = 2020
            };
            dbContext.Wines.Add(wineToAdd);
            await dbContext.SaveChangesAsync();

           
            var wineService = new WineServices(dbContext);

           
            var actualTypeId = await wineService.GetWineTypeId(wineId);

           
            Assert.AreEqual(expectedTypeId, actualTypeId);
        }

        [Test]
        public async Task GetCartItemByIdAsync_WithValidId_ReturnsCartItem()
        {
            string cartItemId = "buyer"; 
            var expectedCartItem = new Data.Data.Models.WineBuyers
            {
                BuyerId = cartItemId,
                WineId = 2
            };

           
            var options = new DbContextOptionsBuilder<WineShopDbContext>()
                .UseInMemoryDatabase(databaseName: "Test_Db")
                .Options;
            using var dbContext = new WineShopDbContext(options);

           
            dbContext.WineBuyers.Add(expectedCartItem);
            await dbContext.SaveChangesAsync();

             
            var wineBuyersService = new WineServices(dbContext);

          
            var actualCartItem = await wineBuyersService.GetCartItemByIdAsync(expectedCartItem.BuyerId, expectedCartItem.WineId);

            
            Assert.NotNull(actualCartItem);
            Assert.AreEqual(expectedCartItem.BuyerId, actualCartItem.BuyerId);
        }

        [Test]
        public async Task RemoveWineFromCartAsync_ItemExists_RemovesItem()
        {
             
            string buyerId = "123";
            int wineId = 1;
            var cartItems = new[]
            {
            new Data.Data.Models.WineBuyers { BuyerId = buyerId, WineId = wineId },
            new Data.Data.Models.WineBuyers { BuyerId = "456", WineId = 2 }  
        };

            
            var options = new DbContextOptionsBuilder<WineShopDbContext>()
                .UseInMemoryDatabase(databaseName: "Test_Db")
                .Options;
            using var dbContext = new WineShopDbContext(options);

          
            await dbContext.WineBuyers.AddRangeAsync(cartItems);
            await dbContext.SaveChangesAsync();

            
            var wineService = new WineServices(dbContext);

            
            var result = await wineService.RemoveWineFromCartAsync(buyerId, wineId);

          
            Assert.True(result);  

           
            var remainingItem = await dbContext.WineBuyers.FirstOrDefaultAsync(ci => ci.BuyerId == buyerId && ci.WineId == wineId);
            Assert.Null(remainingItem);  
        }

        [Test]
        public async Task WineDeliveryAsyncValidDetailsAddsDeliveryToDb()
        {
            
            var deliveryDetails = new WineDeliveryDetailsViewModel
            {
                FullName = "John Doe",
                Address = "123 Main St",
                City = "Example City",
                PostalCode = "12345",
                PhoneNumber = "555-123-4567",
                Email = "user@example.com"
            };

            
            var options = new DbContextOptionsBuilder<WineShopDbContext>()
                .UseInMemoryDatabase(databaseName: "Test_Db")
                .Options;
            using var dbContext = new WineShopDbContext(options);

           
            var wineService = new WineServices(dbContext);

            
            await wineService.WineDeliveryAsync(deliveryDetails);

          
            var addedDelivery = await dbContext.WineDeliveries.FirstOrDefaultAsync();

            Assert.NotNull(addedDelivery); // Ensure a delivery was added
            Assert.AreEqual(deliveryDetails.FullName, addedDelivery.FullName);
            Assert.AreEqual(deliveryDetails.Address, addedDelivery.Address);
            Assert.AreEqual(deliveryDetails.City, addedDelivery.City);
            Assert.AreEqual(deliveryDetails.PostalCode, addedDelivery.PostCode);
            Assert.AreEqual(deliveryDetails.PhoneNumber, addedDelivery.PhoneNumber);
            Assert.AreEqual(deliveryDetails.Email, addedDelivery.Email);
        }

        [Test]
        public async Task ConfirmOrderAsync_ValidUserId_ConfirmsOrderAndClearsCart()
        {
            // Prepare test data
            string userId = "user123";
            var user = new Data.Data.Models.ApplicationUser { Id = userId, Email = "user@example.com", FirstName = "User", LastName = "Example" };
            var deliveryDetails = new Data.Data.Models.WineDelivery
            {
                FullName = "John Doe",
                Address = "123 Main St",
                City = "Example City",
                PostCode = "12345",
                PhoneNumber = "555-123-4567",
                Email = user.Email,

            };
            var cartEvents = new List<Data.Data.Models.WineBuyers>
        {
            new Data.Data.Models.WineBuyers { BuyerId = userId, WineId = 1, Quantity = 2, Wine = new Wine { Id = 1, Name = "Wine 1",Description= "The best wines", AlcoholContent = 12, Bottle= 750, Country = "Italy", Harvest = 2020, ImageUrl= "image.png", Importer= "Italy", Manufucturer = "Mn", Price=12, Year= 2020 } },
            new Data.Data.Models.WineBuyers { BuyerId = userId, WineId = 2, Quantity = 1, Wine = new Wine { Id = 2, Name = "Wine 2",Description= "The best wines", AlcoholContent = 12, Bottle= 750, Country = "Italy", Harvest = 2020, ImageUrl= "image.png", Importer= "Italy", Manufucturer = "Mn", Price=12, Year= 2020 } }
        };

             
            var options = new DbContextOptionsBuilder<WineShopDbContext>()
                .UseInMemoryDatabase(databaseName: "Test_Db")
                .Options;
            using var dbContext = new WineShopDbContext(options);
             

            await dbContext.Users.AddAsync(user);
            await dbContext.WineDeliveries.AddAsync(deliveryDetails);
            await dbContext.WineBuyers.AddRangeAsync(cartEvents);
            await dbContext.SaveChangesAsync();

         
            var wineService = new WineServices(dbContext);

            
            await wineService.ConfirmOrderAsync(userId);

          
            var ordersInDb = await dbContext.OrderWines.ToListAsync();
            var cartItemsInDb = await dbContext.WineBuyers.ToListAsync();

            Assert.IsNotEmpty(ordersInDb);  
            Assert.IsEmpty(cartItemsInDb);  
        }

        [Test]
        public async Task WineDeliveryAsync_ValidDetails_AddsDeliveryToDb()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<WineShopDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var context = new WineShopDbContext(options))
            {
                var wineService = new WineServices(context);

                var deliveryDetails = new WineDeliveryDetailsViewModel
                {
                    FullName = "John Doe",
                    Address = "123 Main St",
                    City = "City",
                    PostalCode = "12345",
                    PhoneNumber = "555-555-5555",
                    Email = "test@example.com"
                };

                // Act
                await wineService.WineDeliveryAsync(deliveryDetails);
            }

            // Assert
            using (var context = new WineShopDbContext(options))
            {
                Assert.AreEqual(1, await context.WineDeliveries.CountAsync());
                 
            }
        }
    }
}

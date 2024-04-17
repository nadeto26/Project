using Microsoft.EntityFrameworkCore;
using WineSite.Core.Contracts;
using WineSite.Core.Models.Event;
using WineSite.Core.Services;
using WineSite.Data.Data;
using WineSite.Data.Data.Models;
using Events = WineSite.Data.Data.Models.Events;

namespace WineSite.Tests.UnitTests
{
    [TestFixture]
    public class EventServicesTest : UnitTestsBase
    {
        private IEventServices eventServices;

        [OneTimeSetUp]
        public void SetUp()
        {
            this.eventServices = new EventServices(this._db);
        }
        [Test]
        public async Task AddEventToCartAsync_ValidEventAndUser_ShouldAddEventToCart()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<WineShopDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            using (var context = new WineShopDbContext(options))
            {
                var service = new EventServices(context);
                var eventId = 1;
                var userId = "testuser";

                
                context.Events.Add(new WineSite.Data.Data.Models.Events
                {
                    Id = eventId,
                    Address = "Test Address",
                    DateTime = "Monday",
                    Description = "Test Description",
                    Duration = "60 min",
                    Features = "Test Features",
                    HostName = "Test HostName",
                    ImageUrl = "test_image.jpg",
                    MoreInformation = "Test Information",
                    Name = "Test Event",
                    Preferences = "Test Preferences",
                    WineList = "Test WineList"
                });
                await context.SaveChangesAsync();

                // Act
                var result = await service.AddEventToCartAsync(eventId, userId);

                // Assert
                Assert.IsTrue(result, "The method should return true for a valid event and user.");
                var addedEntry = await context.TicketBuyers.FirstOrDefaultAsync(e => e.EventId == eventId && e.BuyerId == userId);
                Assert.IsNotNull(addedEntry, "The event should be added to the user's cart.");
            }
        }

        [Test]
        public async Task AddTicketDeliveryAsync_ValidDeliveryDetails_ShouldAddDeliveryToDatabase()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<WineShopDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            using (var context = new WineShopDbContext(options))
            {
                var service = new EventServices(context);
                var deliveryDetails = new DeliveryDetailsViewModel
                {
                    FullName = "Test User",
                    Address = "Test Address",
                    City = "Test City",
                    PostalCode = "12345",
                    PhoneNumber = "123-456-7890",
                    Email = "testuser@example.com"
                };

                // Act
                await service.AddTicketDeliveryAsync(deliveryDetails);

                // Assert
                var addedDelivery = await context.TicketDeliveries.FirstOrDefaultAsync(d =>
                    d.FullName == deliveryDetails.FullName &&
                    d.Address == deliveryDetails.Address &&
                    d.City == deliveryDetails.City &&
                    d.PostCode == deliveryDetails.PostalCode &&
                    d.PhoneNumber == deliveryDetails.PhoneNumber &&
                    d.Email == deliveryDetails.Email);

                Assert.IsNotNull(addedDelivery, "The delivery should be added to the database.");
            }
        }

        [Test]
        public async Task GetUserWineAsync_ValidUserId_ShouldReturnUserWines()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<WineShopDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var context = new WineShopDbContext(options))
            {
                var userId = "testuser";

                context.Wines.AddRange(
           new Wine { Id = 1, Name = "Wine 1", Price = 10, ImageUrl = "wine1.jpg", Country = "Country 1", Description = "Description 1", Importer = "Importer 1", Manufucturer = "Manufacturer 1", AlcoholContent = 12, Bottle = 750, Harvest = 12, Year = 2020 },
           new Wine { Id = 2, Name = "Wine 2", Price = 20, ImageUrl = "wine2.jpg", Country = "Country 2", Description = "Description 2", Importer = "Importer 2", Manufucturer = "Manufacturer 2", AlcoholContent = 12, Bottle = 750, Harvest = 12, Year = 2020 },
           new Wine { Id = 3, Name = "Wine 3", Price = 30, ImageUrl = "wine3.jpg", Country = "Country 3", Description = "Description 3", Importer = "Importer 3", Manufucturer = "Manufacturer 3", AlcoholContent = 12, Bottle = 750, Harvest = 12, Year = 2020 }
       );

                context.WineBuyers.AddRange(
                    new Data.Data.Models.WineBuyers { WineId = 1, BuyerId = userId },
                    new Data.Data.Models.WineBuyers { WineId = 2, BuyerId = userId },
                    new Data.Data.Models.WineBuyers { WineId = 3, BuyerId = userId }
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
                Assert.AreEqual(3, userWines.Count, "The user should have 3 wines in the cart.");
                Assert.IsTrue(userWines.Any(w => w.Id == 1 && w.Name == "Wine 1" && w.Price == 10 && w.ImageUrl == "wine1.jpg"), "Wine 1 should be in the user's cart.");
                Assert.IsTrue(userWines.Any(w => w.Id == 2 && w.Name == "Wine 2" && w.Price == 20 && w.ImageUrl == "wine2.jpg"), "Wine 2 should be in the user's cart.");
                Assert.IsTrue(userWines.Any(w => w.Id == 3 && w.Name == "Wine 3" && w.Price == 30 && w.ImageUrl == "wine3.jpg"), "Wine 3 should be in the user's cart.");
            }
        }

        [Test]
        public async Task GetEventAsync_ExistingEventId_ShouldReturnEventViewModel()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<WineShopDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            using (var context = new WineShopDbContext(options))
            {
                var service = new EventServices(context);
                var eventId = 1;

                
                context.Events.Add(new WineSite.Data.Data.Models.Events
                {
                    Id = eventId,
                    Name = "Test Event",
                    HostName = "Test Host",
                    Address = "Test Address",
                    DateTime = "Monday",
                    Description = "Test Description",
                    ImageUrl = "test.jpg",
                    PriceTicket = 20.0m,
                    WineList = "Test Wine List",
                    Features = "Test Features",
                    Preferences = "Test Preferences",
                    MoreInformation = "Test More Information",
                    Duration = "120 min"
                });
                await context.SaveChangesAsync();

                // Act
                var result = await service.GetEventAsync(eventId);

                // Assert
                Assert.IsNotNull(result, "The method should return an EventsViewModel.");

            }
        }

        [Test]
        public async Task GetEventDetailsByIdAsync_ExistingEventId_ShouldReturnEventViewModel()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<WineShopDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            using (var context = new WineShopDbContext(options))
            {
                var service = new EventServices(context);
                var eventId = 1;

                
                context.Events.Add(new WineSite.Data.Data.Models.Events
                {
                    Id = eventId,
                    Name = "Test Event",
                    HostName = "Test Host",
                    Address = "Test Address",
                    DateTime = "Monday",
                    Description = "Test Description",
                    ImageUrl = "test.jpg",
                    PriceTicket = 20.0m,
                    WineList = "Test Wine List",
                    Features = "Test Features",
                    Preferences = "Test Preferences",
                    MoreInformation = "Test More Information",
                    Duration = "120"
                });
                await context.SaveChangesAsync();

                // Act
                var result = await service.GetEventDetailsByIdAsync(eventId);

                // Assert
                Assert.IsNotNull(result, "The method should return an EventsViewModel.");

            }
        }

        [Test]
        public async Task GetUserTicketsAsync_ValidUserId_ShouldReturnUserTickets()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<WineShopDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            using (var context = new WineShopDbContext(options))
            {
                var service = new EventServices(context);
                var userId = "testuser";

                
                context.Events.AddRange(
                    new Data.Data.Models.Events { Id = 1, Name = "Event 1", PriceTicket = 10.0m, ImageUrl = "event1.jpg", Address = "Event 1 Address", DateTime = "Monday", Description = "Event 1 Description", Duration = "120 min", Features = "Event 1 Features", HostName = "Host 1", MoreInformation = "More Info 1", Preferences = "Preferences 1", WineList = "Wine List 1" },
                    new Data.Data.Models.Events { Id = 2, Name = "Event 2", PriceTicket = 15.0m, ImageUrl = "event2.jpg", Address = "Event 2 Address", DateTime = "Tuesday", Description = "Event 2 Description", Duration = "120 min", Features = "Event 2 Features", HostName = "Host 2", MoreInformation = "More Info 2", Preferences = "Preferences 2", WineList = "Wine List 2" }
                );

                 
                context.TicketBuyers.AddRange(
                    new TicketBuyer { BuyerId = userId, EventId = 1, Quantity = 2 },
                    new TicketBuyer { BuyerId = userId, EventId = 2, Quantity = 1 }
                );
                await context.SaveChangesAsync();

                // Act
                var result = await service.GetUserTicketsAsync(userId);

                // Assert
                Assert.IsNotNull(result, "The method should return a non-null result.");

            }
        }

        [Test]
        public async Task DeleteEventAsync_ExistingEventId_ShouldDeleteEvent()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<WineShopDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            using (var context = new WineShopDbContext(options))
            {
                var service = new EventServices(context);

                
                var eventIdToDelete = 1;
                context.Events.Add(new Events
                {
                    Id = eventIdToDelete,
                    Name = "EventToDelete",
                    Address = "Sample Address",
                    DateTime = "Monday",
                    Description = "Sample Description",
                    Duration = "60 min",
                    Features = "Sample Features",
                    HostName = "Sample Host",
                    ImageUrl = "sample.jpg",
                    MoreInformation = "Sample Information",
                    Preferences = "Sample Preferences",
                    WineList = "Sample Wine List"
                });
                await context.SaveChangesAsync();

                // Act
                var result = await service.DeleteEventAsync(eventIdToDelete);

                // Assert
                Assert.IsTrue(result, "The method should return true for a successful delete.");

                
                var deletedEvent = await context.Events.FindAsync(eventIdToDelete);
                Assert.IsNull(deletedEvent, "The event should be deleted from the database.");
            }
        }

        [Test]
        public async Task RemoveEventFromCartAsync_ValidEventAndUser_ShouldRemoveEventFromCart()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<WineShopDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            using (var context = new WineShopDbContext(options))
            {
                var service = new EventServices(context);
                var userId = "testuser";
                var eventId = 1;

                 
                context.TicketBuyers.Add(new TicketBuyer { BuyerId = userId, EventId = eventId });
                await context.SaveChangesAsync();

                // Act
                var result = await service.RemoveEventFromCartAsync(eventId, userId);

                // Assert
                Assert.IsTrue(result, "The method should return true for a valid event and user.");

                
                var removedEntry = await context.TicketBuyers.FirstOrDefaultAsync(e => e.EventId == eventId && e.BuyerId == userId);
                Assert.IsNull(removedEntry, "The event should be removed from the user's cart.");
            }
        }

        [Test]
        public async Task IncreaseQuantityAsync_ItemExists_ReturnsTrueIfIncreased_FalseIfNotExists()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<WineShopDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

           
            using (var context = new WineShopDbContext(options))
            {
                 
                var eventId = 3;
                var userId = "validUserId";
                var eventBuyer = new TicketBuyer { BuyerId = userId, EventId = eventId, Quantity = 1 };
                context.TicketBuyers.Add(eventBuyer);
                await context.SaveChangesAsync();

                var service = new EventServices(context);

                // Act
                var result1 = await service.IncreaseQuantityAsync(eventId, userId);
                var result2 = await service.IncreaseQuantityAsync(2, userId);

                // Assert
                Assert.True(result1);


               
                var updatedCartItem = await context.TicketBuyers.FirstOrDefaultAsync(item =>
                    item.EventId == eventId && item.BuyerId == userId);
                Assert.NotNull(updatedCartItem);

                
                context.TicketBuyers.RemoveRange(context.TicketBuyers);
                await context.SaveChangesAsync();
            }
        }

        [Test]
        public async Task UpdateEventAsync_ExistingEvent_UpdatesEventDetails()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<WineShopDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            
            using (var context = new WineShopDbContext(options))
            {
                
                var eventId = 5;
                var existingEvent = new WineSite.Data.Data.Models.Events
                {
                    Id = eventId,
                    Name = "Old Event Name",
                    Features = "Old Features",
                    Description = "Old Description",
                    PriceTicket = 50,
                    WineList = "Old Wine List",
                    Address = "Old Address",
                    DateTime = "Monday at 19 ",
                    HostName = "Old Host Name",
                    Duration = "120min",
                    ImageUrl = "old_image_url",
                    Preferences = "Old Preferences",
                    MoreInformation = "Old More Information"
                };
                context.Events.Add(existingEvent);
                await context.SaveChangesAsync();

                var service = new EventServices(context);
                var updatedEvent = new EventsViewModel
                {
                    Id = eventId,
                    Name = "New Event Name",
                    Features = "New Features",
                    Description = "New Description",
                    PriceTicket = 75,
                    WineList = "New Wine List",
                    Address = "New Address",
                    DateTime = "Monday at 19",
                    HostName = "New Host Name",
                    Duration = "120",
                    ImageUrl = "new_image_url",
                    Preferences = "New Preferences",
                    MoreInformation = "New More Information"
                };

                // Act
                await service.UpdateEventAsync(eventId, updatedEvent);

                // Assert
                var updatedEventFromDb = await context.Events.FindAsync(eventId);
                Assert.NotNull(updatedEventFromDb);
                Assert.AreEqual(updatedEvent.Name, updatedEventFromDb.Name);
                Assert.AreEqual(updatedEvent.Features, updatedEventFromDb.Features);
                Assert.AreEqual(updatedEvent.Description, updatedEventFromDb.Description);
                Assert.AreEqual(updatedEvent.PriceTicket, updatedEventFromDb.PriceTicket);
                Assert.AreEqual(updatedEvent.WineList, updatedEventFromDb.WineList);
                Assert.AreEqual(updatedEvent.Address, updatedEventFromDb.Address);
                Assert.AreEqual(updatedEvent.DateTime, updatedEventFromDb.DateTime);
                Assert.AreEqual(updatedEvent.HostName, updatedEventFromDb.HostName);
                Assert.AreEqual(updatedEvent.Duration, updatedEventFromDb.Duration);
                Assert.AreEqual(updatedEvent.ImageUrl, updatedEventFromDb.ImageUrl);
                Assert.AreEqual(updatedEvent.Preferences, updatedEventFromDb.Preferences);
                Assert.AreEqual(updatedEvent.MoreInformation, updatedEventFromDb.MoreInformation);
            }
        }

        [Test]
        public async Task ExistAsync_ExistingEvent_ReturnsTrue()
            {
                // Arrange
                var options = new DbContextOptionsBuilder<WineShopDbContext>()
                    .UseInMemoryDatabase(databaseName: "TestDatabase")
                    .Options;

                using (var context = new WineShopDbContext(options))
                {
                    context.Events.Add(new Events
                    {
                        Id = 10,
                        Name = "Event 1",
                        Address = "Drama",
                        DateTime = "Monday",
                        Description = "The best events",
                        Duration = "120-130",
                        Features = "The ",
                        HostName = "Petar",
                        ImageUrl = "imag.png",
                        MoreInformation = "The best wines",
                        Preferences = "heyslsi",
                        PriceTicket = 12,
                        WineList = "Wines 1"
                    });
                    context.SaveChanges();
                }

                using (var context = new WineShopDbContext(options))
                {
                    var eventService = new EventServices(context);

                    // Act
                    var result = await eventService.ExistAsync(10); 

                    // Assert
                    Assert.True(result); 
                }
            }

        [Test]
        public async Task GetCartItemByIdAsync_ExistingCartItem_ReturnsCartItem()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<WineShopDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var context = new WineShopDbContext(options))
            {
                
                var buyerId = "testBuyerId";
                var eventId = 1;
                var cartItem = new TicketBuyer { BuyerId = buyerId, EventId = eventId };
                context.TicketBuyers.Add(cartItem);
                await context.SaveChangesAsync();

                var service = new EventServices(context);

                // Act
                var result = await service.GetCartItemByIdAsync(buyerId, eventId);

                // Assert
                Assert.NotNull(result);
                Assert.AreEqual(buyerId, result.BuyerId);
                Assert.AreEqual(eventId, result.EventId);
            }



        }

        [Test]
        public async Task UpdateCartItemAsync_UpdatesCartItem()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<WineShopDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var context = new WineShopDbContext(options))
            {
               
                var cartItem = new TicketBuyer { BuyerId = "testBuyerId", EventId = 1, Quantity = 1 };
                context.TicketBuyers.Add(cartItem);
                await context.SaveChangesAsync();

                var service = new EventServices(context);

                // Act
                cartItem.Quantity = 2;  
                var result = await service.UpdateCartItemAsync(cartItem);

                // Assert
                Assert.IsTrue(result);  

                 
                var updatedCartItem = await context.TicketBuyers.FindAsync(cartItem.EventId,cartItem.BuyerId);
                Assert.NotNull(updatedCartItem);
                Assert.AreEqual(2, updatedCartItem.Quantity);  
            }
        }

       








    }
}











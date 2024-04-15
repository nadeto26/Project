using Microsoft.EntityFrameworkCore;
using NUnit.Framework.Internal.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WineSite.Core.Contracts;
using WineSite.Core.Models.Event;
using WineSite.Core.Services;
using WineSite.Data.Data;
using WineSite.Data.Data.Models;

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

                // Add the event to the database with required properties
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
           new Wine { Id = 1, Name = "Wine 1", Price = 10, ImageUrl = "wine1.jpg", Country = "Country 1", Description = "Description 1", Importer = "Importer 1", Manufucturer = "Manufacturer 1", Sort = "Sort 1",AlcoholContent = 12, Bottle=750,Harvest=12,Year = 2020 },
           new Wine { Id = 2, Name = "Wine 2", Price = 20, ImageUrl = "wine2.jpg", Country = "Country 2", Description = "Description 2", Importer = "Importer 2", Manufucturer = "Manufacturer 2", Sort = "Sort 2",AlcoholContent = 12, Bottle = 750, Harvest = 12, Year = 2020 },
           new Wine { Id = 3, Name = "Wine 3", Price = 30, ImageUrl = "wine3.jpg", Country = "Country 3", Description = "Description 3", Importer = "Importer 3", Manufucturer = "Manufacturer 3", Sort = "Sort 3", AlcoholContent = 12, Bottle = 750, Harvest = 12, Year = 2020 }
       );

                context.WineBuyers.AddRange(
                    new WineBuyers { WineId = 1, BuyerId = userId },
                    new WineBuyers { WineId = 2, BuyerId = userId },
                    new WineBuyers { WineId = 3, BuyerId = userId }
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

                // Add an event with the specified ID to the database
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

                // Add an event with the specified ID to the database
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

                // Add events to the database
                context.Events.AddRange(
                    new Events { Id = 1, Name = "Event 1", PriceTicket = 10.0m, ImageUrl = "event1.jpg", Address = "Event 1 Address", DateTime = "Monday", Description = "Event 1 Description", Duration = "120 min", Features = "Event 1 Features", HostName = "Host 1", MoreInformation = "More Info 1", Preferences = "Preferences 1", WineList = "Wine List 1" },
                    new Events { Id = 2, Name = "Event 2", PriceTicket = 15.0m, ImageUrl = "event2.jpg", Address = "Event 2 Address", DateTime = "Tuesday", Description = "Event 2 Description", Duration = "120 min", Features = "Event 2 Features", HostName = "Host 2", MoreInformation = "More Info 2", Preferences = "Preferences 2", WineList = "Wine List 2" }
                );

                // Add user tickets to the database
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

                // Add an event to the database
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

                // Check if the event is deleted from the database
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

                // Add a ticket buyer entry to the database
                context.TicketBuyers.Add(new TicketBuyer { BuyerId = userId, EventId = eventId });
                await context.SaveChangesAsync();

                // Act
                var result = await service.RemoveEventFromCartAsync(eventId, userId);

                // Assert
                Assert.IsTrue(result, "The method should return true for a valid event and user.");

                // Check if the entry is removed from the database
                var removedEntry = await context.TicketBuyers.FirstOrDefaultAsync(e => e.EventId == eventId && e.BuyerId == userId);
                Assert.IsNull(removedEntry, "The event should be removed from the user's cart.");
            }
        }


    }
}









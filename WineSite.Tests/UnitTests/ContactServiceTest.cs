using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WineSite.Areas.Admin.Contracts;
using WineSite.Areas.Admin.Sevices;
using WineSite.Core.Contracts;
using WineSite.Core.Models.Contact;
using WineSite.Core.Services;
using WineSite.Data.Data;

namespace WineSite.Tests.UnitTests
{
    [TestFixture]
    public class ContactServiceTest : UnitTestsBase
    {
        private IContactServices contactServices;
        


        [OneTimeSetUp]
        public void SetUp()
        {

            this.contactServices  = new ContactServices(this._db);
            
        }

        [Test]
        public async Task AddMessageAsync_WithValidModel_AddsMessageToDbContext()
        {
            // Подготовка на тестови данни
            var testData = new AddMessage
            {
                Name = "Test User",
                Email = "test@example.com",
                PhoneNumber = "1234567890",
                About = "Test About",
                Message = "Test Message"
            };

            // Настройка на DbContext за тестови цели с паметна база данни
            var options = new DbContextOptionsBuilder<WineShopDbContext>()
                .UseInMemoryDatabase(databaseName: "Test_Db")
                .Options;
            using var dbContext = new WineShopDbContext(options);

            // Инициализация на MessageService с тестовия DbContext
            var messageService = new ContactServices(dbContext);

            // Извикване на метода, който ще тестваме
            await messageService.AddMessageAsync(testData);

            // Проверка дали данните са добавени към DbContext
            var addedMessage = await dbContext.Messages.FirstOrDefaultAsync(m => m.Name == testData.Name);

            // Проверка за очакван резултат
            // Проверка за очакван резултат
            Assert.NotNull(addedMessage);
            Assert.AreEqual(testData.Email, addedMessage.Email);
            Assert.AreEqual(testData.PhoneNumber, addedMessage.PhoneNumber);
            Assert.AreEqual(testData.About, addedMessage.About);
            Assert.AreEqual(testData.Message, addedMessage.Message);

        }

    }
}

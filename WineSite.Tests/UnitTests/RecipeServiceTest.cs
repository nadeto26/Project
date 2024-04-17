using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WineSite.Core.Contracts;
using WineSite.Core.Models.Receipt;
using WineSite.Core.Services;
using WineSite.Data.Data;
using WineSite.Data.Data.Migrations;

namespace WineSite.Tests.UnitTests
{
    [TestFixture]
    public class RecipeServicesTest : UnitTestsBase
    {
        private IRecipeServices recipeServices;

        [OneTimeSetUp]
        public void SetUp()
        {
            this.recipeServices = new RecipeServices(this._db);
        }

        [Test]
        public async Task DeleteRecipeAsync_ExistingRecipeId_ShouldDeleteRecipe()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<WineShopDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            using (var context = new WineShopDbContext(options))
            {
                var service = new RecipeServices(context);

                // Add a recipe to the database
                var recipeIdToDelete = 1;
                context.Recipes.Add(new WineSite.Data.Data.Models.Recipe { Id = recipeIdToDelete, Name = "RecipeToDelete", Description = "Break the eggs", ImageUrl = "pic.img", Notes = "Break the eggs" });
                await context.SaveChangesAsync();

                // Act
                var result = await service.DeleteRecipeAsync(recipeIdToDelete);

                // Assert
                Assert.IsTrue(result, "The method should return true for a successful delete.");

                // Check if the recipe is deleted from the database
                var deletedRecipe = await context.Recipes.FindAsync(recipeIdToDelete);
                Assert.IsNull(deletedRecipe, "The recipe should be deleted from the database.");
            }
        }

        [Test]
        public async Task ExistAsync_ExistingRecipeId_ShouldReturnTrue()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<WineShopDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            using (var context = new WineShopDbContext(options))
            {
                var service = new RecipeServices(context);

                // Add a recipe to the database
                var recipeId = 1;
                context.Recipes.Add(new WineSite.Data.Data.Models.Recipe { Id = recipeId, Name = "RecipeToDelete", Description = "Break the eggs", ImageUrl = "pic.img", Notes = "Break the eggs" });
                await context.SaveChangesAsync();

                // Act
                var result = await service.ExistAsync(recipeId);

                // Assert
                Assert.IsTrue(result, "The method should return true for an existing recipe ID.");
            }
        }

        [Test]
        public async Task GetAllRecipesAsync_ShouldReturnAllRecipes()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<WineShopDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            using (var context = new WineShopDbContext(options))
            {
                var service = new RecipeServices(context);

                // Add some recipes to the database
                context.Recipes.AddRange(
                    new WineSite.Data.Data.Models.Recipe { Id = 1, Name = "Recipe1", Description = "Description1", ImageUrl = "image1.jpg", Notes = "Notes1" },
                    new WineSite.Data.Data.Models.Recipe { Id = 2, Name = "Recipe2", Description = "Description2", ImageUrl = "image2.jpg", Notes = "Notes2" }
                );
                await context.SaveChangesAsync();

                // Act
                var result = await service.GetAllRecipesAsync();

                // Assert
                Assert.AreEqual(2, result.Count, "The method should return all recipes.");
            }
        }

        [Test]
        public async Task GetRecipeAsync_ExistingRecipeId_ShouldReturnRecipeViewModel()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<WineShopDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            using (var context = new WineShopDbContext(options))
            {
                var service = new RecipeServices(context);

                // Add a recipe to the database
                var recipeId = 1;
                context.Recipes.Add(new WineSite.Data.Data.Models.Recipe { Id = recipeId, Name = "Test Recipe", Description = "Test Description", Notes = "Test Notes", ImageUrl = "test.jpg" });
                await context.SaveChangesAsync();

                // Act
                var result = await service.GetRecipeAsync(recipeId);

                // Assert
                Assert.IsNotNull(result, "The method should return a non-null RecipeViewModel.");
            }
        }

        [Test]
        public async Task GetRecipeDetailsByIdAsync_ExistingRecipeId_ShouldReturnAllRecipeViewModel()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<WineShopDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            using (var context = new WineShopDbContext(options))
            {
                var service = new RecipeServices(context);

                // Add a recipe to the database
                var recipeId = 1;
                context.Recipes.Add(new WineSite.Data.Data.Models.Recipe { Id = recipeId, Name = "Test Recipe", Description = "Test Description", Notes = "Test Notes", ImageUrl = "test.jpg" });
                await context.SaveChangesAsync();

                // Act
                var result = await service.GetRecipeDetailsByIdAsync(recipeId);

                // Assert
                Assert.IsNotNull(result, "The method should return a non-null AllRecipeViewModel.");
            }
        }

        [Test]

        public async Task UpdateRecipeAsync_ValidData_SuccessfullyUpdatesRecipe()
        {
            // Подготовка на тестови данни
            int recipeId = 1;
            var testRecipe = new ReceiptViewModel
            {
                Name = "Test Recipe",
                Notes = "Test Notes",
                Description = "Test Description",
                ImageUrl = "test.jpg"
            };

            // Настройка на DbContext за тестови цели с паметна база данни
            var options = new DbContextOptionsBuilder<WineShopDbContext>()
                .UseInMemoryDatabase(databaseName: "Test_Db")
                .Options;
            using var dbContext = new WineShopDbContext(options);

            // Добавяне на тестов рецепт в базата данни
            var recipeToAdd = new WineSite.Data.Data.Models.Recipe
            {
                Id = recipeId,
                Name = "Initial Name",
                Notes = "Initial Notes",
                Description = "Initial Description",
                ImageUrl = "initial.jpg"
            };
            dbContext.Recipes.Add(recipeToAdd);
            await dbContext.SaveChangesAsync();

            // Инициализация на RecipeService с тестовия DbContext
            var recipeService = new RecipeServices(dbContext);

            // Извикване на метода, който ще тестваме
            await recipeService.UpdateRecipeAsync(recipeId, testRecipe);

            // Проверка дали рецептът е актуализиран в базата данни
            var updatedRecipe = await dbContext.Recipes.FindAsync(recipeId);

            // Проверка за очакван резултат
            Assert.NotNull(updatedRecipe);
            Assert.AreEqual(testRecipe.Name, updatedRecipe.Name);
            Assert.AreEqual(testRecipe.Notes, updatedRecipe.Notes);
            Assert.AreEqual(testRecipe.Description, updatedRecipe.Description);
            Assert.AreEqual(testRecipe.ImageUrl, updatedRecipe.ImageUrl);

        }
    }
}


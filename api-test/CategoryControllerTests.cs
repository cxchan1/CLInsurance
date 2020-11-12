using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using api.Controllers;
using api.Models;
using Moq;
using Xunit;

namespace api_test
{
    public class CategoryControllerTests
    {
        #region snippet_CategoryControllerTests1
        [Fact]
        public async Task Create_GetCategoryTest_GivenNonExistingId()
        {
            var options = new DbContextOptionsBuilder<NudeDBContext>().UseInMemoryDatabase(databaseName: "NudeDB").Options;

            // Insert seed data into the database using one instance of the context
            using (var context = new NudeDBContext(options))
            {
                context.Categories.Add(new Category { id = 1, Name = "Clothing", Active = true });
                context.SaveChanges();
            }

            using (var context = new NudeDBContext(options))
            {
                CategoryController controller = new CategoryController(context);
                var result = await controller.GetCategory(2);
                Assert.Null(result.Value);
            }
        }
        #endregion

        #region snippet_CategoryControllerTests2
        [Fact]
        public async Task Create_GetCategoryTest_GivenExistingId()
        {
            var options = new DbContextOptionsBuilder<NudeDBContext>().UseInMemoryDatabase(databaseName: "NudeDB").Options;

            // Insert seed data into the database using one instance of the context
            using (var context = new NudeDBContext(options))
            {
                context.Categories.Add(new Category { id = 1, Name = "Clothing", Active = true });
                context.SaveChanges();
            }

            using (var context = new NudeDBContext(options))
            {
                CategoryController controller = new CategoryController(context);
                var result = await controller.GetCategory(1);
                Assert.NotNull(result.Value);
            }
        }
        #endregion

        #region snippet_CategoryControllerTests3
        [Fact]
        public void Create_GetCategoriesTest_WithNoData()
        {
            var options = new DbContextOptionsBuilder<NudeDBContext>().UseInMemoryDatabase(databaseName: "NudeDB").Options;

            using (var context = new NudeDBContext(options))
            {
                CategoryController controller = new CategoryController(context);
                var result = controller.GetCategories();
                Assert.Null(result.Result);
            }
        }
        #endregion

        #region snippet_CategoryControllerTests4
        [Fact]
        public void Create_GetCategoriesTest_WithExistingData()
        {
            var options = new DbContextOptionsBuilder<NudeDBContext>().UseInMemoryDatabase(databaseName: "NudeDB").Options;

            // Insert seed data into the database using one instance of the context
            using (var context = new NudeDBContext(options))
            {
                context.Categories.Add(new Category { id = 1, Name = "Clothing", Active = true });
                context.SaveChanges();
            }

            using (var context = new NudeDBContext(options))
            {
                CategoryController controller = new CategoryController(context);
                var result = controller.GetCategories();
                Assert.IsType<List<Category>>(result.Value);
            }
        }
        #endregion
    }
}

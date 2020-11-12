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
    public class ItemControllerTests
    {
        #region snippet_ItemControllerTests1
        [Fact]
        public async Task Create_GetItemTest_GivenNonExistingId()
        {
            var options = new DbContextOptionsBuilder<NudeDBContext>().UseInMemoryDatabase(databaseName: "NudeDB").Options;

            // Insert seed data into the database using one instance of the context
            using (var context = new NudeDBContext(options))
            {
                context.Categories.Add(new Category { id = 1, Name = "Electronic", Active = true });

                context.Items.Add(new Item { id = 1, CategoryId = 1, Name = "TV", Active = true, DateCreated = DateTime.Now, Price = 2000});
                context.SaveChanges();
            }

            using (var context = new NudeDBContext(options))
            {
                ItemController controller = new ItemController(context);
                var result = await controller.GetItem(2);
                Assert.Null(result.Value);
            }
        }
        #endregion

        #region snippet_ItemControllerTests2
        [Fact]
        public async Task Create_GetItemTest_GivenExistingId()
        {
            var options = new DbContextOptionsBuilder<NudeDBContext>().UseInMemoryDatabase(databaseName: "NudeDB").Options;

            // Insert seed data into the database using one instance of the context
            using (var context = new NudeDBContext(options))
            {
                context.Categories.Add(new Category { id = 1, Name = "Electronic", Active = true });

                context.Items.Add(new Item { id = 1, CategoryId = 1, Name = "TV", Active = true, DateCreated = DateTime.Now, Price = 2000 });
                context.SaveChanges();
            }

            using (var context = new NudeDBContext(options))
            {
                ItemController controller = new ItemController(context);
                var result = await controller.GetItem(1);
                Assert.NotNull(result.Value);
            }
        }
        #endregion

        #region snippet_ItemControllerTests3
        [Fact]
        public void Create_GetItemsTest_WithNoData()
        {
            var options = new DbContextOptionsBuilder<NudeDBContext>().UseInMemoryDatabase(databaseName: "NudeDB").Options;

            using (var context = new NudeDBContext(options))
            {
                ItemController controller = new ItemController(context);
                var result = controller.GetItems();
                Assert.Null(result.Result);
            }
        }
        #endregion

        #region snippet_ItemControllerTests4
        [Fact]
        public void Create_GetItemsTest_WithExistingsData()
        {
            var options = new DbContextOptionsBuilder<NudeDBContext>().UseInMemoryDatabase(databaseName: "NudeDB").Options;

            // Insert seed data into the database using one instance of the context
            using (var context = new NudeDBContext(options))
            {
                context.Categories.Add(new Category { id = 1, Name = "Electronic", Active = true });

                context.Items.Add(new Item { id = 1, CategoryId = 1, Name = "TV", Active = true, DateCreated = DateTime.Now, Price = 2000 });
                context.SaveChanges();
            }

            using (var context = new NudeDBContext(options))
            {
                ItemController controller = new ItemController(context);
                var result = controller.GetItems();
                Assert.Equal(1, (int)result.Value.Count());
            }
        }
        #endregion

        #region snippet_ItemControllerTests5
        [Fact]
        public async Task Create_CreateItemTest_WithBadRequest()
        {
            var options = new DbContextOptionsBuilder<NudeDBContext>().UseInMemoryDatabase(databaseName: "NudeDB").Options;

            using (var context = new NudeDBContext(options))
            {
                ItemController controller = new ItemController(context);

                Item test = new Item();

                var result = await controller.CreateItem(test);
                Assert.IsType<BadRequestResult>(result.Result);
            }
        }
        #endregion

        #region snippet_ItemControllerTests6
        [Fact]
        public async Task Create_CreateItemTest_WithGoodRequest()
        {
            var options = new DbContextOptionsBuilder<NudeDBContext>().UseInMemoryDatabase(databaseName: "NudeDB").Options;

            // Insert seed data into the database using one instance of the context
            using (var context = new NudeDBContext(options))
            {
                context.Categories.Add(new Category { id = 1, Name = "Electronic", Active = true });

                context.SaveChanges();
            }

            using (var context = new NudeDBContext(options))
            {
                ItemController controller = new ItemController(context);

                Item test = new Item();
                test.CategoryId = 1;
                test.Price = 200;
                test.Name = "TV";

                var result = await controller.CreateItem(test);
                Assert.IsType<CreatedAtActionResult>(result.Result);
            }
        }
        #endregion

        #region snippet_ItemControllerTests7
        [Fact]
        public async Task Create_DeleteItemTest_WithExistingsData()
        {
            var options = new DbContextOptionsBuilder<NudeDBContext>().UseInMemoryDatabase(databaseName: "NudeDB").Options;

            // Insert seed data into the database using one instance of the context
            using (var context = new NudeDBContext(options))
            {
                context.Categories.Add(new Category { id = 1, Name = "Electronic", Active = true });

                context.Items.Add(new Item { id = 1, CategoryId = 1, Name = "TV", Active = true, DateCreated = DateTime.Now, Price = 2000 });
                context.SaveChanges();
            }

            using (var context = new NudeDBContext(options))
            {
                ItemController controller = new ItemController(context);
                var result = await controller.DeleteItem(1);
                Assert.IsType<OkResult>(result);
            }
        }
        #endregion

        #region snippet_ItemControllerTests8
        [Fact]
        public async Task Create_DeleteItemTest_WithBadRequest()
        {
            var options = new DbContextOptionsBuilder<NudeDBContext>().UseInMemoryDatabase(databaseName: "NudeDB").Options;

            using (var context = new NudeDBContext(options))
            {
                ItemController controller = new ItemController(context);
                var result = await controller.DeleteItem(1);
                Assert.IsType<NotFoundResult>(result);
            }
        }
        #endregion
    }
}

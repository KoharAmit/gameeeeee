using GameHub.Controllers;
using GameHub.Data;
using GameHub.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHubTests
{
    [TestClass] // needed to indicate this file contains unit tests to be executed and evaluated
    public class ProductsControllerTests
    {
        private ApplicationDbContext _context;
        private ProductsController controller;

        // this is a special startup method that runs before each unit test
        // to avoid repeating arrange code, we can move it here so it always runs first
        [TestInitialize]
        public void TestInitialize()
        {
            // set up the in-memory db that's needed in every test
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            _context = new ApplicationDbContext(options);

            // create mock data in the in-memory db to unit test the ProductsController methods in the web app
            var category = new Category
            {
                CategoryId = 1000,
                Name = "Test Category"
            };
            _context.Add(category);

            for (var i = 1; i <=3; i++)
            {
                var product = new Product
                {
                    CategoryId = 1000,
                    Name = "Product " + i.ToString(),
                    Price = i + 10,
                    Category = category
                };
                _context.Add(product);
            }
            _context.SaveChanges();

            // create the controller instance in memory AFTER creating the db.  used by every test
            controller = new ProductsController(_context);
        }

        #region "Index"
        [TestMethod]
        public void IndexLoadsIndexView()
        {
            // arrange - pass the in-memory db instance as a dependency to the controller
            // now moved to TestInitialize
            //var controller = new ProductsController(_context);

            // act
            var result = (ViewResult)controller.Index().Result;

            // assert
            Assert.AreEqual("Index", result.ViewName);
        }

        [TestMethod]
        public void IndexLoadsProducts()
        {
            // arrange
            // now moved to TestInitialize
            //var controller = new ProductsController(_context);

            // act
            var result = (ViewResult)controller.Index().Result;
            List<Product> model = (List<Product>)result.Model;  // convert data to a list of products for comparison

            // assert
            CollectionAssert.AreEqual(_context.Products.ToList(), model);
        }
        #endregion

        #region "Details"
        [TestMethod]
        public void DetailsNoIdLoads404()
        {
            // arrange
            // now moved to TestInitialize
            //var controller = new ProductsController(_context);

            // act - call Details() without an id
            var result = (ViewResult)controller.Details(null).Result;

            // assert
            Assert.AreEqual("404", result.ViewName);
        }

        [TestMethod]
        public void DetailsNoProductsLoads404()
        {
            // arrange - remove the Products from the db 
            _context.Products = null;

            // act - pass in an Id
            var result = (ViewResult)controller.Details(1).Result;

            // assert
            Assert.AreEqual("404", result.ViewName);
        }

        [TestMethod]
        public void DetailsInvalidIdLoads404()
        {
            // act.  try any # > 3 as we used 1, 2, 3 as the in-memory db ProductId's
            var result = (ViewResult)controller.Details(4).Result;

            // assert
            Assert.AreEqual("404", result.ViewName);
        }

        [TestMethod]
        public void DetailsValidIdLoadsProduct()
        {
            // act.  try id 1, 2, or 3 as the in-memory db ProductId's
            var result = (ViewResult)controller.Details(2).Result;
            var model = (Product)result.Model;

            // assert
            Assert.AreEqual(_context.Products.Find(2), model);
        }

        [TestMethod]
        public void DetailsValidIdLoadsDetailsView()
        {
            // act.  try id 1, 2, or 3 as the in-memory db ProductId's
            var result = (ViewResult)controller.Details(2).Result;

            // assert
            Assert.AreEqual("Details", result.ViewName);
        }

        #endregion
    }
}

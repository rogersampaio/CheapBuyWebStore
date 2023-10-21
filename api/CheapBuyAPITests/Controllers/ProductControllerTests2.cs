//using CheapBuyAPI.Response;
//using CheapBuyAPI.Models;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.VisualStudio.TestTools.UnitTesting;

//namespace CheapBuyAPI.Controllers.Tests
//{
//    [TestClass()]
//    public class ProductControllerTests
//    {
//        public required DbContextOptions<CheapBuyDbContext> _options;

//        [TestInitialize()]
//        public void Initialize()
//        {
//            //TODO: Implement Repository Pattern to avoid using InMemoryDatabase Tests
//            //https://learn.microsoft.com/en-us/ef/core/testing/choosing-a-testing-strategy
//            _options = new DbContextOptionsBuilder<CheapBuyDbContext>()
//                .UseInMemoryDatabase(databaseName: "CheapBuy")
//                .Options;

//            AddInMemoryProducts();
//        }

//        [TestMethod()]
//        public void AddProductTest()
//        {
//            // Given
//            ProductDto newProduct = new()
//            {
//                ProductId = "TestId",
//                ProductName = "Test",
//                Price = 1,
//                BrandId = 1
//            };

//            // When
//            int expectedProducts;
//            using (var context = new CheapBuyDbContext(_options))
//            {
//                ProductController productController = new(context);
//                productController.PostProduct(newProduct);

//                expectedProducts = productController.GetAll().Count;
//            }

//            // Then
//            Assert.IsTrue(expectedProducts > 0);
//        }

//        [TestMethod()]
//        public void GetAllBrandsTest()
//        {
//            // Given

//            // When
//            int expectedBrands;
//            using (var context = new CheapBuyDbContext(_options))
//            {
//                BrandController brandController = new(context);
//                expectedBrands = brandController.GetAll().Count;
//            }
//            // Then
//            Assert.IsTrue(expectedBrands > 0);
//        }

//        [TestMethod()]
//        public void GetAllProductsTest()
//        {
//            // Given

//            // When
//            int expectedProducts;
//            using (var context = new CheapBuyDbContext(_options))
//            {
//                ProductController controller = new(context);
//                expectedProducts = controller.GetAll().Count;
//            }

//            // Then
//            Assert.IsTrue(expectedProducts > 0);
//        }

//        [TestMethod()]
//        public void DeleteProductTest()
//        {
//            // Given
//            using var context = new CheapBuyDbContext(_options);
//            ProductController controller = new(context);
//            int totalProductsBefore = controller.GetAll().Count;

//            // When
//            controller.DeleteProduct("1");
//            int totalProductsAfter = controller.GetAll().Count;

//            // Then
//            Assert.IsTrue(totalProductsBefore > totalProductsAfter);
//        }

//        private void AddInMemoryProducts()
//        {
//            using var context = new CheapBuyDbContext(_options);

//            if (!context.Brands.Any())
//            {
//                Brand brandApple = new() { Id = 1, Name = "Apple" };
//                Brand brandHP = new() { Id = 2, Name = "HP" };
//                Brand brandDell = new() { Id = 3, Name = "Dell" };
//                List<Product> products = new() {
//                    new Product(){
//                        Id = "1",
//                        Name = "Test1",
//                        Price = 1,
//                        BrandId = brandApple.Id,
//                    },
//                    new Product(){
//                        Id = "2",
//                        Name = "Test2",
//                        Price = 1,
//                        BrandId = brandHP.Id
//                    }
//                };
//                context.Brands.AddRange(new List<Brand> { brandApple, brandHP, brandDell });
//                context.Products.AddRange(products);
//                context.SaveChanges();
//            }
//        }
//    }

//}
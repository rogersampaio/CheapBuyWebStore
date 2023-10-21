using CheapBuyDB.Interfaces;
using CheapBuyDB.Models;
using CheapBuyAPI.Response;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Linq.Expressions;

namespace CheapBuyAPI.Controllers.Tests
{
    [TestClass()]
    public class ProductControllerTests
    {
        public required Mock<ICheapBuyRepository<Product>> _productRepositoryMock;
        public required Mock<ICheapBuyRepository<Brand>> _brandRepositoryMock;

        [TestInitialize()]
        public void Initialize()
        {
            _productRepositoryMock = new Mock<ICheapBuyRepository<Product>>();
            _brandRepositoryMock = new Mock<ICheapBuyRepository<Brand>>();

            _productRepositoryMock.Setup(x =>
                x.Get(
                    It.IsAny<Expression<Func<Product, bool>>>(),
                    It.IsAny<Func<IQueryable<Product>, IOrderedQueryable<Product>>>(),
                    It.IsAny<string>()
                )).Returns(CreateFakeProducts().AsEnumerable());

            _brandRepositoryMock.Setup(x =>
               x.Get(
                   It.IsAny<Expression<Func<Brand, bool>>>(),
                   It.IsAny<Func<IQueryable<Brand>, IOrderedQueryable<Brand>>>(),
                   It.IsAny<string>()
               )).Returns(CreateFakeBrands().AsEnumerable());
        }

        [TestMethod()]
        public void AddProductTest()
        {
            // Given
            ProductRequest response = new()
            {
                ProductId = "TestId",
                ProductName = "Test",
                Price = 1,
                BrandId = 1
            };

            // When
            int expectedProducts;

            ProductController productController = new(_productRepositoryMock.Object);
            productController.PostProduct(response);

            expectedProducts = productController.GetAll().Count;

            // Then
            Assert.IsTrue(expectedProducts > 0);
        }

        [TestMethod()]
        public void GetAllBrandsTest()
        {
            // Given

            // When
            int expectedBrands;
            BrandController brandController = new(_brandRepositoryMock.Object);
            expectedBrands = brandController.GetAll().Count;
            // Then
            Assert.IsTrue(expectedBrands > 0);
        }

        [TestMethod()]
        public void GetAllProductsTest()
        {
            // Given

            // When
            int expectedProducts;
            ProductController controller = new(_productRepositoryMock.Object);
            expectedProducts = controller.GetAll().Count;

            // Then
            Assert.IsTrue(expectedProducts > 0);
        }

        [TestMethod()]
        public void DeleteProductTest()
        {
            // Given
            ProductController controller = new(_productRepositoryMock.Object);
            int totalProductsBefore = controller.GetAll().Count;

            // When
            controller.DeleteProduct("1");
            int totalProductsAfter = controller.GetAll().Count;

            // Then
            Assert.IsTrue(totalProductsBefore > totalProductsAfter);
        }

        private List<Product> CreateFakeProducts()
        {
            Brand brandApple = new() { Id = 1, Name = "Apple" };
            Brand brandHP = new() { Id = 2, Name = "HP" };
            Brand brandDell = new() { Id = 3, Name = "Dell" };
            return [
                new Product()
                {
                    Id = "1",
                    Name = "Test1",
                    Price = 1,
                    BrandId = brandApple.Id,
                },
                new Product()
                {
                    Id = "2",
                    Name = "Test2",
                    Price = 1,
                    BrandId = brandHP.Id
                }
            ];
        }

        private List<Brand> CreateFakeBrands()
        {
            Brand brandApple = new() { Id = 1, Name = "Apple" };
            Brand brandHP = new() { Id = 2, Name = "HP" };
            Brand brandDell = new() { Id = 3, Name = "Dell" };
            return [brandApple, brandHP, brandDell];
        }
    }

}
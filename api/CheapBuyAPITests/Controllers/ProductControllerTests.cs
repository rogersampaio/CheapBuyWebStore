using CheapBuyAPI.Response;
using CheapBuyDB.Interfaces;
using CheapBuyDB.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Linq.Expressions;

namespace CheapBuyAPI.Controllers.Tests
{
    [TestClass()]
    public class ProductControllerTests
    {
        public required Mock<ICheapBuyRepository<Product>> _productRepositoryMock;

        [TestInitialize()]
        public void Initialize()
        {
            _productRepositoryMock = new Mock<ICheapBuyRepository<Product>>();

            _productRepositoryMock.Setup(x =>
                x.Get(
                    It.IsAny<Expression<Func<Product, bool>>>(),
                    It.IsAny<Func<IQueryable<Product>, IOrderedQueryable<Product>>>(),
                    It.IsAny<string>()))
                .Returns(CreateFakeProducts().AsEnumerable());

            _productRepositoryMock.Setup(x =>
                x.GetById(It.IsAny<object>()))
                .Returns(CreateFakeProducts()[0]);

            _productRepositoryMock.Setup(x =>
                x.GetById("TestNew"))
                .Returns(value: null);
        }

        [TestMethod()]
        public void AddNewProductTest()
        {
            // Given
            ProductRequest response = new()
            {
                ProductId = "TestNew",
                ProductName = "TestNew",
                Price = 2,
                BrandId = 2
            };
            ProductController productController = new(_productRepositoryMock.Object);

            // When
            productController.PostProduct(response);

            // Then
            _productRepositoryMock.Verify(x => x.SaveChanges(), Times.Once());
        }

        [TestMethod()]
        public void AddExistingProductTest()
        {
            // Given
            ProductRequest response = new()
            {
                ProductId = "TestExisting",
                ProductName = "TestExisting",
                Price = 1,
                BrandId = 1
            };
            string exceptionMessage = "";
            ProductController productController = new(_productRepositoryMock.Object);

            // When
            try
            {
                productController.PostProduct(response);
            }
            catch (Exception ex)
            {
                exceptionMessage = ex.Message;
            }
            
            // Then
            _productRepositoryMock.Verify(x => x.SaveChanges(), Times.Never());
            Assert.AreEqual("Product already exist", exceptionMessage);
        }

        [TestMethod()]
        public void GetAllProductsTest()
        {
            // Given
            ProductController controller = new(_productRepositoryMock.Object);
            
            // When
            int expectedProducts = controller.GetAll().Count;

            // Then
            Assert.IsTrue(expectedProducts > 0);
        }

        [TestMethod()]
        public void DeleteProductTest()
        {
            // Given
            ProductController controller = new(_productRepositoryMock.Object);

            // When
            controller.DeleteProduct("1");

            // Then
            _productRepositoryMock.Verify(x => x.SaveChanges(), Times.Once());
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
    }

}
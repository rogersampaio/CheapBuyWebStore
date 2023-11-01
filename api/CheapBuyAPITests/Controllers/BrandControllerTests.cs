using CheapBuyDB.Interfaces;
using CheapBuyDB.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Linq.Expressions;

namespace CheapBuyAPI.Controllers.Tests
{
    [TestClass()]
    public class BrandControllerTests
    {
        public required Mock<ICheapBuyRepository<Brand>> _brandRepositoryMock;

        [TestInitialize()]
        public void Initialize()
        {
            _brandRepositoryMock = new Mock<ICheapBuyRepository<Brand>>();

            _brandRepositoryMock.Setup(x =>
               x.Get(
                   It.IsAny<Expression<Func<Brand, bool>>>(),
                   It.IsAny<Func<IQueryable<Brand>, IOrderedQueryable<Brand>>>(),
                   It.IsAny<string>()
               )).Returns(CreateFakeBrands().AsEnumerable());
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

        private List<Brand> CreateFakeBrands()
        {
            Brand brandApple = new() { Id = 1, Name = "Apple" };
            Brand brandHP = new() { Id = 2, Name = "HP" };
            Brand brandDell = new() { Id = 3, Name = "Dell" };
            return [brandApple, brandHP, brandDell];
        }
    }

}
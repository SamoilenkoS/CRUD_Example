using System.Collections.Generic;
using System.Threading.Tasks;
using CRUD_ASP_API.Services;
using CRUD_DAL.Entities;
using CRUD_DAL.InsightDB;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace CRUD_Tests
{
    public class ProductServiceTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task Get_Test()
        {
            var dbMock = new Mock<IDbContext>();
            ProductService productService = new ProductService(dbMock.Object);
            var expected = new List<Product>
            {
                new Product
                {
                    Id = 1,
                    Price = 10,
                    Title = "Test"
                },
                new Product
                {
                    Id = 2,
                    Price = 5.5,
                    Title = "QQQ"
                },
            };
            dbMock.Setup(db => db.ProductRepository.GetAllProductsAsync())
                .ReturnsAsync(expected);

            var actual = await productService.GetAllProductsAsync();

            actual.Should().BeEquivalentTo(expected);
        }

        [Test]
        public async Task Add_Test()
        {
            var dbMock = new Mock<IDbContext>();
            ProductService productService = new ProductService(dbMock.Object);
            dbMock.Setup(db
                => db.ProductRepository.AddProductAsync(It.IsAny<Product>()))
                .Verifiable();

            await productService.AddProductAsync(new Product());

            dbMock.Verify();
        }
    }
}
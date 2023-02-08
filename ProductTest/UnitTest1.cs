using AutoFixture;
using Mango.Services.ProductAPI.Controllers;
using Mango.Services.ProductAPI.Models;
using Mango.Services.ProductAPI.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections;
using System.Threading.Tasks;

namespace ProductTest
{
    public class ProductAPITest
    {
        private readonly Mock <ProductRepository> _sut;
        private readonly Mock<ProductDto> produsctCreqte;
        private readonly Mock<IProductRepository> _productRepositoryMock = new Mock<IProductRepository>();
        private readonly Fixture _fixture= new();
        [Fact]
        public ProductAPITest()
        {
            _sut = new Mock<ProductRepository>(_productRepositoryMock.Object)
            { CallBase = true }

            ;

            produsctCreqte= new Mock<ProductDto>();
        }
       public async Task GetProductById_Should_Return_True()
        {
            //Arrange
            var productId = 1;
            int count = _fixture.Create<int>();
            var s = _fixture.CreateMany<IList>();
            string productCreate= _fixture.Create<string>();

            _sut.Setup(s => s.GetProductById(productId));
            _sut.Verify(s => s.CreateUpdateProduct(produsctCreqte.Object));
            _sut.Setup(s => s.GetProductById(productId));



            // Act
            var actual = _sut.Object.CreateUpdateProduct(produsctCreqte.Object);
            //Assert
            Assert.AreEqual("saim", actual);
            

        }
    }
}
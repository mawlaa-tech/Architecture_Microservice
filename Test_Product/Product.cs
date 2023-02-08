using Mango.Services.ProductAPI.Repository;
using Mango.Services.ProductAPI.Models;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;
using FluentAssertions;

namespace Test_Product
{
    public class Product
    {
        private readonly Mock<IProductRepository> _productRepository;


        public Product()
        {
            _productRepository = new Mock<IProductRepository>(MockBehavior.Strict);
        }
        [Test]
        public void CanGetProduct()
        {
            List<ProductDto> list = new()
            {
                new ProductDto()
                {
                    ProductId = 1,
                    Name = "Samosa",
                    Price = 15,
                    Description = "Praesent scelerisque, magna vehicula sagittis ut non Phasellus commodo cursus pretium.",
                    CategoryName = "Appetizer",
                    ImageUrl = "https://salimmawlaa.blob.core.windows.net/mango/1.jpg"
                }
            };

           
            list.Count.Should().Be(1);

            _productRepository.Setup(p => p.GetProducts()).Returns(It.IsAny<Task<IEnumerable<ProductDto>>>);

            _productRepository.Verify(p => p.GetProducts(), Times.Never);
        }

        [Test]
        public  void CanGetOneProduct()
        {
            //arrange
             var  productId = It.IsAny<int>();
            _productRepository.Setup(p => p.GetProductById(It.IsAny<int>())).Returns(It.IsAny<Task<ProductDto>>());

            //assert
            _productRepository.Verify(p => p.GetProductById(productId), Times.Never);

        }

        [Test]
        public void CanCreateProduct()
        {
            //arrange
            ProductDto productDto = It.IsAny<ProductDto>();
            _productRepository.Setup(p => p.CreateUpdateProduct(productDto)).Returns(It.IsAny<Task<ProductDto>>());

            //assert
            _productRepository.Verify(p => p.CreateUpdateProduct(productDto), Times.Never);
        }
        [Test]
        public void CanDeleteProduct()
        {
            //arrange
            int productId=It.IsAny<int>();
            _productRepository.Setup(p => p.Delete(productId)).Returns(It.IsAny<Task<bool>>);

            //assert

            _productRepository.Verify(p => p.Delete(It.IsAny<int>()),Times.AtLeastOnce);
           

        }
        
        [Test]
        public void CangetProduct_Null()
        {
            
        }

    }
}
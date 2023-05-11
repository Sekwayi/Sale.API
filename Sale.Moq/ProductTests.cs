using Moq;
using Sale.API.Controllers;
using Sale.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sale.Moq
{
    public class ProductTests
    {
        private readonly ProductController _sut;
        private readonly Mock<IRepositoryWrapper> _repoProductMock = new Mock<IRepositoryWrapper>();

        public ProductTests()
        {
            _sut = new ProductController(_repoProductMock.Object);
        }

        [Fact]
        public void GetById_ReturnsProduct() 
        {
            //Arrange
            var productId = new int();
            var name = "Machine";
            var supplier = "Tesla";
            var supplierId = new int();

            var pro = new Entities.Models.Product
            {
                ProductId = productId,
                ProductName = name,
                ProductSupplier = supplier,
                SupplierId = supplierId
            };
            _repoProductMock.Setup(x => x.ProductRepository.FindById(x => x.ProductId == productId))
                .Returns(pro);
            //Act
            var product = _sut.GetById(productId);
            //Assert
            Assert.Equal(productId, pro.ProductId);
            Assert.Equal(name, pro.ProductName);
            Assert.Equal(supplierId, pro.SupplierId);
        }
    }
}

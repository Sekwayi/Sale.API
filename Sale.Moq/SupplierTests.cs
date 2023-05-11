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
    public class SupplierTests
    {
        private readonly SupplierController _sut;
        private readonly Mock<IRepositoryWrapper> _supplierRepoMock = new Mock<IRepositoryWrapper>();
        public SupplierTests()
        {
            _sut = new SupplierController(_supplierRepoMock.Object);
        }
        [Fact]
        public void GetById_ReturnSupplier()
        {
            //Arrange
            var supplierId = new int();
            var name = "Tesla";

            var sup = new Entities.Models.Supplier
            {
                SupplierId = supplierId,
                SupplierName = name
            };

            _supplierRepoMock.Setup(x => x.SupplierRepository.FindById(x => x.SupplierId == supplierId))
                .Returns(sup);
            //Act
            var supplier = _sut.GetById(supplierId);
            //Assert
            Assert.Equal(supplierId, sup.SupplierId);
            Assert.Equal(name, sup.SupplierName);
        }
    }
}

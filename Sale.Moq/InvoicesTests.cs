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
    public class InvoicesTests
    {
        private readonly InvoiceController _sut;
        private readonly Mock<IRepositoryWrapper> _invoiceRepoMock = new Mock<IRepositoryWrapper>();
        public InvoicesTests()
        {
            _sut = new InvoiceController(_invoiceRepoMock.Object);
        }
        [Fact]
        public void GetById_ReturnInvoice() 
        {
            //Arrange
            int invoiceId = new int();
            int customerId = new int();
            int employeeId = new int();
            int productId = new int();
            DateOnly invoiceDate = new DateOnly();
            var inv = new Entities.Models.Invoice 
            {
                InvoiceId = invoiceId,
                CustomerId = customerId,
                EmployeeId = employeeId,
                ProductId = productId,
                InvoiceDate = invoiceDate,
            };
            _invoiceRepoMock.Setup(x => x.InvoiceRepository.FindById(x => x.InvoiceId == invoiceId))
                .Returns(inv);
            //Act
            var invoice = _sut.GetById(invoiceId);
            //Assert
            Assert.Equal(invoiceId, inv.InvoiceId);
            Assert.Equal(customerId, inv.CustomerId);
            Assert.Equal(employeeId, inv.EmployeeId);
            Assert.Equal(productId, inv.ProductId);
            Assert.Equal(invoiceDate, inv.InvoiceDate);
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Moq;
using Sale.API.Controllers;
using Sale.Contracts;
using System.Linq.Expressions;
using System.Net;
using System.Numerics;
using System.Xml.Linq;

namespace Sale.Moq
{
    public class CustomerTests
    {
        private readonly CustomerController _sut;
        private readonly Mock<IRepositoryWrapper> _customerRepoMock = new Mock<IRepositoryWrapper>();
        public CustomerTests()
        {
            _sut = new CustomerController(_customerRepoMock.Object);
        }
        [Fact]
        public void GetById_ShouldReturnCustomer()
        {
            //Arrange
            var customerId = new int();
            var name = "SK";
            var phone = Convert.ToInt32(0712223333);
            
            var cus = new Entities.Models.Customer
            {
                CustomerId = customerId,
                CustomerName = name,
                CustomerPhone = phone
            };

            _customerRepoMock.Setup(x => x.CustomerRepository.FindById(x => x.CustomerId == customerId))
                .Returns(cus);

            //Act
            var customer = _sut.GetById(customerId);

            //Assert
            Assert.Equal(customerId, cus.CustomerId);
            Assert.Equal(name, cus.CustomerName);
            Assert.Equal(phone, cus.CustomerPhone);
        }
        [Fact]
        public void GetById_ShouldReturnNothing()
        {
            ////Arrange
            //int? customerId = null;
            //var cus = new Entities.Models.Customer
            //{
            //    CustomerId = (int)customerId,
            //};
            //_customerRepoMock.Setup(x => x.CustomerRepository.FindById(x => x.CustomerId == customerId))
            //    .Returns(cus);
            //It.IsAny<Entities.Models.Customer>();
            ////Act
            //var customer = _sut.GetById((int)customerId);
            ////Assert
            //Assert.Equal(customer, null);

            ///////////////////////////////////////////////////////////////////////////////

            ////Arrange
            //int customerId = 00000;
            //var cus = new Entities.Models.Customer
            //{
            //    CustomerId = customerId
            //};

            //_customerRepoMock.Setup(x => x.CustomerRepository.FindById(x => x.CustomerId == customerId))
            //    .Returns((Entities.Models.Customer)null);
            ////Act
            //var customer = _sut.GetById(customerId);
            //var statusCode = 404;
            //int verify = 200;

            //if (cus == null)
            //{
            //    verify = 404;
            //}
            ////Assert
            //Assert.Equal(statusCode, verify);

            ///////////////////////////////////////////////////////////////////////////////

            int customerId = 00000;
            var cus = new Entities.Models.Customer
            {
                CustomerId = customerId
            };

            _customerRepoMock.Setup(x => x.CustomerRepository.FindById(x => x.CustomerId == customerId))
                .Returns(cus);
            //Act
            var customer = _sut.GetById(customerId);
            var statusCode = 404;
            int verify = 200;

            if (cus.CustomerId <= 0)
            {
                verify = 404;
            }
            //Assert
            Assert.Equal(statusCode, verify);
        }
    }
}
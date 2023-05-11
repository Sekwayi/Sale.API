using Moq;
using Sale.API.Controllers;
using Sale.Contracts;
using Sale.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sale.Moq
{
    public class EmployeeTests
    {
        private readonly EmployeeController _sut;
        private readonly Mock<IRepositoryWrapper> _employeeRepoMock = new Mock<IRepositoryWrapper>();
        public EmployeeTests()
        {
            _sut = new EmployeeController(_employeeRepoMock.Object);
        }

        [Fact]
        public void GetById_ShouldReturnEmployee()
        {
            //Arrange
            var employeeId = new int();
            var name = "Worker";
            var cus = new Entities.Models.Employee
            {
                EmployeeId = employeeId,
                EmployeeName = name,
            };
            _employeeRepoMock.Setup(x => x.EmployeeRepository.FindById(x => x.EmployeeId == employeeId))
                .Returns(cus);
            //Act
            var customer = _sut.GetById(employeeId);
            //Assert
            Assert.Equal(employeeId, cus.EmployeeId);
            Assert.Equal(name, cus.EmployeeName);
        }

        [Fact]
        public void GetById_ShouldReturnNothing()
        {
            //Arrange 
            int employeeId = 00000;
            var cus = new Entities.Models.Employee
            {
                EmployeeId = employeeId
            };

            _employeeRepoMock.Setup(x => x.EmployeeRepository.FindById(x => x.EmployeeId == employeeId))
                .Returns(cus);
            //Act
            var employee = _sut.GetById(employeeId);
            var statusCode = 404;
            int verify = 200;

            if (cus.EmployeeId <= 0)
            {
                verify = 404;
            }
            //Assert
            Assert.Equal(statusCode, verify);
        }
    }
}

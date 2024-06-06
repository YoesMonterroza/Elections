using Elections.Backend.Controllers;
using Elections.Backend.Data;
using Elections.Backend.UnitsOfWork.Interfaces;
using Elections.Shared.DTOs;
using Elections.Shared.Entities;
using Elections.Shared.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace Elections.UnitTests.Controllers
{
    [TestClass]
    public class ElectoralPositionsControllerTests
    {

        private Mock<IGenericUnitOfWork<ElectoralPosition>> _mockGenericUnitOfWork = null!;
        private Mock<IElectoralPositionsUnitOfWork> _mockElectoralPositionUnitOfWork = null!;
        private ElectoralPositionsController _controller = null!;


        [TestInitialize]
        public void Setup()
        {
            _mockGenericUnitOfWork = new Mock<IGenericUnitOfWork<ElectoralPosition>>();
            _mockElectoralPositionUnitOfWork = new Mock<IElectoralPositionsUnitOfWork>();
            _controller = new ElectoralPositionsController(_mockGenericUnitOfWork.Object, _mockElectoralPositionUnitOfWork.Object);
        }

        /*[TestMethod]
        public async Task GetComboAsync_ReturnsOkObjectResult()
        {
            // Arrange
            var comboData = new List<ElectoralPosition> { new ElectoralPosition() };
            _mockElectoralPositionUnitOfWork.Setup(x => x.GetAsync()).ReturnsAsync(comboData);
            // Act
            var result = await _controller.GetAsync();
            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.AreEqual(comboData, okResult!.Value);
            _mockElectoralPositionUnitOfWork.Verify(x => x.GetAsync(), Times.Once());
        }*/


        //[TestMethod]
        //public async Task GetAsync_ReturnsOkResult()
        //{
        //    //Arrange
        //    var pagination = new PaginationDTO();
        //    var response = new ActionResponse<IEnumerable<ElectoralPosition>> { WasSuccess= true};
        //    //var comboData = new List<ElectoralPosition> { new ElectoralPosition() };
        //    _mockElectoralPositionUnitOfWork.Setup(x => x.GetAsync(pagination)).ReturnsAsync(response);//new PaginationDTO()

        //    //Act
        //    var result = await _controller.GetAsync();
            
        //    //assert
        //    Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        //    var okResult = result as OkObjectResult;
        //    Assert.AreEqual(response.Result, okResult!.Value);
        //    _mockElectoralPositionUnitOfWork.Verify( x => x.GetAsync(), Times.Once());
        //}

        [TestMethod]
        public async Task GetAsync_ReturnsBadRequestResult_WhenWasSuccessIsFalse()
        {
            // Arrange
            var pagination = new PaginationDTO();
            var response = new ActionResponse<IEnumerable<ElectoralPosition>> { WasSuccess = false };
            _mockElectoralPositionUnitOfWork.Setup(x => x.GetAsync(pagination)).ReturnsAsync(response);
            // Act
            var result = await _controller.GetAsync(pagination);
            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
            _mockElectoralPositionUnitOfWork.Verify(x => x.GetAsync(pagination), Times.Once());
        }

        [TestMethod]
        public async Task GetPagesAsync_ReturnsOkObjectResult_WhenWasSuccessIsTrue()

        {
            // Arrange
            var pagination = new PaginationDTO();
            var action = new ActionResponse<int> { WasSuccess = true, Result = 5 };
            _mockElectoralPositionUnitOfWork.Setup(x => x.GetTotalPagesAsync(pagination)).ReturnsAsync(action);
            // Act
            var result = await _controller.GetPagesAsync(pagination);
            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.AreEqual(action.Result, okResult!.Value);
            _mockElectoralPositionUnitOfWork.Verify(x => x.GetTotalPagesAsync(pagination), Times.Once());
        }

        [TestMethod]
        public async Task GetPagesAsync_ReturnsBadRequestResult_WhenWasSuccessIsFalse()
        {
            // Arrange
            var pagination = new PaginationDTO();
            var action = new ActionResponse<int> { WasSuccess = false };
            _mockElectoralPositionUnitOfWork.Setup(x => x.GetTotalPagesAsync(pagination)).ReturnsAsync(action);
            // Act
            var result = await _controller.GetPagesAsync(pagination);
            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
            _mockElectoralPositionUnitOfWork.Verify(x => x.GetTotalPagesAsync(pagination), Times.Once());
        }
    }
}

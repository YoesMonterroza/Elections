using Elections.Backend.Repositories.Interfaces;
using Elections.Backend.UnitsOfWork.Implementations;
using Elections.Shared.DTOs;
using Elections.Shared.Entities;
using Elections.Shared.Responses;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elections.UnitTests.UnitsOfWork
{
    [TestClass]
    public class ElectoralPositionUnitOfWorkTest
    {
        private Mock<IGenericRepository<ElectoralPosition>> _mockGenericRepository = null!;
        private Mock<IElectoralPositionsRepository> _mockElectoralPositionsRepository = null!;
        private ElectoralPositionsUnitOfWork _unitOfWork = null!;

        [TestInitialize]
        public void Initialize()
        {
            _mockGenericRepository = new Mock<IGenericRepository<ElectoralPosition>>();
            _mockElectoralPositionsRepository = new Mock<IElectoralPositionsRepository>();
            _unitOfWork = new ElectoralPositionsUnitOfWork(_mockGenericRepository.Object, _mockElectoralPositionsRepository.Object);
        }

        [TestMethod]
        public async Task GetAsync_WithPagination_ShouldReturnData()
        {
            // Arrange
            var pagination = new PaginationDTO();
            var expectedResponse = new ActionResponse<IEnumerable<ElectoralPosition>> { WasSuccess = true };
            _mockElectoralPositionsRepository.Setup(x => x.GetAsync(pagination))
            .ReturnsAsync(expectedResponse);
            // Act
            var result = await _unitOfWork.GetAsync(pagination);
            // Assert
            Assert.AreEqual(expectedResponse, result);
            _mockElectoralPositionsRepository.Verify(x => x.GetAsync(pagination), Times.Once);
        }

        [TestMethod]
        public async Task GetAsync_ShouldReturnData()
        {
            // Arrange
            var expectedResponse = new ActionResponse<IEnumerable<ElectoralPosition>> { WasSuccess = true };
            _mockElectoralPositionsRepository.Setup(x => x.GetAsync())
            .ReturnsAsync(expectedResponse);
            // Act
            var result = await _unitOfWork.GetAsync();
            // Assert
            Assert.AreEqual(expectedResponse, result);
            _mockElectoralPositionsRepository.Verify(x => x.GetAsync(), Times.Once);
        }

        [TestMethod]
        public async Task GetTotalPagesAsync_ShouldReturnTotalPages()
        {
            // Arrange
            var pagination = new PaginationDTO();
            var expectedResponse = new ActionResponse<int> { WasSuccess = true };
            _mockElectoralPositionsRepository.Setup(x => x.GetTotalPagesAsync(pagination))
            .ReturnsAsync(expectedResponse);
            // Act
            var result = await _unitOfWork.GetTotalPagesAsync(pagination);
            // Assert
            Assert.AreEqual(expectedResponse, result);
            _mockElectoralPositionsRepository.Verify(x => x.GetTotalPagesAsync(pagination), Times.Once);
        }

        [TestMethod]
        public async Task GetAsync_WithId_ShouldReturnData()
        {
            // Arrange
            int id = 1;
            var expectedResponse = new ActionResponse<ElectoralPosition> { WasSuccess = true };
            _mockElectoralPositionsRepository.Setup(x => x.GetAsync(id))
            .ReturnsAsync(expectedResponse);
            // Act
            var result = await _unitOfWork.GetAsync(id);
            // Assert
            Assert.AreEqual(expectedResponse, result);
            _mockElectoralPositionsRepository.Verify(x => x.GetAsync(id), Times.Once);
        }

    }
}

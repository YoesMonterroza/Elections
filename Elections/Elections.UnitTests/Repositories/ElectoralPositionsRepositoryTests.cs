using Elections.Backend.Data;
using Elections.Backend.Repositories.Implementations;
using Elections.Shared.DTOs;
using Elections.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace Elections.UnitTests.Repositories
{
    [TestClass]
    public class ElectoralPositionsRepositoryTests
    {
        private DataContext _context = null!;
        private ElectoralPositionsRepository _repository = null!;

        [TestInitialize]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;
            _context = new DataContext(options);
            _repository = new ElectoralPositionsRepository(_context);
            _context.ElectoralPositions.AddRange(new List<ElectoralPosition>
            {
                new ElectoralPosition { Name = "Secretario General" },
                new ElectoralPosition { Name = "Tesorero" },
                new ElectoralPosition { Name = "Director Ejecutivo" },
            });
            _context.SaveChanges();
        }

        [TestCleanup]
        public void Cleanup()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }
        [TestMethod]
        public async Task GetAsync_ReturnsFilteredElectoralPositions()
        {
            // Arrange
            var pagination = new PaginationDTO { Filter = "Teso", RecordsNumber = 10, Page = 1 };
            // Act
            var response = await _repository.GetAsync(pagination);
            // Assert
            Assert.IsTrue(response.WasSuccess);
            var categories = response.Result!.ToList();
            Assert.AreEqual(1, categories.Count);
            Assert.AreEqual("Tesorero", categories.First().Name);
        }

        [TestMethod]
        public async Task GetAsync_ReturnsAllElectoralPositios_WhenNoFilterIsProvided()
        {
            // Arrange
            var pagination = new PaginationDTO { RecordsNumber = 10, Page = 1 };
            // Act
            var response = await _repository.GetAsync(pagination);
            // Assert
            Assert.IsTrue(response.WasSuccess);
            var electoralPositions = response.Result!.ToList();
            Assert.AreEqual(3, electoralPositions.Count);
        }

        /*[TestMethod]
        public async Task GetAsync_ReturnsAllElectoralPositions()
        {
            // Act
            var electoralPositions = await _repository.GetAsync();
            // Assert
            Assert.AreEqual(3, electoralPositions.Count());
        }*/

        [TestMethod]
        public async Task GetTotalPagesAsync_ReturnsCorrectNumberOfPages()
        {
            // Arrange
            var pagination = new PaginationDTO { RecordsNumber = 2, Page = 1 };
            // Act
            var response = await _repository.GetTotalPagesAsync(pagination);
            // Assert
            Assert.IsTrue(response.WasSuccess);
            Assert.AreEqual(2, response.Result);
        }

        [TestMethod]
        public async Task GetTotalPagesAsync_WithFilter_ReturnsCorrectNumberOfPages()
        {
            // Arrange
            var pagination = new PaginationDTO { RecordsNumber = 2, Page = 1, Filter = "Te" };
            // Act
            var response = await _repository.GetTotalPagesAsync(pagination);
            // Assert
            Assert.IsTrue(response.WasSuccess);
            Assert.AreEqual(1, response.Result);
        }
    }
}

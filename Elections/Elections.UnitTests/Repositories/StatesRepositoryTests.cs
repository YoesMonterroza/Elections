﻿using Elections.Backend.Data;
using Elections.Backend.Repositories.Implementations;
using Elections.Shared.DTOs;
using Elections.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elections.UnitTests.Repositories
{
    [TestClass]
    public class StatesRepositoryTests
    {
        private DataContext _context = null!;
        private StatesRepository _repository = null!;

        [TestInitialize]
        public void Initialize()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(databaseName: "OrdersDb")
            .Options;
            _context = new DataContext(options);
            _repository = new StatesRepository(_context);
        }

        [TestMethod]
        public async Task GetAsync_ShouldReturnStates()
        {
            // Arrange
            PopulateTestData();
            // Act
            var result = await _repository.GetAsync();
            // Assert
            Assert.IsTrue(result.WasSuccess);
            Assert.AreEqual(4, result.Result!.Count());
            Assert.AreEqual("TestState1", result.Result!.First().Name);
            Assert.AreEqual("TestState4", result.Result!.Last().Name);
        }

        [TestMethod]
        public async Task GetAsync_ShouldReturnFilteredAndPaginatedStates()
        {
            // Arrange
            PopulateTestData();
            var pagination = new PaginationDTO
            {
                Filter = "test",
                RecordsNumber = 2,
                Page = 1,
                Id = 1
            };
            // Act
            var result = await _repository.GetAsync(pagination);
            // Assert
            Assert.IsTrue(result.WasSuccess);
            Assert.AreEqual(2, result.Result!.Count());
            Assert.AreEqual("TestState1", result.Result!.First().Name);
            Assert.AreEqual("TestState2", result.Result!.Last().Name);
        }

        [TestMethod]
        public async Task GetTotalPagesAsync_ShouldReturnCorrectTotalPages()
        {
            // Arrange
            PopulateTestData();
            var pagination = new PaginationDTO
            {
                RecordsNumber = 2,
                Id = 1,
                Filter = "Test"
            };
            // Act
            var result = await _repository.GetTotalPagesAsync(pagination);
            // Assert
            Assert.IsTrue(result.WasSuccess);
            Assert.AreEqual(2, result.Result);
        }

        [TestMethod]
        public async Task GetAsync_ById_ShouldReturnState()
        {
            // Arrange
            PopulateTestData();
            var stateId = 1;
            // Act
            var result = await _repository.GetAsync(stateId);
            // Assert
            Assert.IsTrue(result.WasSuccess);
            Assert.AreEqual("TestState1", result.Result!.Name);
        }

        [TestMethod]
        public async Task GetAsync_ById_ShouldReturnError()
        {
            // Arrange
            PopulateTestData();
            var stateId = 999;
            // Act
            var result = await _repository.GetAsync(stateId);
            // Assert
            Assert.IsFalse(result.WasSuccess);
            Assert.AreEqual("Estado no existe", result.Message);
        }

        [TestMethod]
        public async Task GetComboAsync_ShouldReturnStatesForCountry()
        {
            // Arrange
            PopulateTestData();
            var countryId = 1;
            // Act
            var result = await _repository.GetComboAsync(countryId);
            // Assert
            Assert.AreEqual(4, result.Count());
        }
        private void PopulateTestData()
        {
        if (_context.Countries.Any())
        {
            return;
        }
        var country = new Country { Id = 1, Name = "TestCountry" };
            _context.Countries.Add(country);
            var states = new List<State>
            {
            new State { Id = 1, Name = "TestState1", Country = country },
            new State { Id = 2, Name = "TestState2", Country = country },
            new State { Id = 3, Name = "TestState3", Country = country },
            new State { Id = 4, Name = "TestState4", Country = country }
            };
            _context.States.AddRange(states);
            _context.SaveChanges();
        }

        [TestCleanup]
        public void Cleanup()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }
    }
}

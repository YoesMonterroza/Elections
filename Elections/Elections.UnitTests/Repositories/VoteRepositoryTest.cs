using Elections.Backend.Data;
using Elections.Backend.Repositories.Implementations;
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
    public class VoteRepositoryTest
    {
        private DataContext _context = null!;
        private VoteRepository _repository = null!;

        [TestInitialize]
        public void Initialize()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;
            _context = new DataContext(options);
            _repository = new VoteRepository(_context);
            SeedDatabase();
        }
        private void SeedDatabase()
        {
            var country = new Country
            {
                Name = "Country",
                States = new List<State>
                {
                    new State
                    {
                        Name = "State",
                        Cities = new List<City>
                        {
                            new City { Name = "City" }
                        }
                    }
                }
            };
            _context.Countries.Add(country);
            _context.SaveChanges();
            var votes = new VotingStation
            {
                Name = "Puesto Cafeteria",
                Description = "Puesto ubicado en la Cafeteria",
                Code = "CF",
                CityId = 1,
                Zonings = [
                    new Zoning() { ZoningNumber = "01" },
                    new Zoning() { ZoningNumber = "02"},
                    new Zoning() { ZoningNumber = "03"},
                    new Zoning() { ZoningNumber = "04"},
                    new Zoning() { ZoningNumber = "05"},
                    new Zoning() { ZoningNumber = "06"},
                    new Zoning() { ZoningNumber = "07"},
                    new Zoning() { ZoningNumber = "08"},
                    new Zoning() { ZoningNumber = "09"},
                    new Zoning() { ZoningNumber = "10"},
                    new Zoning() { ZoningNumber = "11"},
                    new Zoning() { ZoningNumber = "12"}
                ]
            };
            _context.VotingStations.AddRange(votes);
            _context.SaveChanges();
        }
    }
}

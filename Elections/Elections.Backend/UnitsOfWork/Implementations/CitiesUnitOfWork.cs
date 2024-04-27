using Elections.Backend.Repositories.Interfaces;
using Elections.Backend.UnitsOfWork.Interfaces;
using Elections.Shared.DTOs;
using Elections.Shared.Entities;
using Elections.Shared.Responses;

namespace Elections.Backend.UnitsOfWork.Implementations
{
    public class CitiesUnitOfWork : GenericUnitOfWork<City>, ICitiesUnitOfWork
    {
        private readonly ICitiesRepository _citiesRepository;

        public CitiesUnitOfWork(IGenericRepository<City> repository, ICitiesRepository citiesRepository) : base(repository)
        {
            _citiesRepository = citiesRepository;
        }
        public async Task<IEnumerable<City>> GetComboAsync(int stateId) => await _citiesRepository.GetComboAsync(stateId);
    }
}

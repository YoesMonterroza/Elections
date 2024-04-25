using Elections.Backend.Repositories.Interfaces;
using Elections.Backend.UnitsOfWork.Interfaces;
using Elections.Shared.DTOs;
using Elections.Shared.Entities;
using Elections.Shared.Responses;

namespace Elections.Backend.UnitsOfWork.Implementations
{
    public class ZoningsUnitOfWork : GenericUnitOfWork<Zoning>, IZoningsUnitOfWork
    {
        private readonly IZoningsRepository _zoningsRepository;

        public ZoningsUnitOfWork(IGenericRepository<Zoning> repository, IZoningsRepository zoningsRepository) : base(repository)
        {
            _zoningsRepository = zoningsRepository;
        }

        public override async Task<ActionResponse<IEnumerable<Zoning>>> GetAsync(PaginationDTO pagination) => await _zoningsRepository.GetAsync(pagination);

        public override async Task<ActionResponse<int>> GetTotalPagesAsync(PaginationDTO pagination) => await _zoningsRepository.GetTotalPagesAsync(pagination);

    }
}

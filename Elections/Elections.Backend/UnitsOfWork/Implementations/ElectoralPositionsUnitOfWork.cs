using Elections.Backend.Repositories.Implementations;
using Elections.Backend.Repositories.Interfaces;
using Elections.Backend.UnitsOfWork.Interfaces;
using Elections.Shared.DTOs;
using Elections.Shared.Entities;
using Elections.Shared.Responses;

namespace Elections.Backend.UnitsOfWork.Implementations
{
    public class ElectoralPositionsUnitOfWork : GenericUnitOfWork<ElectoralPosition>, IElectoralPositionsUnitOfWork
    {
        private readonly IElectoralPositionsRepository _electoralPositionsRepository;
        public ElectoralPositionsUnitOfWork(IGenericRepository<ElectoralPosition> repository, IElectoralPositionsRepository electoralPositionsRepository) : base(repository)
        {
            _electoralPositionsRepository = electoralPositionsRepository;
        }
        public override async Task<ActionResponse<IEnumerable<ElectoralPosition>>> GetAsync() => await _electoralPositionsRepository.GetAsync();
        public override async Task<ActionResponse<ElectoralPosition>> GetAsync(int id) => await _electoralPositionsRepository.GetAsync(id);
        public override async Task<ActionResponse<IEnumerable<ElectoralPosition>>> GetAsync(PaginationDTO pagination) => await _electoralPositionsRepository.GetAsync(pagination);
        public override async Task<ActionResponse<int>> GetTotalPagesAsync(PaginationDTO pagination) => await _electoralPositionsRepository.GetTotalPagesAsync(pagination);

    }
}

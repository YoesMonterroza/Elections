using Elections.Backend.Repositories.Implementations;
using Elections.Backend.Repositories.Interfaces;
using Elections.Backend.UnitsOfWork.Interfaces;
using Elections.Shared.DTOs;
using Elections.Shared.Entities;
using Elections.Shared.Responses;

namespace Elections.Backend.UnitsOfWork.Implementations
{
    public class ElectoralJourneysUnitOfWork : GenericUnitOfWork<ElectoralJourney>, IElectoralJourneysUnitOfWork
    {
        private readonly IElectoralJourneysRepository _electoralJourneyRepository;
        public ElectoralJourneysUnitOfWork(IGenericRepository<ElectoralJourney> repository, IElectoralJourneysRepository electoralJourneyRepository ) : base(repository)
        {
            _electoralJourneyRepository = electoralJourneyRepository;
        }

        public override async Task<ActionResponse<IEnumerable<ElectoralJourney>>> GetAsync() => await _electoralJourneyRepository.GetAsync();
        public override async Task<ActionResponse<ElectoralJourney>> GetAsync(int id) => await _electoralJourneyRepository.GetAsync(id);
        public override async Task<ActionResponse<IEnumerable<ElectoralJourney>>> GetAsync(PaginationDTO pagination) => await _electoralJourneyRepository.GetAsync(pagination);
        public override async Task<ActionResponse<int>> GetTotalPagesAsync(PaginationDTO pagination) => await _electoralJourneyRepository.GetTotalPagesAsync(pagination);

    }
}

using Elections.Backend.Repositories.Interfaces;
using Elections.Backend.UnitsOfWork.Interfaces;
using Elections.Shared.DTOs;
using Elections.Shared.Entities;
using Elections.Shared.Responses;

namespace Elections.Backend.UnitsOfWork.Implementations
{
    public class ElectoralCandidateUnitOfWork : GenericUnitOfWork<ElectoralCandidate>, IElectoralCandidateUnitOfWork
    {
        private readonly IElectoralCandidateRepository _electoralCandidateRepository;

        public ElectoralCandidateUnitOfWork(IGenericRepository<ElectoralCandidate> repository, IElectoralCandidateRepository electoralCandidateRepository) : base(repository)
        {
            _electoralCandidateRepository = electoralCandidateRepository;
        }

        public override async Task<ActionResponse<IEnumerable<ElectoralCandidate>>> GetAsync() => await _electoralCandidateRepository.GetAsync();

        public override async Task<ActionResponse<ElectoralCandidate>> GetAsync(int id) => await _electoralCandidateRepository.GetAsync(id);

        public override async Task<ActionResponse<IEnumerable<ElectoralCandidate>>> GetAsync(PaginationDTO pagination) => await _electoralCandidateRepository.GetAsync(pagination);
        public override async Task<ActionResponse<int>> GetTotalPagesAsync(PaginationDTO pagination) => await _electoralCandidateRepository.GetTotalPagesAsync(pagination);

    }
}

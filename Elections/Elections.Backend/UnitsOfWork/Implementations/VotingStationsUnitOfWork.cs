using Elections.Backend.Repositories.Interfaces;
using Elections.Backend.UnitsOfWork.Interfaces;
using Elections.Shared.DTOs;
using Elections.Shared.Entities;
using Elections.Shared.Responses;

namespace Elections.Backend.UnitsOfWork.Implementations
{
    public class VotingStationsUnitOfWork : GenericUnitOfWork<VotingStation>, IVotingStationsUnitOfWork
    {
        private readonly IVotingStationsRepository _votingStationsRepository;

        public VotingStationsUnitOfWork(IGenericRepository<VotingStation> repository, IVotingStationsRepository votingStationsRepository) : base(repository)
        {
            _votingStationsRepository = votingStationsRepository;
        }

        public override async Task<ActionResponse<IEnumerable<VotingStation>>> GetAsync() => await _votingStationsRepository.GetAsync();

        public override async Task<ActionResponse<VotingStation>> GetAsync(int id) => await _votingStationsRepository.GetAsync(id);

        public override async Task<ActionResponse<IEnumerable<VotingStation>>> GetAsync(PaginationDTO pagination) => await _votingStationsRepository.GetAsync(pagination);

    }
}

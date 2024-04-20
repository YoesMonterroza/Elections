using Elections.Shared.Entities;
using Elections.Shared.Responses;

namespace Elections.Backend.Repositories.Interfaces
{
    public interface IVotingStationsRepository
    {
        Task<ActionResponse<VotingStation>> GetAsync(int id);

        Task<ActionResponse<IEnumerable<VotingStation>>> GetAsync();

    }
}

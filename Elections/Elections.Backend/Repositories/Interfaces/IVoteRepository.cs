using Elections.Shared.Entities;
using Elections.Shared.Responses;

namespace Elections.Backend.Repositories.Interfaces
{
    public interface IVoteRepository
    {
        Task<ActionResponse<Vote>> RegisterVote(Vote _vote);
    }
}

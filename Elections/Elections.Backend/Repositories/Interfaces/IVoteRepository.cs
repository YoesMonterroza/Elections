using Elections.Shared.DTOs;
using Elections.Shared.Entities;
using Elections.Shared.Responses;

namespace Elections.Backend.Repositories.Interfaces
{
    public interface IVoteRepository
    {
        Task<ActionResponse<Vote>> RegisterVote(Vote _vote);

        Task<IEnumerable<CandidateDTO>> GetCandidatesByJourney(int journeyId);

        Task<IEnumerable<int>> GetVotesByDocument(Vote _vote);
    }
}

using Elections.Shared.DTOs;
using Elections.Shared.Entities;
using Elections.Shared.Responses;

namespace Elections.Backend.Repositories.Interfaces
{
    public interface IElectoralCandidateRepository
    {
        Task<ActionResponse<ElectoralCandidate>> GetAsync(int id);

        Task<ActionResponse<IEnumerable<ElectoralCandidate>>> GetAsync();
        Task<ActionResponse<IEnumerable<ElectoralCandidate>>> GetAsync(PaginationDTO pagination);
        Task<ActionResponse<int>> GetTotalPagesAsync(PaginationDTO pagination);
    }
}

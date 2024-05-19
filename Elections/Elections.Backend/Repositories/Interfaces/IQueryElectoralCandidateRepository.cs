using Elections.Shared.DTOs;
using Elections.Shared.Responses;

namespace Elections.Backend.Repositories.Interfaces
{
    public interface IQueryElectoralCandidateRepository
    {
        Task<ActionResponse<IEnumerable<ElectoralCandidateDTO>>> GetAsync();
    }
}

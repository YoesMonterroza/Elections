using Elections.Shared.DTOs;
using Elections.Shared.Entities;
using Elections.Shared.Responses;

namespace Elections.Backend.UnitsOfWork.Interfaces
{
    public interface IElectoralJourneysUnitOfWork
    {
        Task<ActionResponse<ElectoralJourney>> GetAsync(int id);
        Task<ActionResponse<IEnumerable<ElectoralJourney>>> GetAsync();
        Task<ActionResponse<IEnumerable<ElectoralJourney>>> GetAsync(PaginationDTO pagination);
        Task<ActionResponse<int>> GetTotalPagesAsync(PaginationDTO pagination);
    }
}

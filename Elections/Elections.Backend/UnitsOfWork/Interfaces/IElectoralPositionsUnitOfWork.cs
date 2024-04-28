using Elections.Shared.DTOs;
using Elections.Shared.Entities;
using Elections.Shared.Responses;

namespace Elections.Backend.UnitsOfWork.Interfaces
{
    public interface IElectoralPositionsUnitOfWork
    {
        Task<ActionResponse<ElectoralPosition>> GetAsync(int id);
        Task<ActionResponse<IEnumerable<ElectoralPosition>>> GetAsync();
        Task<ActionResponse<IEnumerable<ElectoralPosition>>> GetAsync(PaginationDTO pagination);
        Task<ActionResponse<int>> GetTotalPagesAsync(PaginationDTO pagination);
    }
}

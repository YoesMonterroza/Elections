using Elections.Shared.Entities;
using Elections.Shared.DTOs;
using Elections.Shared.Responses;

namespace Elections.Backend.UnitsOfWork.Interfaces
{
    public interface ICitiesUnitOfWork
    {
        Task<ActionResponse<IEnumerable<City>>> GetAsync(PaginationDTO pagination);
        Task<IEnumerable<City>> GetComboAsync(int stateId);
        Task<ActionResponse<int>> GetTotalPagesAsync(PaginationDTO pagination);

    }
}

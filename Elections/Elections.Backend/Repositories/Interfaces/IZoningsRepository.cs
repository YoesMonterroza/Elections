using Elections.Shared.DTOs;
using Elections.Shared.Entities;
using Elections.Shared.Responses;

namespace Orders.Backend.Repositories.Interfaces
{
    public interface IZoningsRepository
    {
        Task<ActionResponse<IEnumerable<Zoning>>> GetAsync(PaginationDTO pagination);

        Task<ActionResponse<int>> GetTotalPagesAsync(PaginationDTO pagination);

    }
}
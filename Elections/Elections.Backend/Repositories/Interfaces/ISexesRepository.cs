using Elections.Shared.DTOs;
using Elections.Shared.Entities;
using Elections.Shared.Responses;

namespace Elections.Backend.Repositories.Interfaces
{
    public interface ISexesRepository
    {
        Task<ActionResponse<IEnumerable<Sex>>> GetAsync(PaginationDTO pagination);

        Task<ActionResponse<Sex>> PostAsync(SexDTO model);

        Task<ActionResponse<Sex>> UpdateAsync(Sex model);

        Task<ActionResponse<Sex>> DeleteAsync(int id);
    }
}

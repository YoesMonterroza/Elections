using Elections.Shared.DTOs;
using Elections.Shared.Entities;
using Elections.Shared.Responses;

namespace Elections.Backend.Repositories.Interfaces
{
    public interface IIdentificationTypeRepository
    {
        Task<ActionResponse<IEnumerable<IdentificationType>>> GetAsync(PaginationDTO pagination);

        Task<ActionResponse<IdentificationType>> PostAsync(IdentificationType model);

        Task<ActionResponse<IdentificationType>> UpdateAsync(IdentificationType model);

        Task<ActionResponse<IdentificationType>> DeleteAsync(int id);
    }
}

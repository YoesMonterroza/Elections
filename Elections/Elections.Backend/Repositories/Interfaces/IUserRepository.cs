using Elections.Shared.DTOs;
using Elections.Shared.Entities;
using Elections.Shared.Responses;

namespace Elections.Backend.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<ActionResponse<IEnumerable<User>>> GetAsync(PaginationDTO pagination);

        Task<ActionResponse<User>> PostAsync(UserDTO model);

        Task<ActionResponse<User>> UpdateAsync(User model);

        Task<ActionResponse<User>> DeleteAsync(int id);
    }
}

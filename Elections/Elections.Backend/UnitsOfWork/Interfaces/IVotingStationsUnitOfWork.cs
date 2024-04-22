using Elections.Shared.DTOs;
using Elections.Shared.Entities;
using Elections.Shared.Responses;

namespace Elections.Backend.UnitsOfWork.Interfaces
{
    public interface IVotingStationsUnitOfWork
    {
        Task<ActionResponse<VotingStation>> GetAsync(int id);

        Task<ActionResponse<IEnumerable<VotingStation>>> GetAsync();
        Task<ActionResponse<IEnumerable<VotingStation>>> GetAsync(PaginationDTO pagination);

    }
}

using Elections.Shared.Entities;
using Elections.Shared.Responses;

namespace Elections.Backend.UnitsOfWork.Interfaces
{
    public interface IStatesUnitOfWork
    {
        Task<ActionResponse<State>> GetAsync(int id);

        Task<ActionResponse<IEnumerable<State>>> GetAsync();

        Task<IEnumerable<State>> GetComboAsync(int countryId);
    }
}

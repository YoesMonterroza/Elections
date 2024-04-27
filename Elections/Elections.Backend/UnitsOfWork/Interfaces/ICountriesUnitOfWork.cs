using Elections.Shared.Entities;
using Elections.Shared.Responses;

namespace Elections.Backend.UnitsOfWork.Interfaces
{
    public interface ICountriesUnitOfWork
    {
        Task<ActionResponse<Country>> GetAsync(int id);

        Task<ActionResponse<IEnumerable<Country>>> GetAsync();

        Task<IEnumerable<Country>> GetComboAsync();
    }
}

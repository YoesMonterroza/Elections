using Elections.Shared.Entities;
using Elections.Shared.Responses;


namespace Elections.Backend.Repositories.Interfaces
{
    public interface ICountriesRepository
    {
        Task<ActionResponse<Country>> GetAsync(int id);

        Task<ActionResponse<IEnumerable<Country>>> GetAsync();

        Task<IEnumerable<Country>> GetComboAsync();
    }
}



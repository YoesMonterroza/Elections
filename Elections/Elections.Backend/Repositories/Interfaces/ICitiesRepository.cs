using Elections.Shared.Entities;

namespace Elections.Backend.Repositories.Interfaces
{
    public interface ICitiesRepository
    {
        Task<IEnumerable<City>> GetComboAsync(int stateId);
    }
}

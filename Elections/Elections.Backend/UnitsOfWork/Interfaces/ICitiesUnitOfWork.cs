using Elections.Shared.Entities;

namespace Elections.Backend.UnitsOfWork.Interfaces
{
    public interface ICitiesUnitOfWork
    {
        Task<IEnumerable<City>> GetComboAsync(int stateId);
    }
}
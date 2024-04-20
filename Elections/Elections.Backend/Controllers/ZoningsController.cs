using Elections.Backend.UnitsOfWork.Interfaces;
using Elections.Shared.Entities;

namespace Elections.Backend.Controllers
{
    public class ZoningsController : GenericController<Zoning>
    {
        public ZoningsController(IGenericUnitOfWork<Zoning> unitOfWork) : base(unitOfWork)
        {
        }
    }
}

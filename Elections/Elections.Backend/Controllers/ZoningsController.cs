using Elections.Backend.UnitsOfWork.Interfaces;
using Elections.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Elections.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ZoningsController : GenericController<Zoning>
    {
        public ZoningsController(IGenericUnitOfWork<Zoning> unitOfWork) : base(unitOfWork)
        {
        }
    }
}

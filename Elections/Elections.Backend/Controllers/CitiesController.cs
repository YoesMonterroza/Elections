using Elections.Backend.UnitsOfWork.Interfaces;
using Elections.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Elections.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CitiesController : GenericController<City>
    {
        public CitiesController(IGenericUnitOfWork<City> unitOfWork) : base(unitOfWork)
        {
        }
    }
}



using Elections.Backend.Data;
using Elections.Backend.UnitsOfWork.Interfaces;
using Elections.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Elections.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ElectoralJourneysController : GenericController<ElectoralJourney>
    {
        public ElectoralJourneysController(IGenericUnitOfWork<ElectoralJourney> unitOfWork) : base(unitOfWork)
        {
        }
    }
}

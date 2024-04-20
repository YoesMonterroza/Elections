using Elections.Backend.Data;
using Elections.Backend.UnitsOfWork.Interfaces;
using Elections.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace Elections.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VotingStationController : GenericController<VotingStation>
    {
        public VotingStationController(IGenericUnitOfWork<VotingStation> unitOfWork) : base(unitOfWork)
        {
        }
    }
}


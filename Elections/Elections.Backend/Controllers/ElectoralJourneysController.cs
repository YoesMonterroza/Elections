using Elections.Backend.Data;
using Elections.Backend.UnitsOfWork.Implementations;
using Elections.Backend.UnitsOfWork.Interfaces;
using Elections.Shared.DTOs;
using Elections.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Elections.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ElectoralJourneysController : GenericController<ElectoralJourney>
    {
        private readonly IElectoralJourneysUnitOfWork _electoralJourneysUnitOfWork;
        public ElectoralJourneysController(IGenericUnitOfWork<ElectoralJourney> unitOfWork, IElectoralJourneysUnitOfWork electoralJourneysUnitOfWork) : base(unitOfWork)
        {
            _electoralJourneysUnitOfWork = electoralJourneysUnitOfWork;
        }

        [HttpGet("full")]
        public override async Task<IActionResult> GetAsync()
        {
            var response = await _electoralJourneysUnitOfWork.GetAsync();
            if (response.WasSuccess)
            {
                return Ok(response.Result);
            }
            return BadRequest();
        }

        [HttpGet("{id}")]
        public override async Task<IActionResult> GetAsync(int id)
        {
            var response = await _electoralJourneysUnitOfWork.GetAsync(id);
            if (response.WasSuccess)
            {
                return Ok(response.Result);
            }
            return NotFound(response.Message);
        }

        [HttpGet]
        public override async Task<IActionResult> GetAsync(PaginationDTO pagination)
        {
            var response = await _electoralJourneysUnitOfWork.GetAsync(pagination);
            if (response.WasSuccess)
            {
                return Ok(response.Result);
            }
            return BadRequest();
        }

        [HttpGet("totalPages")]
        public override async Task<IActionResult> GetPagesAsync([FromQuery] PaginationDTO pagination)
        {
            var action = await _electoralJourneysUnitOfWork.GetTotalPagesAsync(pagination);
            if (action.WasSuccess)
            {
                return Ok(action.Result);
            }
            return BadRequest();
        }

    }
}

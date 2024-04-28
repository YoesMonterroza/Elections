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
    public class ElectoralPositionsController : GenericController<ElectoralPosition>
    {
        private readonly IElectoralPositionsUnitOfWork _electoralPositionsUnitOfWork;
        public ElectoralPositionsController(IGenericUnitOfWork<ElectoralPosition> unitOfWork, IElectoralPositionsUnitOfWork electoralPositionsUnitOfWork) : base(unitOfWork)
        {
            _electoralPositionsUnitOfWork = electoralPositionsUnitOfWork;
        }
        [HttpGet("full")]
        public override async Task<IActionResult> GetAsync()
        {
            var response = await _electoralPositionsUnitOfWork.GetAsync();
            if (response.WasSuccess)
            {
                return Ok(response.Result);
            }
            return BadRequest();
        }

        [HttpGet("{id}")]
        public override async Task<IActionResult> GetAsync(int id)
        {
            var response = await _electoralPositionsUnitOfWork.GetAsync(id);
            if (response.WasSuccess)
            {
                return Ok(response.Result);
            }
            return NotFound(response.Message);
        }

        [HttpGet]
        public override async Task<IActionResult> GetAsync(PaginationDTO pagination)
        {
            var response = await _electoralPositionsUnitOfWork.GetAsync(pagination);
            if (response.WasSuccess)
            {
                return Ok(response.Result);
            }
            return BadRequest();
        }

        [HttpGet("totalPages")]
        public override async Task<IActionResult> GetPagesAsync([FromQuery] PaginationDTO pagination)
        {
            var action = await _electoralPositionsUnitOfWork.GetTotalPagesAsync(pagination);
            if (action.WasSuccess)
            {
                return Ok(action.Result);
            }
            return BadRequest();
        }

    }
}

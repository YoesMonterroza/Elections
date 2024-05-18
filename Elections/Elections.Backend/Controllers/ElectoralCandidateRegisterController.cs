using Elections.Backend.UnitsOfWork.Interfaces;
using Elections.Shared.DTOs;
using Elections.Shared.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Elections.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ElectoralCandidateRegisterController : GenericController<ElectoralCandidate>
    {
        private readonly IElectoralCandidateUnitOfWork _electoralCandidateUnitOfWork;
        public ElectoralCandidateRegisterController(IGenericUnitOfWork<ElectoralCandidate> unitOfWork, IElectoralCandidateUnitOfWork electoralCandidateUnitOfWork) : base(unitOfWork)
        {
            _electoralCandidateUnitOfWork = electoralCandidateUnitOfWork;
        }

        [HttpGet("full")]
        public override async Task<IActionResult> GetAsync()
        {
            var response = await _electoralCandidateUnitOfWork.GetAsync();
            if (response.WasSuccess)
            {
                return Ok(response.Result);
            }
            return BadRequest();
        }

        [HttpGet("{id}")]
        public override async Task<IActionResult> GetAsync(int id)
        {
            var response = await _electoralCandidateUnitOfWork.GetAsync(id);
            if (response.WasSuccess)
            {
                return Ok(response.Result);
            }
            return NotFound(response.Message);
        }

        [HttpGet]
        public override async Task<IActionResult> GetAsync(PaginationDTO pagination)
        {
            var response = await _electoralCandidateUnitOfWork.GetAsync(pagination);
            if (response.WasSuccess)
            {
                return Ok(response.Result);
            }
            return BadRequest();
        }

        [HttpGet("totalPages")]
        public override async Task<IActionResult> GetPagesAsync([FromQuery] PaginationDTO pagination)
        {
            var action = await _electoralCandidateUnitOfWork.GetTotalPagesAsync(pagination);
            if (action.WasSuccess)
            {
                return Ok(action.Result);
            }
            return BadRequest();
        }
    }
}

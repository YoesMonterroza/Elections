using Elections.Backend.Repositories.Implementations;
using Elections.Backend.Repositories.Interfaces;
using Elections.Backend.UnitsOfWork.Implementations;
using Elections.Backend.UnitsOfWork.Interfaces;
using Elections.Shared.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Elections.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoteController : ControllerBase
    {
        private readonly IVoteRepository _voteRepository;

        public VoteController(IVoteRepository voteRepository)
        {
            _voteRepository = voteRepository; 
        }

        [HttpPost("RegisterVote")]
        public async Task<IActionResult> RegisterVote(Vote vote)
        {
            var response = await _voteRepository.RegisterVote(vote);
            if (response.WasSuccess)
            {
                return Ok(response.Result);
            }

            return BadRequest();
        }

        [HttpGet("GetCandidatesByJourney")]
        public async Task<IActionResult> GetCandidatesByJourney(int journeyId)
        {
            var response = await _voteRepository.GetCandidatesByJourney(journeyId);
            return Ok(response);
        }

    }
}

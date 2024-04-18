using Elections.Backend.Data;
using Elections.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace Elections.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VotingStationController : ControllerBase
    {
        private readonly DataContext _context;
        public VotingStationController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _context.VotingStations.ToListAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var votingStation = await _context.VotingStations.FirstOrDefaultAsync(c => c.Id == id);
            if (votingStation == null)
            {
                return NotFound();
            }
            return Ok(votingStation);
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync(VotingStation votingStation)
        {
            _context.Add(votingStation);
            await _context.SaveChangesAsync();
            return Ok(votingStation);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var votingStation = await _context.VotingStations.FirstOrDefaultAsync(c => c.Id == id);
            
        if (votingStation == null)
            {
                return NotFound();
            }
            _context.Remove(votingStation);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpPut]
        public async Task<IActionResult> PutAsync(VotingStation votingStation)
        {
            _context.Update(votingStation);
            await _context.SaveChangesAsync();
            return Ok(votingStation);
        }
    }
}


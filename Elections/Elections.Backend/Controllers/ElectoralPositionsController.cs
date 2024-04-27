using Elections.Backend.Data;
using Elections.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Elections.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ElectoralPositionsController : ControllerBase
    {
        private readonly DataContext _context;

        public ElectoralPositionsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _context.ElectoralPositions.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var electoralPosition = await _context.ElectoralPositions.FindAsync(id);
            if(electoralPosition == null)
            {
                return NotFound();
            }
            return Ok(electoralPosition);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(ElectoralPosition electoralPosition)
        {
            _context.Add(electoralPosition);
            await _context.SaveChangesAsync();
            return Ok(electoralPosition);
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync(ElectoralPosition electoralPosition)
        {
            _context.Update(electoralPosition);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var electoralPosition = await _context.ElectoralPositions.FindAsync(id);
            if (electoralPosition == null)
            {
                return NotFound();
            }
            _context.Remove(electoralPosition);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}

using Elections.Backend.Data;
using Elections.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Elections.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ElectoralJourneysController : ControllerBase
    {
        private readonly DataContext _context;

        public ElectoralJourneysController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _context.ElectoralJourneys.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        { 
            var electoralJourney  = await _context.ElectoralJourneys.FindAsync(id);
            if(electoralJourney == null)
            {
                return NotFound();
            }
            return Ok(electoralJourney);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(ElectoralJourney electoralJourney)
        {
            _context.Add(electoralJourney);
            await _context.SaveChangesAsync();
            return Ok(electoralJourney);
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync(ElectoralJourney electoralJourney)
        {
            _context.Update(electoralJourney);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var electoralJourney = await _context.ElectoralJourneys.FindAsync(id);
            if (electoralJourney == null)
            {
                return NotFound();
            }
            _context.Remove(electoralJourney);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}

using Elections.Backend.Data;
using Elections.Backend.Repositories.Implementations;
using Elections.Backend.Repositories.Interfaces;
using Elections.Shared.Entities;
using Elections.Shared.Responses;
using Microsoft.EntityFrameworkCore;


namespace Elections.Backend.Repositories.Implementations
{
    public class CountriesRepository : GenericRepository<Country>, ICountriesRepository
    {
        private readonly DataContext _context;

        public CountriesRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<ActionResponse<IEnumerable<Country>>> GetAsync()
        {
            var countries = await _context.Countries
                .Include(c => c.States)
                .ToListAsync();
            return new ActionResponse<IEnumerable<Country>>
            {
                WasSuccess = true,
                Result = countries
            };
        }

        public override async Task<ActionResponse<Country>> GetAsync(int id)
        {
            var country = await _context.Countries
                 .Include(c => c.States!)
                 .ThenInclude(s => s.Cities)
                 .FirstOrDefaultAsync(c => c.Id == id);

            if (country == null)
            {
                return new ActionResponse<Country>
                {
                    WasSuccess = false,
                    Message = "País no existe"
                };
            }

            return new ActionResponse<Country>
            {
                WasSuccess = true,
                Result = country
            };
        }

        public async Task<IEnumerable<Country>> GetComboAsync()
        {
            return await _context.Countries
                .OrderBy(c => c.Name)
                .ToListAsync();
        }
    }
}

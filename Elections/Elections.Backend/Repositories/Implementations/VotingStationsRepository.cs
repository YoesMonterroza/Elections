using Elections.Backend.Data;
using Elections.Backend.Repositories.Interfaces;
using Elections.Shared.Entities;
using Elections.Shared.Responses;
using Microsoft.EntityFrameworkCore;

namespace Elections.Backend.Repositories.Implementations
{
    public class VotingStationsRepository : GenericRepository<VotingStation>, IVotingStationsRepository
    {
        private readonly DataContext _context;

        public VotingStationsRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<ActionResponse<IEnumerable<VotingStation>>> GetAsync()
        {
            var votingstations = await _context.VotingStations
                .Include(c => c.Zonings)
                .ToListAsync();
            return new ActionResponse<IEnumerable<VotingStation>>
            {
                WasSuccess = true,
                Result = votingstations
            };
        }

        public override async Task<ActionResponse<VotingStation>> GetAsync(int id)
        {
            var votingStation = await _context.VotingStations
                 .Include(c => c.Zonings!)
                 .FirstOrDefaultAsync(c => c.Id == id);

            if (votingStation == null)
            {
                return new ActionResponse<VotingStation>
                {
                    WasSuccess = false,
                    Message = "Puesto de votación no existe"
                };
            }

            return new ActionResponse<VotingStation>
            {
                WasSuccess = true,
                Result = votingStation
            };
        }

    }
}

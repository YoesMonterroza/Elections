using Elections.Backend.Data;
using Elections.Backend.Helpers;
using Elections.Backend.Repositories.Interfaces;
using Elections.Shared.DTOs;
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
                .OrderBy(c => c.Name)
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

        public override async Task<ActionResponse<IEnumerable<VotingStation>>> GetAsync(PaginationDTO pagination)
        {
            var queryable = _context.VotingStations
                .Include(c => c.Zonings)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(pagination.Filter))
            {
                queryable = queryable.Where(x => x.Name.ToLower().Contains(pagination.Filter.ToLower()));
            }

            if (pagination.RecordsNumber == -1)
            {
                pagination.RecordsNumber = await queryable.CountAsync();
            }


            return new ActionResponse<IEnumerable<VotingStation>>
            {
                WasSuccess = true,
                Result = await queryable
                    .OrderBy(x => x.Name)
                    .Paginate(pagination)
                    .ToListAsync()
            };
        }

        public override async Task<ActionResponse<int>> GetTotalPagesAsync(PaginationDTO pagination)
        {
            var queryable = _context.VotingStations.AsQueryable();

            if (!string.IsNullOrWhiteSpace(pagination.Filter))
            {
                queryable = queryable.Where(x => x.Name.ToLower().Contains(pagination.Filter.ToLower()));
            }

            double count = await queryable.CountAsync();
            if (pagination.RecordsNumber == -1)
            {
                pagination.RecordsNumber = (int) count;
            }
            int totalPages = (int)Math.Ceiling(count / pagination.RecordsNumber);
            return new ActionResponse<int>
            {
                WasSuccess = true,
                Result = totalPages
            };
        }



    }
}

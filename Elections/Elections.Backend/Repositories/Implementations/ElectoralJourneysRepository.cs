using Elections.Backend.Data;
using Elections.Backend.Helpers;
using Elections.Backend.Repositories.Interfaces;
using Elections.Shared.DTOs;
using Elections.Shared.Entities;
using Elections.Shared.Responses;
using Microsoft.EntityFrameworkCore;

namespace Elections.Backend.Repositories.Implementations
{
    public class ElectoralJourneysRepository : GenericRepository<ElectoralJourney>, IElectoralJourneysRepository
    {
        private readonly DataContext _context;
        public ElectoralJourneysRepository(DataContext context) : base(context)
        {
            _context = context;
        }
        public override async Task<ActionResponse<IEnumerable<ElectoralJourney>>> GetAsync()
        {
            var electoralJourneys = await _context.ElectoralJourneys
                .OrderBy(c => c.Date)
                .ToListAsync();
            return new ActionResponse<IEnumerable<ElectoralJourney>>
            {
                WasSuccess = true,
                Result = electoralJourneys
            };
        }

        public override async Task<ActionResponse<ElectoralJourney>> GetAsync(int id)
        {
            var electoralJourney = await _context.ElectoralJourneys
                 .FirstOrDefaultAsync(c => c.Id == id);

            if (electoralJourney == null)
            {
                return new ActionResponse<ElectoralJourney>
                {
                    WasSuccess = false,
                    Message = "Jornada electoral no existe"
                };
            }

            return new ActionResponse<ElectoralJourney>
            {
                WasSuccess = true,
                Result = electoralJourney
            };
        }

        public override async Task<ActionResponse<IEnumerable<ElectoralJourney>>> GetAsync(PaginationDTO pagination)
        {
            var queryable = _context.ElectoralJourneys
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(pagination.Filter))
            {
                queryable = queryable.Where(x => x.Name.ToLower().Contains(pagination.Filter.ToLower()));
            }

            if (pagination.RecordsNumber == -1)
            {
                pagination.RecordsNumber = await queryable.CountAsync();
            }


            return new ActionResponse<IEnumerable<ElectoralJourney>>
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
                pagination.RecordsNumber = (int)count;
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

using Elections.Backend.Data;
using Elections.Backend.Helpers;
using Elections.Backend.Repositories.Interfaces;
using Elections.Shared.DTOs;
using Elections.Shared.Entities;
using Elections.Shared.Responses;
using Microsoft.EntityFrameworkCore;

namespace Elections.Backend.Repositories.Implementations
{
    public class ElectoralCandidateRepository : GenericRepository<ElectoralCandidate>, IElectoralCandidateRepository
    {
        private readonly DataContext _context;

        public ElectoralCandidateRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<ActionResponse<IEnumerable<ElectoralCandidate>>> GetAsync()
        {
            var electoralCandidate = await _context.ElectoralCandidate               
                .ToListAsync();

            return new ActionResponse<IEnumerable<ElectoralCandidate>>
            {
                WasSuccess = true,
                Result = electoralCandidate
            };
        }

        public override async Task<ActionResponse<ElectoralCandidate>> GetAsync(int id)
        {
            var votingStation = await _context.ElectoralCandidate                  
                 .FirstOrDefaultAsync(c => c.Id == id);

            if (votingStation == null)
            {
                return new ActionResponse<ElectoralCandidate>
                {
                    WasSuccess = false,
                    Message = "Candidato no encontrado"
                };
            }

            return new ActionResponse<ElectoralCandidate>
            {
                WasSuccess = true,
                Result = votingStation
            };
        }

        public override async Task<ActionResponse<IEnumerable<ElectoralCandidate>>> GetAsync(PaginationDTO pagination)
        {
            var queryable = _context.ElectoralCandidate.AsQueryable();

            if (!string.IsNullOrWhiteSpace(pagination.Filter))
            {
                queryable = queryable.Where(x => x.Document.ToLower().Contains(pagination.Filter.ToLower()));
            }

            if (pagination.RecordsNumber == -1)
            {
                pagination.RecordsNumber = await queryable.CountAsync();
            }


            return new ActionResponse<IEnumerable<ElectoralCandidate>>
            {
                WasSuccess = true,
                Result = await queryable
                    .OrderBy(x => x.Document).Paginate(pagination)                    
                    .ToListAsync()
            };
        }

        public override async Task<ActionResponse<int>> GetTotalPagesAsync(PaginationDTO pagination)
        {
            var queryable = _context.ElectoralCandidate.AsQueryable();

            if (!string.IsNullOrWhiteSpace(pagination.Filter))
            {
                queryable = queryable.Where(x => x.Document.ToLower().Contains(pagination.Filter.ToLower()));
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

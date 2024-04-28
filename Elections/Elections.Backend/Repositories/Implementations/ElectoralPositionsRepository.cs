using Elections.Backend.Data;
using Elections.Backend.Helpers;
using Elections.Backend.Repositories.Interfaces;
using Elections.Shared.DTOs;
using Elections.Shared.Entities;
using Elections.Shared.Responses;
using Microsoft.EntityFrameworkCore;

namespace Elections.Backend.Repositories.Implementations
{
    public class ElectoralPositionsRepository : GenericRepository<ElectoralPosition>, IElectoralPositionsRepository
    {
        private readonly DataContext _context;
        public ElectoralPositionsRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<ActionResponse<IEnumerable<ElectoralPosition>>> GetAsync()
        {
            var electoralPositions = await _context.ElectoralPositions
                .OrderBy(c => c.Name)
                .ToListAsync();
            return new ActionResponse<IEnumerable<ElectoralPosition>>
            {
                WasSuccess = true,
                Result = electoralPositions
            };
        }

        public override async Task<ActionResponse<ElectoralPosition>> GetAsync(int id)
        {
            var electoralPosition = await _context.ElectoralPositions
                 .FirstOrDefaultAsync(c => c.Id == id);

            if (electoralPosition == null)
            {
                return new ActionResponse<ElectoralPosition>
                {
                    WasSuccess = false,
                    Message = "Cargo electoral no existe"
                };
            }

            return new ActionResponse<ElectoralPosition>
            {
                WasSuccess = true,
                Result = electoralPosition
            };
        }

        public override async Task<ActionResponse<IEnumerable<ElectoralPosition>>> GetAsync(PaginationDTO pagination)
        {
            var queryable = _context.ElectoralPositions
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(pagination.Filter))
            {
                queryable = queryable.Where(x => x.Name.ToLower().Contains(pagination.Filter.ToLower()));
            }

            if (pagination.RecordsNumber == -1)
            {
                pagination.RecordsNumber = await queryable.CountAsync();
            }


            return new ActionResponse<IEnumerable<ElectoralPosition>>
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
            var queryable = _context.ElectoralPositions.AsQueryable();

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

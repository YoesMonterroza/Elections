using Elections.Backend.Data;
using Elections.Backend.Helpers;
using Elections.Backend.Repositories.Interfaces;
using Elections.Shared.DTOs;
using Elections.Shared.Entities;
using Elections.Shared.Responses;
using Microsoft.EntityFrameworkCore;

namespace Elections.Backend.Repositories.Implementations
{
    public class ZoningsRepository : GenericRepository<Zoning>, IZoningsRepository
    {
        private readonly DataContext _context;

        public ZoningsRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<ActionResponse<IEnumerable<Zoning>>> GetAsync(PaginationDTO pagination)
        {
            var queryable = _context.Zonings
                .Where(x => x.VotingStation!.Id == pagination.Id)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(pagination.Filter))
            {
                queryable = queryable.Where(x => x.ZoningNumber.ToLower().Contains(pagination.Filter.ToLower()));
            }

            if (pagination.RecordsNumber == -1)
            {
                pagination.RecordsNumber = await queryable.CountAsync();
            }


            return new ActionResponse<IEnumerable<Zoning>>
            {
                WasSuccess = true,
                Result = await queryable
                    .OrderBy(x => x.ZoningNumber)
                    .Paginate(pagination)
                    .ToListAsync()
            };
        }

        public override async Task<ActionResponse<int>> GetTotalPagesAsync(PaginationDTO pagination)
        {
            var queryable = _context.Zonings
                .Where(x => x.VotingStation!.Id == pagination.Id)
                .AsQueryable();


            if (!string.IsNullOrWhiteSpace(pagination.Filter))
            {
                queryable = queryable.Where(x => x.ZoningNumber.ToLower().Contains(pagination.Filter.ToLower()));
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

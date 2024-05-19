using Elections.Backend.Data;
using Elections.Backend.Repositories.Interfaces;
using Elections.Shared.Entities;
using Elections.Shared.Responses;
using Elections.Backend.Helpers;
using Elections.Shared.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Elections.Backend.Repositories.Implementations
{
    public class QueryElectoralCandidateRepository : GenericRepository<ElectoralCandidateDTO>, IQueryElectoralCandidateRepository
    {
        private readonly DataContext _context;

        public QueryElectoralCandidateRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<ActionResponse<IEnumerable<ElectoralCandidateDTO>>> GetAsync()
        {
            var electoralCandidate =   await (from ec in _context.ElectoralCandidate
                                              join ep in _context.ElectoralPositions on ec.ElectoralPositionId equals ep.Id
                                              join ej in _context.ElectoralJourneys on ec.ElectoralJourneyId equals ej.Id
                                              join usr in _context.Users on ec.Document equals usr.Document
                                              where ec.Enabled == true
                                              select new ElectoralCandidateDTO
                                              {
                                                  ElectoralJourneyName = ej.Name,
                                                  ElectoralJourneyId = ej.Id,
                                                  ElectoralPositionId = ep.Id,
                                                  ElectoralPositionName = ep.Name,
                                                  Document = ec.Document,
                                                  Enabled = ec.Enabled,
                                                  Id = ec.Id,
                                                  RegisterDate = ec.RegisterDate,
                                                  CandidateFullName = usr.FullName
                                              }).ToListAsync();

            return new ActionResponse<IEnumerable<ElectoralCandidateDTO>>
            {
                WasSuccess = true,
                Result = electoralCandidate
            };
        }

    }
}

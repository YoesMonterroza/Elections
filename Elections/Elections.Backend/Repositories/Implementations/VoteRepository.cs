using Elections.Backend.Data;
using Elections.Backend.Repositories.Interfaces;
using Elections.Shared.Entities;
using Elections.Shared.Responses;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Elections.Backend.Repositories.Implementations
{
    public class VoteRepository: GenericRepository<Vote>, IVoteRepository
    {
        private readonly DataContext _context;

        public VoteRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ActionResponse<Vote>> RegisterVote(Vote _vote) 
        {           
            //DATE PARSE
            //vote.RegisterDate = DateTime.Now;
            //vote.UserId = _vote.UserId;
            //vote.ElectoralCandidateId = _vote.ElectoralCandidateId;
            //vote.ElectoralPositionId = _vote.ElectoralPositionId;
            //vote.ElectoralJourneyId = _vote.ElectoralJourneyId;

            //NEW METHOD TO GET VOTING STATION NUMBER OF USER

            return await AddAsync(_vote);
        }

       
    }
}

﻿using Elections.Backend.Data;
using Elections.Backend.Repositories.Interfaces;
using Elections.Shared.DTOs;
using Elections.Shared.Entities;
using Elections.Shared.Responses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Reflection.Metadata;

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
            return await AddAsync(_vote);
        }

        public async Task<IEnumerable<CandidateDTO>> GetCandidatesByJourney(int journeyId)
        {
            var response = (from ej in _context.ElectoralJourneys
                                  join can in _context.ElectoralCandidate on ej.Id equals can.ElectoralJourneyId
                                  join us in _context.Users on can.Document equals us.Document
                                  join cit in _context.Cities on us.CityId equals cit.Id
                                  join pos in _context.ElectoralPositions on can.ElectoralPositionId equals pos.Id
                            where ej.Id == journeyId
                                  select new CandidateDTO{
                                      Document = us.Document,
                                      CandidateFullName = us.FullName,
                                      Photo = us.Photo,
                                      CityName = cit.Name,
                                      ElectoralPosition = pos.Name,
                                      ElectoralPositionId = pos.Id,
                                      ElectoralCandidateId = can.Id
                                  }).ToList();

            return response;
        }

        public async Task<IEnumerable<int>> GetVotesByDocument(string userDocument, int journeyId)
        {
            var response = (from vot in _context.Votes                            
                            where vot.UserDocument == userDocument
                            && vot.ElectoralJourneyId == journeyId
                            select vot.ElectoralPositionId).Distinct().ToList();

            return response;
        }

        public async Task<IEnumerable<ResultDTO>> GetResultsAsync(int journeyId)
        {
            var response = (from vot in _context.Votes
                            join can in _context.ElectoralCandidate on vot.ElectoralCandidateId equals can.Id
                            join us in _context.Users on can.Document equals us.Document
                            where vot.ElectoralJourneyId == journeyId
                            group vot by new { vot.ElectoralCandidateId, us.FirstName, us.LastName } into g
                            select new ResultDTO
                            {
                                ElectoralCandidateId = g.Key.ElectoralCandidateId,                             
                                ElectoralCandidateName = string.Concat(g.Key.FirstName, " ", g.Key.LastName),
                                nVotes = g.Count()
                            }).ToList();

            return response;
        }
    }
}

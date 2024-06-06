using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elections.Shared.DTOs
{
    public class ResultDTO
    {
        public int ElectoralCandidateId { get; set; }
        public required string ElectoralCandidateName { get; set; }
        public int nVotes { get; set; }
    }
}

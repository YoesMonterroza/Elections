using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elections.Shared.DTOs
{
    public class ElectoralCandidateDTO
    {
        public int Id { get; set; }
      
        public int ElectoralJourneyId { get; set; }
 
        public int ElectoralPositionId { get; set; }

        public string ElectoralJourneyName { get; set; }

        public string ElectoralPositionName { get; set; }

        public string Document { get; set; } = null!;

        public string CandidateFullName { get; set; } = null!;

        public DateTime RegisterDate { get; set; }

        public bool Enabled { get; set; }
    }
}

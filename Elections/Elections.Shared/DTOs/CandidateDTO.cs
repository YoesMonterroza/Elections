using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elections.Shared.DTOs
{
    public class CandidateDTO
    {  
        public string Document { get; set; } = null!;

        public string CandidateFullName { get; set; } = null!;

        public string? Photo { get; set; }

        public string CityName { get; set; } = null!;

        public string ElectoralPosition { get; set; } = null!;
        public int ElectoralPositionId { get; set; }
        public int ElectoralCandidateId { get; set; }
    }
}

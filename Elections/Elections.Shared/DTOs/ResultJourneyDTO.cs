using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elections.Shared.DTOs
{
    public class ResultJourneyDTO
    {
        public string ElectoralPosition { get; set; }
        public ResultDTO resultDTO { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elections.Shared.Entities
{
    public class Vote
    {
        public int Id { get; set; }


        [Display(Name = "Puesto de Votación")]      
        public int VotingStationId { get; set; }


        [Display(Name = "Puesto de Votación")]
        public int ElectoralJourneyId { get; set; }


        [Display(Name = "Puesto de Votación")]
        public int ElectoralCandidateId { get; set; }


        [Display(Name = "Puesto de Votación")]
        public int ElectoralPositionId { get; set; }


        [Display(Name = "Sufragante")]
        public string UserDocument { get; set; }


        [Display(Name = "Fecha de Registro")]        
        public DateTime? RegisterDate { get; set; }

       
    }
}

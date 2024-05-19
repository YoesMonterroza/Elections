using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elections.Shared.Entities
{
    public class ElectoralCandidate
    {
        public int Id { get; set; }

        [Display(Name = "Jornada Electoral")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int ElectoralJourneyId { get; set; }

        [Display(Name = "Perfil Electoral")]       
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int ElectoralPositionId { get; set; }

        [Display(Name = "Documento")]        
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Document { get; set; } = null!;

        public DateTime RegisterDate { get; set; }

        public bool Enabled { get; set; } 
    }
}

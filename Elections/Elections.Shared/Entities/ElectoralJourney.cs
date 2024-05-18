using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Elections.Shared.Entities
{
    public class ElectoralJourney
    {
        public int Id { get; set; }

        [Display(Name = "Jornada Electoral")]
        [MaxLength(80, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Name { get; set; } = null!;

        [Display(Name = "Fecha Inicio Jornada")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public DateTime? Date { get; set; }

        [Display(Name = "Fecha Fin Jornada")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public DateTime? DateFinish { get; set; }


        //LLAVE FORANEA 
        public ICollection<ElectoralCandidate>? ElectoralCandidate { get; set; }
    }
}

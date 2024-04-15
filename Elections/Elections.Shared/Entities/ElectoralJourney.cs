using System.ComponentModel.DataAnnotations;

namespace Elections.Shared.Entities
{
    public class ElectoralJourney
    {
        public int Id { get; set; }

        [Display(Name = "Jornada Electoral")]
        [MaxLength(80, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Name { get; set; } = null!;

        [Display(Name = "Fecha Jornada")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public DateTime? Date { get; set; }
    }
}

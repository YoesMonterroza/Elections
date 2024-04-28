using System.ComponentModel.DataAnnotations;

namespace Elections.Shared.Entities
{
    public class IdentificationType
    {
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        [MaxLength(80, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Name { get; set; } = null!;

        public bool enabled { get; set; }
    }
}

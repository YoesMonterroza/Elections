using Elections.Shared.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Elections.Shared.Entities
{
    public class ElectoralPosition : IEntityWithName
    {
        public int Id { get; set; }

        [Display(Name = "Cargo Electoral")]
        [MaxLength(50, ErrorMessage ="El campo {0} no puede tener mas de {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Name { get; set; } = null!; 
    }
}

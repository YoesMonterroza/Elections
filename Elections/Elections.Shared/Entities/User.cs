using System.ComponentModel.DataAnnotations;

namespace Elections.Shared.Entities
{
    public class User
    {
        public int Id { get; set; }

        [Display(Name = "Nombre ")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Name { get; set; } = null!;


        [Display(Name = "Apellido ")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string LastName { get; set; } = null!;


        [Display(Name = "Fecha Nacimiento")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public DateTime? BirthDate { get; set; }


        [Display(Name = "Sexo")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public DateTime? Sex { get; set; }
    }
}

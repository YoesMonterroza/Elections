using Elections.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elections.Shared.Entities
{
    public class VotingStation
    {
        public int Id { get; set; }

        [Display(Name = "Nombre del sitio de Votación")]
        [MaxLength(80, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Name { get; set; }

        [Display(Name = "Descripción del sitio de Votación")]
        [MaxLength(80, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres")]
        public string Description { get; set; }

        [Display(Name = "Código del sitio de Votación")]
        [MaxLength(80, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Code { get; set; }

        public City? City { get; set; }

        [Display(Name = "Ciudad")]
        [Range(1, int.MaxValue, ErrorMessage = "Debes seleccionar una {0}.")]
        public int CityId { get; set; }

        public ICollection<Zoning>? Zonings { get; set; }

        [Display(Name = "Mesas de Votación")]
        public int ZoningNumber => Zonings == null || Zonings.Count == 0 ? 0 : Zonings.Count;

    }
}

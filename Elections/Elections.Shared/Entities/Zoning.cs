using Elections.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elections.Shared.Entities
{
    public class Zoning
    {
        public int Id { get; set; }

        [Display(Name = "Número de mesa de votación")]
        [MaxLength(80, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string ZoningNumber { get; set; } = null!;

        public int VotingStationId { get; set; }

        public VotingStation? VotingStation { get; set; }
    }
}

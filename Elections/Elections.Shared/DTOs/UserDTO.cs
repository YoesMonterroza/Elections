using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elections.Shared.DTOs
{
    public class UserDTO
    {
       
        public string Name { get; set; } = null!;
    
        public string LastName { get; set; } = null!;
       
        public DateTime? BirthDate { get; set; }
      
        public int SexId { get; set; }
    }
}

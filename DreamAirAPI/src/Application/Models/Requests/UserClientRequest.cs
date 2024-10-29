using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Requests
{
    public class UserClientRequest
    {
        [Required]
        public string Email { get; set; }
        [Required] 
        public string Password { get; set; }
        [Required]
        public string Name { get; set; }
        [Required] 
        public string LastName { get; set; }
        
        public string Nationality { get; set; }

        [Required]
        public int Dni { get; set; }
        
        public string Phone { get; set; }
        [Required]
        public int Age { get; set; }

    }
}

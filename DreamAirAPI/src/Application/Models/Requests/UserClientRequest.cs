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
        public string email { get; set; }
        [Required] 
        public string password { get; set; }
        [Required]
        public string name { get; set; }
        [Required] 
        public string lastName { get; set; }
        [Required]
        public string nationality { get; set; }
        [Required]
        public int dni { get; set; }
        [Required]
        public string phone { get; set; }
        [Required]
        public int age { get; set; }

    }
}

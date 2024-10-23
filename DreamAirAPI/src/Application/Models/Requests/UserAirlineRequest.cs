using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Requests
{
    public class UserAirlineRequest 
    {
        [Required]
        public string name {  get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string password { get; set; }



    }
}

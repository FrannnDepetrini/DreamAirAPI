using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Requests
{
    public class TicketRequest
    {
        [Required]
        public string classSeat { get; set; }

        [Required]
        public string State { get; set; }

         [Required]
        public string UserName { get; set; }

        [Required]
        public string UserLastName { get; set; }

        [Required]
        public int flightId { get; set; }
    }
}

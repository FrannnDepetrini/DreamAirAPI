using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Requests
{
    public class FlightRequest
    {
        [Required]
        public string departure { get; set; }
        [Required]
        public string arrival { get; set; }
        [Required]
        public DateTime date { get; set; }
        [Required]
        public string timeDeparture { get; set; }
        [Required]
        public string timeArrival { get; set; }
        [Required]
        public int totalAmountEconomic { get; set; }
        [Required]
        public int totalAmountFirstClass { get; set; }
        [Required]
        public float priceDefault { get; set; }
        [Required]
        public string airline { get; set; }
    }
}

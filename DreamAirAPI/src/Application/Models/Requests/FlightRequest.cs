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
        public string travel {  get; set; }
        [Required]
        public string departure { get; set; }
        [Required]
        public string arrival { get; set; }
        [Required]
        public DateTime dateGo { get; set; }
        [Required]
        public string timeDepartureGo { get; set; }
        [Required]
        public string timeArrivalGo { get; set; }
        
        public DateTime? dateBack { get; set; }
        
        public string? timeDepartureBack { get; set; }
        
        public string? timeArrivalBack { get; set; }
        [Required]
        public int totalAmountEconomic { get; set; }
        [Required]
        public int totalAmountFirstClass { get; set; }
        [Required]
        public float priceDefault { get; set; }
        
    }
}

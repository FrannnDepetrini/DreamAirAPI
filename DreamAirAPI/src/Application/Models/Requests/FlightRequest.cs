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
        public string Travel {  get; set; }
        [Required]
        public string Departure { get; set; }
        [Required]
        public string Arrival { get; set; }
        [Required]
        public DateTime DateGo { get; set; }
        [Required]
        public string TimeDepartureGo { get; set; }
        [Required]
        public string TimeArrivalGo { get; set; }
        
        public DateTime? DateBack { get; set; }
        
        public string? TimeDepartureBack { get; set; }
        
        public string? TimeArrivalBack { get; set; }
        [Required]
        public int TotalAmountEconomic { get; set; }
        [Required]
        public int TotalAmountFirstClass { get; set; }
        [Required]
        public float PriceDefault { get; set; }
        
    }
}

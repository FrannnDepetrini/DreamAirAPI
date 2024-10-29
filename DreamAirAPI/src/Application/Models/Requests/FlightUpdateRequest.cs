using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Requests
{
    public class FlightUpdateRequest
    {

        public int FlightId { get; set; }
        public DateTime DateGo { get; set; }
        public string TimeDepartureGo { get; set; }
        public string TimeArrivalGo { get; set; }

        public DateTime? DateBack { get; set; }
        public string? TimeDepartureBack { get; set; }
        public string? TimeArrivalBack { get; set; }


    }
}




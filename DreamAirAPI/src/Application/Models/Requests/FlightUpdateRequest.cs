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

        public int flightId { get; set; }
        public DateTime dateGo { get; set; }
        public string timeDepartureGo { get; set; }
        public string timeArrivalGo { get; set; }

        public DateTime? dateBack { get; set; }
        public string? timeDepartureBack { get; set; }
        public string? timeArrivalBack { get; set; }


    }
}




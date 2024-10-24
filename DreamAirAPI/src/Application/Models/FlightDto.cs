using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class FlightDto
    {
        public int id { get; set; }
        public string travel {  get; set; }
        public string departure { get; set; }
        public string arrival { get; set; }
        public DateTime dateGo { get; set; }
        public string timeDepartureGo { get; set; }
        public string timeArrivalGo { get; set; }

        public DateTime? dateBack { get; set; }
        public string? timeDepartureBack { get; set; }
        public string? timeArrivalBack { get; set; }
        public string duration { get; set; }
        public int totalAmountEconomic { get; set; }
        public int totalAmountFirstClass { get; set; }
        public float priceDefault { get; set; }
        public int freeEconomicSeats { get; set; }
        public int freeFirstClassSeats { get; set; }
        
        public static FlightDto Create(Flight flight)
        {
            
            return new FlightDto
            {
                id = flight.id,
                travel = flight.travel,
                departure = flight.departure,
                arrival = flight.arrival,
                dateGo = flight.dateGo,
                timeDepartureGo = flight.timeDepartureGo,
                timeArrivalGo = flight.timeArrivalGo,
                dateBack = flight.dateBack ?? null,
                timeDepartureBack = flight.timeDepartureBack ?? null,
                timeArrivalBack = flight.timeArrivalBack ?? null,
                duration = flight.duration,
                totalAmountEconomic = flight.totalAmountEconomic,
                totalAmountFirstClass = flight.totalAmountFirstClass,
                priceDefault = flight.priceDefault,
                freeEconomicSeats = flight.freeEconomicSeats,
                freeFirstClassSeats = flight.freeFirstClassSeats
            };
        }
    }
}

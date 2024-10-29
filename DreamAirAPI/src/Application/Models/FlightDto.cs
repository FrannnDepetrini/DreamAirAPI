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
        public int Id { get; set; }
        public string Travel {  get; set; }
        public string Departure { get; set; }
        public string Arrival { get; set; }
        public DateTime DateGo { get; set; }
        public string TimeDepartureGo { get; set; }
        public string TimeArrivalGo { get; set; }

        public DateTime? DateBack { get; set; }
        public string? TimeDepartureBack { get; set; }
        public string? TimeArrivalBack { get; set; }
        public string Duration { get; set; }
        public int TotalAmountEconomic { get; set; }
        public int TotalAmountFirstClass { get; set; }
        public float PriceDefault { get; set; }
        public int FreeEconomicSeats { get; set; }
        public int FreeFirstClassSeats { get; set; }
        public string Airline {  get; set; }
        
        public static FlightDto Create(Flight flight)
        {
            
            return new FlightDto
            {
                Id = flight.Id,
                Travel = flight.Travel,
                Departure = flight.Departure,
                Arrival = flight.Arrival,
                DateGo = flight.DateGo,
                TimeDepartureGo = flight.TimeDepartureGo,
                TimeArrivalGo = flight.TimeArrivalGo,
                DateBack = flight.DateBack ?? null,
                TimeDepartureBack = flight.TimeDepartureBack ?? null,
                TimeArrivalBack = flight.TimeArrivalBack ?? null,
                Duration = flight.Duration,
                TotalAmountEconomic = flight.TotalAmountEconomic,
                TotalAmountFirstClass = flight.TotalAmountFirstClass,
                PriceDefault = flight.PriceDefault,
                FreeEconomicSeats = flight.FreeEconomicSeats,
                FreeFirstClassSeats = flight.FreeFirstClassSeats,
                Airline = flight.Airline
            };
        }
    }
}

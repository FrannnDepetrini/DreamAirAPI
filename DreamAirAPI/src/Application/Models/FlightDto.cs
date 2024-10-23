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
        public string departure { get; set; }
        public string arrival { get; set; }
        public DateTime date { get; set; }
        public string timeDeparture { get; set; }
        public string timeArrival { get; set; }
        public string duration { get; set; }
        public int totalAmountEconomic { get; set; }
        public int totalAmountFirstClass { get; set; }
        public float priceDefault { get; set; }
        public int freeEconomicSeats { get; set; }
        public int freeFirstClassSeats { get; set; }
        public List<TicketDto> tickets { get; set; } = new List<TicketDto>();

        public static FlightDto Create(Flight flight)
        {
            var listMapped = flight.tickets.Select(tck =>
            {
                return TicketDto.Create(tck);
            });
            return new FlightDto
            {
                id = flight.id,
                departure = flight.departure,
                arrival = flight.arrival,
                date = flight.date,
                timeDeparture = flight.timeDeparture,
                timeArrival = flight.timeArrival,
                duration = flight.duration,
                totalAmountEconomic = flight.totalAmountEconomic,
                totalAmountFirstClass = flight.totalAmountFirstClass,
                priceDefault = flight.priceDefault,
                freeEconomicSeats = flight.freeEconomicSeats,
                freeFirstClassSeats = flight.freeFirstClassSeats,
                tickets = listMapped.ToList()
            };
        }
    }
}

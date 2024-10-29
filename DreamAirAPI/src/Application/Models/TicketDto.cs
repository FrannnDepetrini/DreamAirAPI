using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class TicketDto
    {
        public int Id { get; set; }
        public string Seat { get; set; } //numero de asiento
        public string ClassSeat { get; set; }
        public string State { get; set; }
        public double Price { get; set; }

        public string FullName { get; set; }
        public int Dni { get; set; }
        public string TimeDepartureGo { get; set; }

        public string TimeArrivalGo { get; set; }
        public DateTime DateGo {  get; set; }

        public string? TimeDepartureBack { get; set; }

        public string? TimeArrivalBack { get; set; }
        public DateTime? DateBack { get; set; }

        public string Airline { get; set; }



        public static TicketDto Create(Ticket ticket) 
        {
            return new TicketDto
            {
                Id = ticket.Id,
                Seat = ticket.Seat,
                ClassSeat = ticket.ClassSeat,
                State = ticket.State,
                Price = ticket.Price,
                FullName = $"{ticket.User.Name} {ticket.User.LastName}",
                Dni = ticket.User.Dni,
                TimeDepartureGo = ticket.Flight.TimeDepartureGo,
                TimeArrivalGo = ticket.Flight.TimeArrivalGo,
                DateGo = ticket.Flight.DateGo,
                TimeDepartureBack = ticket.Flight.TimeDepartureBack ?? null,
                TimeArrivalBack = ticket.Flight.TimeArrivalBack ?? null,
                DateBack = ticket.Flight.DateBack ?? null,
                Airline = ticket.Flight.Airline
            };

        }

    }
}

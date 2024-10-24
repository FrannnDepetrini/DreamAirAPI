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
        public int id { get; set; }
        public string Seat { get; set; } //numero de asiento
        public string classSeat { get; set; }
        public string State { get; set; }
        public double Price { get; set; }

        public string fullName { get; set; }
        public int dni { get; set; }
        public string timeDepartureGo { get; set; }

        public string timeArrivalGo { get; set; }
        public DateTime dateGo {  get; set; }

        public string? timeDepartureBack { get; set; }

        public string? timeArrivalBack { get; set; }
        public DateTime? dateBack { get; set; }



        public static TicketDto Create(Ticket ticket) 
        {
            return new TicketDto
            {
                id = ticket.id,
                Seat = ticket.Seat,
                classSeat = ticket.classSeat,
                State = ticket.State,
                Price = ticket.Price,
                fullName = $"{ticket.user.name} {ticket.user.lastName}",
                dni = ticket.user.dni,
                timeDepartureGo = ticket.flight.timeDepartureGo,
                timeArrivalGo = ticket.flight.timeArrivalGo,
                dateGo = ticket.flight.dateGo,
                timeDepartureBack = ticket.flight.timeDepartureBack ?? null,
                timeArrivalBack = ticket.flight.timeArrivalBack ?? null,
                dateBack = ticket.flight.dateBack ?? null
            };

        }

    }
}

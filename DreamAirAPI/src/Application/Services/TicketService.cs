using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class TicketService : ITicketService
    {

        private readonly ITicketRepository _ticketRepository;
        public TicketService(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public int Create(string classSeat, UserClient client, Flight flight)
        {
            Ticket ticket1 = new Ticket
            {
                classSeat = classSeat,
                user = client,
                flight = flight
            };

            flight.CalculateSeat(classSeat);
            ticket1.CalculatePrice();
            ticket1.SeatSelected();
            return _ticketRepository.Create(ticket1);
        }
    }
}
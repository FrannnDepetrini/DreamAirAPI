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
        private readonly IUserClientRepository _userClientRepository;
        public TicketService(ITicketRepository ticketRepository, IUserClientRepository userClientRepository)
        {
            _ticketRepository = ticketRepository;
            _userClientRepository = userClientRepository;
        }

        public int Create(string classSeat, int id, Flight flight)
        {
            var clientFound = _userClientRepository.GetById(id);
            if (clientFound == null) throw new Exception("User not found");
            Ticket ticket1 = new Ticket
            {
                classSeat = classSeat,
                user = clientFound,
                flight = flight
            };

            flight.CalculateSeat(classSeat);
            ticket1.CalculatePrice();
            ticket1.SeatSelected();
            return _ticketRepository.Create(ticket1);
        }
    }
}
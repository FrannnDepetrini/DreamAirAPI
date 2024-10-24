using Application.Interfaces;
using Application.Models;
using Application.Models.Requests;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class TicketService : ITicketService
    {

        private readonly ITicketRepository _ticketRepository;
        private readonly IUserClientRepository _userClientRepository;
        private readonly IFlightRepository _flightRepository;
        public TicketService(ITicketRepository ticketRepository, IUserClientRepository userClientRepository, IFlightRepository flightRepository)
        {
            _ticketRepository = ticketRepository;
            _userClientRepository = userClientRepository;
            _flightRepository = flightRepository;
        }

        public int Create(TicketRequest ticket, int userId)
        {
            var flightFound = _flightRepository.GetById(ticket.flightId);
            if (flightFound == null) throw new Exception("Flight not found");
            var clientFound = _userClientRepository.GetById(userId);
            if (clientFound == null) throw new Exception("User not found");
            Ticket ticket1 = new Ticket
            {
                classSeat = ticket.classSeat,
                user = clientFound,
                flight = flightFound
            };

            flightFound.CalculateSeat(ticket.classSeat);
            ticket1.CalculatePrice();
            ticket1.SeatSelected();
            return _ticketRepository.Create(ticket1);
        }
    }
}
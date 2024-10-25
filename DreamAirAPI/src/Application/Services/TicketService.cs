using Application.Interfaces;
using Application.Models;
using Application.Models.Requests;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
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
            if (flightFound == null) throw new Exception("Flight not found.");
            var clientFound = _userClientRepository.GetById(userId);
            if (clientFound == null) throw new Exception("User not found.");
            if (ticket.classSeat != "Economic" && ticket.classSeat != "FirstClass")
            {
                throw new Exception("Invalid class seat. Only 'Economic' or 'FirstClass' are allowed.");
            }
            if (ticket.classSeat == "FirstClass" && flightFound.freeFirstClassSeats == flightFound.totalAmountFirstClass || ticket.classSeat == "Economic" && flightFound.freeEconomicSeats == flightFound.totalAmountEconomic) throw new Exception("No hay tickets disponibles");
            


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

        public int Delete(int ticketId, int userId)
        {
            var ticketFound = _ticketRepository.GetById(ticketId);
            if (ticketFound == null) throw new Exception("Ticket not found.");
            var clietnFound = _userClientRepository.GetById(userId);
            if (clietnFound == null) throw new Exception("User not found.");
            if (ticketFound.user.id == clietnFound.id)
            {
                return _ticketRepository.Delete(ticketFound);

            }
            throw new Exception("The specified ticket does not belong to the user.");
        }
            
        
    }
}
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
    public class TicketService: ITicketService
    {

        private readonly ITicketRepository _ticketRepository;
        public TicketService(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public int Create(Ticket ticket) { 
            return _ticketRepository.Create(ticket);
        }
    }
}

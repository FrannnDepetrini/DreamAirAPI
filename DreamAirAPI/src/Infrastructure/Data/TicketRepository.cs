using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class TicketRepository : ITicketRepository
    {
        private readonly ApplicationContext _context;

        public TicketRepository(ApplicationContext context) { _context = context; }

        public int Create(Ticket ticket)
        {
            _context.Set<Ticket>().Add(ticket);
            _context.SaveChanges();
            return 1;
        }
    }
}

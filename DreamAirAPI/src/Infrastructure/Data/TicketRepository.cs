using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
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

        public int Delete(Ticket ticket)
        {
            _context.Set<Ticket>().Remove(ticket);
            _context.SaveChanges();
            return 1;
        }

        public Ticket GetById(int id)
        {
            return _context.Set<Ticket>().Include(t => t.User).FirstOrDefault(t => t.Id == id);
        }
    }
}

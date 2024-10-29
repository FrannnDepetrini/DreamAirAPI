using Application.Interfaces;
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
    public class UserClientRepository : IUserClientRepository
    {
        private readonly ApplicationContext _context;
        public UserClientRepository(ApplicationContext context)
        {
            _context = context;
        }

        public int Create(UserClient client)
        {
            _context.Set<UserClient>().Add(client);
            _context.SaveChanges();
            return 1;
        }


        public List<UserClient> Get()
        {
            return _context.Set<UserClient>().Include(uc => uc.Tickets).ThenInclude(t => t.Flight).ToList();
        }


        public UserClient GetById(int id)
        {
            return _context.Set<UserClient>().Include(uc => uc.Tickets).ThenInclude(t => t.Flight).FirstOrDefault(uc => uc.Id == id);

        }


        public int Delete(UserClient clientFound)
        {
            _context.Set<UserClient>().Remove(clientFound);
            _context.SaveChanges();
            return 1;

        }

        public List<Ticket> GetTickets(int id)
        {
            return _context.Set<UserClient>()
        .Include(uc => uc.Tickets)
            .ThenInclude(ticket => ticket.Flight)
        .Include(uc => uc.Tickets)
            .ThenInclude(ticket => ticket.User) // Incluir el usuario relacionado
        .Where(uc => uc.Id == id)
        .SelectMany(uc => uc.Tickets)
        .ToList();
        }
    }
}
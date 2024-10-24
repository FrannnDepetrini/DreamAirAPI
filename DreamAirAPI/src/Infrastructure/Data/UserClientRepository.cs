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
    public class UserClientRepository: IUserClientRepository
    {
        private readonly ApplicationContext _context;
        public UserClientRepository(ApplicationContext context  )
        {
            _context = context;
        }

        public int Create(UserClient client)
        {
            _context.Set<UserClient>().Add( client );
            _context.SaveChanges();
            return 1;
        }
        

        public List<UserClient> Get()
        {
            return _context.Set<UserClient>().Include(uc => uc.tickets).ThenInclude(t => t.flight).ToList();
        }

        
        public UserClient GetById(int id) 
        {
            return _context.Set<UserClient>().Include(uc => uc.tickets).ThenInclude(t => t.flight).FirstOrDefault(uc => uc.id == id);

        }

        public UserClient GetByEmail(string email)
        {
            return _context.Set<UserClient>().FirstOrDefault(uc => uc.email == email);

        }
        public int Delete(int id)
        {
            UserClient? clientFound = _context.Set<UserClient>().Find(id);

            if (clientFound != null) {
                _context.Set<UserClient>().Remove(clientFound);
                _context.SaveChanges();
                return 1;
                } else
            {
                return 0;
            }
        }

        public List<Ticket> GetTickets(int id)
        {
            return _context.Set<UserClient>().Include(uc => uc.tickets).Where(uc => uc.id == id).SelectMany(uc => uc.tickets).ToList();
        }
    }
}

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
        


        
        public UserClient GetById(int id) 
        {
            return _context.Set<UserClient>().Include(uc => uc.tickets).ThenInclude(t=>t.flight).FirstOrDefault(uc => uc.id == id);

        }
        

    }
}

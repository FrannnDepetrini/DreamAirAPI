using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class UserRepository: IUserRepository
    {
        private readonly ApplicationContext _context;

        public UserRepository(ApplicationContext context)
        {
            _context = context;
        }


        public List<User> Get()
        {
            return _context.Set<User>().ToList();
        }

        public User GetByEmail(string email) 
        {
            return _context.Set<User>().FirstOrDefault(u => u.email == email);
        }

        public User GetById(int id)
        {
            return _context.Set<User>().Find(id);
        }

        public User UpdateRole(User user, string newRole) 
        {
            user.role = newRole;
            _context.Set<User>().Update(user);
            _context.SaveChanges();

            return user;
        }

        public User Delete(User user) 
        {
            _context.Set<User>().Remove(user);
            _context.SaveChanges();

            return user;
        }

    }
}

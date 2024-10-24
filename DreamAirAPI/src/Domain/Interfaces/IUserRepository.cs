using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUserRepository
    {
        List<User> Get();
        User GetByEmail(string email);

        User GetById(int id);

        User UpdateRole(User user, string newRole);

        User Delete(User user);
    }
}

using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUserService
    {
        List<User> Get();
        User GetById(int id);

        User UpdateRole(string newRole, int id);

        User Delete(int id);
    }
}

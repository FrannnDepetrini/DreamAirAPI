using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUserClientRepository
    {
        int Create(UserClient client);

        List<UserClient> Get();
        UserClient GetById(int id);
        UserClient GetByEmail(string email);

        int Delete(int id);

        List<Ticket> GetTickets(int id);
    }
}

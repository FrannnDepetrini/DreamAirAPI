using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ITicketService
    {
        int Create(string classSeat, int id, Flight flight);

        //int Update(TicketUpdateRequest ticket);

    }
}
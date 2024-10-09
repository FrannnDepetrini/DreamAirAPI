using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IFlightService
    {
        int Create(Flight flight);
        List<Flight> Get();
        Flight GetById(int id);

        int Delete(int id);

        int Update(int id, Flight flight);
        
            
    }
}

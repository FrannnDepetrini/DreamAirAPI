using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IFlightRepository
    {
        int Create(Flight flight);
        List<Flight> Get();
        Flight GetById(int id);

        int Delete(Flight flightFound);

        int Update(Flight flightFound, Flight flight);
    }
}

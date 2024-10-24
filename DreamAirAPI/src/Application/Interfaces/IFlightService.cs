using Application.Models;
using Application.Models.Requests;
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
        int Create(FlightRequest flight, int id);
        List<FlightDto> Get();
        FlightDto GetById(int id);

        int Delete(int id);

        int Update(int id, FlightUpdateRequest flight);
        
            
    }
}

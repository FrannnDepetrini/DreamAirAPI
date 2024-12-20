﻿using Application.Models;
using Application.Models.Requests;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUserAirlineService
    {
         List<string> GetAirlines();

        int Create(UserAirlineRequest userAirline);

        List<FlightDto> GetFlights(int id);

    }
}

﻿using Application.Interfaces;
using Application.Models;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class FlightService : IFlightService
    {
        private readonly IFlightRepository _flightRepository;
        public FlightService(IFlightRepository flightRepository)
        {
            _flightRepository = flightRepository;
        }
        

        public List<Flight> Get()
        {
             return _flightRepository.Get();
        }

        public Flight GetById(int id)
        {
            return _flightRepository.GetById(id);
        }

        public int Delete(int id)
        {
            return _flightRepository.Delete(id);
        }

        public int Create(Flight flight)
        {
            return _flightRepository.Create(flight);
        }

        public int Update(int id ,Flight flight)
        {
            return _flightRepository.Update(id, flight);
        }

    }
}

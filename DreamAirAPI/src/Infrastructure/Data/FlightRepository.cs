﻿using Application.Models;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class FlightRepository : IFlightRepository
    {
        private readonly ApplicationContext _context;

        public FlightRepository(ApplicationContext context) { _context = context; }

        public int Create(Flight flight) { 
            _context.Set<Flight>().Add(flight);
            _context.SaveChanges();
            return 1;
        }
        public List<Flight> Get() {
            
            
            return _context.Set<Flight>().Include(f => f.tickets).ThenInclude(t => t.user).ToList();
        }
        public Flight GetById(int id) {
            return _context.Set<Flight>().Include(f => f.tickets).ThenInclude(t => t.user).FirstOrDefault(f => f.id == id);
        }

        public int Delete(int id) {
            Flight? flightFound = _context.Set<Flight>().Find(id);
            if (flightFound != null)
            {

                _context.Set<Flight>().Remove(flightFound);
            _context.SaveChanges();
                return 1;   
            }
            return 0;
        }

        public int Update(int id, Flight flight) {
            Flight flightFound = _context.Set<Flight>().Find(id);
            if (flightFound != null)
            {
                flightFound.dateGo = flight.dateGo;
                flightFound.timeArrivalGo = flight.timeArrivalGo;
                flightFound.timeDepartureGo = flight.timeDepartureGo;
                flightFound.dateBack = flight.dateBack ?? null;
                flightFound.timeArrivalBack = flight.timeArrivalBack ?? null;
                flightFound.timeDepartureBack = flight.timeDepartureBack ?? null;
                _context.Set<Flight>().Update(flightFound);
                _context.SaveChanges();
            return 1;
            }
            return 0;
        }
    }
}

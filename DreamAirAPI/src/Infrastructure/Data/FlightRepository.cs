using Application.Models;
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

        public int Create(Flight flight)
        {
            _context.Set<Flight>().Add(flight);
            _context.SaveChanges();
            return 1;
        }
        public List<Flight> Get()
        {


            return _context.Set<Flight>().Include(f => f.Tickets).ThenInclude(t => t.User).ToList();
        }
        public Flight GetById(int id)
        {
            return _context.Set<Flight>().Include(f => f.UserAirline).Include(f => f.Tickets).ThenInclude(t => t.User).FirstOrDefault(f => f.Id == id);
        }

        public int Delete(Flight flightFound)
        {

            _context.Set<Flight>().Remove(flightFound);
            _context.SaveChanges();
            return 1;

        }

        public int Update(Flight flightFound, Flight flight)
        {

            flightFound.DateGo = flight.DateGo;
            flightFound.TimeArrivalGo = flight.TimeArrivalGo;
            flightFound.TimeDepartureGo = flight.TimeDepartureGo;
            flightFound.DateBack = flight.DateBack ?? null;
            flightFound.TimeArrivalBack = flight.TimeArrivalBack ?? null;
            flightFound.TimeDepartureBack = flight.TimeDepartureBack ?? null;
            flightFound.Duration = flight.Duration;
            _context.Set<Flight>().Update(flightFound);
            _context.SaveChanges();
            return 1;

        }
    }
}
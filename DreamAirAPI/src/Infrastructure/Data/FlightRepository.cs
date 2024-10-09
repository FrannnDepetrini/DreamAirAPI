using Domain.Entities;
using Domain.Interfaces;
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
            
            
            return _context.Set<Flight>().ToList() ;
        }
        public Flight GetById(int id) {
            return _context.Set<Flight>().Find(id);
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

        public int Update(Flight flight) {
            _context.Set<Flight>().Update(flight);
            _context.SaveChanges();
            return 1;
        }
    }
}

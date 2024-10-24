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
     public class UserAirlineRepository : IUserAirlineRepository
    {
        private readonly ApplicationContext _context;
        public UserAirlineRepository(ApplicationContext context) 
        {
            _context = context;        
        }

        public List<string> GetAirlines()
        {
          return  _context.Set<UserAirline>().Select(user => user.name).ToList();
        }

        public int Create(UserAirline airline)
        {
            _context.Set<UserAirline>().Add(airline);
            _context.SaveChanges();
            return 1;
        }

        public List<Flight> GetFlights(int id) 
        {
            return _context.Set<UserAirline>().Include(ua => ua.flights).Where(ua => ua.id == id).SelectMany(ua => ua.flights).ToList();
        }
    }
}

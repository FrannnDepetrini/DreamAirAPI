using Application.Interfaces;
using Application.Models;
using Application.Models.Requests;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserAirlineService : IUserAirlineService
    {
        private readonly IAutenticationService _authenticationService;
        private readonly IUserAirlineRepository _userAirlineRepository;
        private readonly IUserRepository _userRepository;

        public UserAirlineService(IUserAirlineRepository userAirlineRepository, IAutenticationService autenticationService, IUserRepository userRepository) 
        {
            _userAirlineRepository = userAirlineRepository;
            _authenticationService = autenticationService;
            _userRepository = userRepository;
        }

        public List<string> GetAirlines()
        {
                return _userAirlineRepository.GetAirlines();
        }

        public int Create(UserAirlineRequest airline)
        {
            var emailFound = _userRepository.GetByEmail(airline.Email);
            if (emailFound != null) throw new Exception("This email already exists");
            UserAirline airline1 = new UserAirline
            {
                Email = airline.Email,
                Password = _authenticationService.GenerateHash(airline.Password),
                Name = airline.Name,
                Role= "airline"

            };

            return _userAirlineRepository.Create(airline1);
        }

        public List<FlightDto> GetFlights(int id) 
        {
            var listMapped = _userAirlineRepository.GetFlights(id).Select(f => FlightDto.Create(f)).ToList();
            return listMapped;
        }
    }
}

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

        public UserAirlineService(IUserAirlineRepository userAirlineRepository, IAutenticationService autenticationService) 
        {
            _userAirlineRepository = userAirlineRepository;
            _authenticationService = autenticationService;
        }

        public List<string> GetAirlines()
        {
                return _userAirlineRepository.GetAirlines();
        }

        public int Create(UserAirlineRequest airline)
        {
            UserAirline airline1 = new UserAirline
            {
                email = airline.email,
                password = _authenticationService.GenerateHash(airline.password),
                name = airline.name,
                role= "airline"

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

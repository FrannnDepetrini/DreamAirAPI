using Application.Interfaces;
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
        private readonly IUserAirlineRepository _userAirlineRepository;

        public UserAirlineService(IUserAirlineRepository userAirlineRepository) 
        {
            _userAirlineRepository = userAirlineRepository;
        }

        public List<string> GetAirlines()
        {
                return _userAirlineRepository.GetAirlines();
        }

        public int Create(UserAirline airline)
        {
            return _userAirlineRepository.Create(airline);
        }
    }
}

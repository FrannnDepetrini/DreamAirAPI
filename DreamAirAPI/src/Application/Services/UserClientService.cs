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
    public class UserClientService : IUserClientService
    {
        private readonly IAutenticationService _authenticationService;
        private readonly IUserClientRepository _userClientRepository;
        private readonly IUserRepository _userRepository;

        public UserClientService(IUserClientRepository userClientRepository, IAutenticationService autenticationService, IUserRepository userRepository)
        {
            _userClientRepository = userClientRepository;
            _authenticationService = autenticationService;
            _userRepository = userRepository;
        }

        public int Create(UserClientRequest client)
        {
            var emailFound = _userRepository.GetByEmail(client.Email);
            if (emailFound != null) throw new Exception("This email already exists");


            UserClient client1 = new UserClient
            {
                Email = client.Email,
                Password = _authenticationService.GenerateHash(client.Password),
                Name = client.Name,
                LastName = client.LastName,
                Nationality = client.Nationality,
                Dni = client.Dni,
                Phone = client.Phone,
                Age = client.Age
            };

            return _userClientRepository.Create(client1);
        }

        public List<UserClientDto> Get()
        {

            var listMapped = _userClientRepository.Get().Select((uc) => UserClientDto.Create(uc)).ToList();
            return listMapped;
        }

        public UserClientDto GetById(int id)
        {

            return UserClientDto.Create(_userClientRepository.GetById(id));
        }

        public int Delete(int id)
        {
            var userFound = _userClientRepository.GetById(id);
            if (userFound == null) throw new Exception("User not found");
            return _userClientRepository.Delete(userFound);
        }

        public List<TicketDto> GetTickets(int id)
        {
            var listMapped = _userClientRepository.GetTickets(id).Select(t => TicketDto.Create(t)).ToList();
            return listMapped;
        }
    }
}

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
    public class UserClientService: IUserClientService
    {
        private readonly IAutenticationService _authenticationService;
        private readonly IUserClientRepository _userClientRepository;
        
        public UserClientService(IUserClientRepository userClientRepository, IAutenticationService autenticationService)
        {
             _userClientRepository = userClientRepository;
             _authenticationService = autenticationService;
        }

        public int Create(UserClientRequest client)
        {

            UserClient client1 = new UserClient
            {
                email = client.email,
                password = _authenticationService.GenerateHash(client.password),
                name = client.name,
                lastName = client.lastName,
                nationality = client.nationality,
                dni = client.dni,
                phone = client.phone,
                age = client.age
            };

            return  _userClientRepository.Create(client1);
        }

        public List<UserClientDto> Get() {

            var listMapped = _userClientRepository.Get().Select((uc) => UserClientDto.Create(uc)).ToList();
            return listMapped;
        }
       
        public UserClientDto GetById(int id) 
        {

            return UserClientDto.Create(_userClientRepository.GetById(id));
        }

        public UserClientDto GetByEmail(string email)
        {

            return UserClientDto.Create(_userClientRepository.GetByEmail(email));
        }

        public int Delete(int id)
        {
            return _userClientRepository.Delete(id);
        }
    }
}

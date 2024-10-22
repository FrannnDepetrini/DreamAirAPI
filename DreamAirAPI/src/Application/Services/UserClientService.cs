
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
    public class UserClientService: IUserClientService
    {
        private readonly IUserClientRepository _userClientRepository;
        
        public UserClientService(IUserClientRepository userClientRepository)
        {
             _userClientRepository = userClientRepository;
            
        }

        public int Create(UserClient client)
        {
            
            return  _userClientRepository.Create(client);
        }

        public List<UserClient> Get() {
            return _userClientRepository.Get();
        }
       
        public UserClient GetById(int id) 
        {
            return _userClientRepository.GetById(id);
        }

        public UserClient GetByEmail(string email)
        {
            return _userClientRepository.GetByEmail(email);
        }

        public int Delete(int id)
        {
            return _userClientRepository.Delete(id);
        }
    }
}

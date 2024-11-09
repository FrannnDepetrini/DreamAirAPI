using Application.Interfaces;
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
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public List<User> Get()
        {
            return _userRepository.Get();
        }

        public User GetById(int id)
        {
           return _userRepository.GetById(id);
        }

        public User UpdateRole(UserUpdateRequest role) 
        {
            var userFound = _userRepository.GetById(role.Id);
            if (userFound == null) throw new Exception("Not found");

            return _userRepository.UpdateRole(userFound, role.NewRole);
        }

        public User Delete(int id)
        {
            var userFound = _userRepository.GetById(id);
            if (userFound == null) throw new Exception("Not found");

            return _userRepository.Delete(userFound);
        }
    }
}

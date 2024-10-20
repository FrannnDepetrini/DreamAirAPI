using Application.Models.Requests;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IAutenticationService
    {
        UserClient ValidateUser(LoginRequest user);

        string Authenticate(LoginRequest user);
        string GenerateHash(string password);
    }
}

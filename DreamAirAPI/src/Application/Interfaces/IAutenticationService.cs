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
        User ValidateUser(LoginRequest userRequest);

        string Authenticate(LoginRequest userRequest);
        string GenerateHash(string password);
    }
}

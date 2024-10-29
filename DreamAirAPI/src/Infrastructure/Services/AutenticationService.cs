using Application.Interfaces;
using Application.Models.Requests;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class AutenticationService : IAutenticationService
    {
        private readonly IUserRepository _userRepository;

        private readonly AutenticationServiceOptions _options;


        public AutenticationService(IUserRepository userRepository, IOptions<AutenticationServiceOptions> options)
        {
            _userRepository = userRepository;
            _options = options.Value;
        }

        public User? ValidateUser(LoginRequest userRequest)
        {

            if (string.IsNullOrEmpty(userRequest.Email) || string.IsNullOrEmpty(userRequest.Password))
            {
                return null;
            }

            User? user = _userRepository.GetByEmail(userRequest.Email);

            if (user == null) return null;

            string passwordHashed = GenerateHash(userRequest.Password);

            if (passwordHashed == user.Password) return user;
            return null;
        }

        public string Authenticate(LoginRequest userRequest)
        {
            User? user = ValidateUser(userRequest);
            if (user == null) { throw new Exception("User authentication failed"); }

            var userClaims = new[]
            {
                new Claim("sub", user.Id.ToString()),
                new Claim("email", user.Email),
                new Claim("role", user.Role)
            };

            var seccurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_options.SecretForKey));

            var credentials = new SigningCredentials(seccurityKey, SecurityAlgorithms.HmacSha256);

            var jwtConfig = new JwtSecurityToken(
                issuer: _options.Issuer,
                audience: _options.Audience,
                claims: userClaims,
                DateTime.UtcNow,
                DateTime.UtcNow.AddHours(1),
                credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(jwtConfig);
        }

        public string GenerateHash(string password)
        {
            
            return HashGenerator.GenerateHash(password);
        }
        public class AutenticationServiceOptions
        {
            public const string AutenticacionService = "AutenticacionService";

            public string Issuer { get; set; }
            public string Audience { get; set; }
            public string SecretForKey { get; set; }
        }
    }
}
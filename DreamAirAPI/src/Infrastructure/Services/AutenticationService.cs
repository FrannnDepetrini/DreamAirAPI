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

            if (string.IsNullOrEmpty(userRequest.email) || string.IsNullOrEmpty(userRequest.password))
            {
                return null;
            }

            User? user = _userRepository.GetByEmail(userRequest.email);

            if (user == null) return null;

            string passwordHashed = GenerateHash(userRequest.password);

            if (passwordHashed == user.password) return user;
            return null;
        }

        public string Authenticate(LoginRequest userRequest)
        {
            User? user = ValidateUser(userRequest);
            if (user == null) { throw new Exception("User authentication failed"); }

            var userClaims = new[]
            {
                new Claim("sub", user.id.ToString()),
                new Claim("email", user.email),
                new Claim("role", user.role)
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
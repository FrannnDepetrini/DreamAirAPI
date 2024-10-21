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
        private readonly IUserClientRepository _userClientRepository;

        private readonly AutenticationServiceOptions _options;
        public AutenticationService(IUserClientRepository userClientRepository, IOptions<AutenticationServiceOptions> options)
        {
            _userClientRepository = userClientRepository;
            _options = options.Value;
        }

        public UserClient? ValidateUser(LoginRequest user)
        {
            if (string.IsNullOrEmpty(user.email) || string.IsNullOrEmpty(user.password)) 
            {
                return null;    
            }

            UserClient? userClient = _userClientRepository.GetByEmail(user.email);

            if (userClient == null) return null;

            string passwordHashed = GenerateHash(user.password);

            if (passwordHashed == userClient.password) return userClient;
            return null;
        }

        public string Authenticate(LoginRequest user) 
        {
            UserClient? userClient = ValidateUser(user);
            if (userClient == null) { throw new Exception("User authentication failed"); }

            var userClaims = new[]
            {
                new Claim("ID", userClient.id.ToString()),
                new Claim("Email", userClient.email),
                new Claim("Role", userClient.role)
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
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++) 
                {
                    builder.Append(bytes[i].ToString("x2"));    
                }
                return builder.ToString();
            }
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

using Application.Interfaces;
using Application.Models.Requests;
using Application.Services;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserAirlineController : ControllerBase
    {
        private readonly IUserAirlineService _userAirlineService;
        private readonly IAutenticationService _authenticationService;
        private readonly IUserRepository _userService;
        public UserAirlineController(IUserAirlineService userAirlineService, IAutenticationService autenticationService, IUserRepository userRepository)
        {
            _userAirlineService = userAirlineService;
            _authenticationService = autenticationService;  
            _userService = userRepository;
        }



        [HttpGet("[action]")]
        public IActionResult GetAirlines() 
        {
            return Ok(_userAirlineService.GetAirlines());
        }

        [HttpPost("[action]")]
        public IActionResult Create(UserAirlineRequest airline)
        {
            var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

            if (userRole == "airline")
            {
                return Ok(_userAirlineService.Create(airline));

            }
            return Forbid();
        }

        [HttpGet("[action]")]
        
        public IActionResult GetFlights()
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

            if (userRole == "airline")
            {
                return Ok(_userAirlineService.GetFlights(int.Parse(userId)));

            }
            return Forbid();
        }

        [HttpGet("[action]")]
        public IActionResult GetByEmail(int id)
        {

            var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

            if (userRole == "airline")
            {
                return Ok(_userService.GetById(id));
            }
            return Forbid();

        }


    }
}

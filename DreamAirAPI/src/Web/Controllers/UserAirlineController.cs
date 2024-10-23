using Application.Interfaces;
using Application.Models.Requests;
using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAirlineController : ControllerBase
    {
        private readonly IUserAirlineService _userAirlineService;
        private readonly IAutenticationService _authenticationService;
        public UserAirlineController(IUserAirlineService userAirlineService, IAutenticationService autenticationService)
        {
            _userAirlineService = userAirlineService;
            _authenticationService = autenticationService;   
        }
        [HttpGet("[action]")]
        public IActionResult GetAirlines() 
        {
            return Ok(_userAirlineService.GetAirlines());
        }
        [HttpPost("[action]")]
        public IActionResult Create(UserAirlineRequest airline)
        {

            UserAirline airline1 = new UserAirline
            {
                email = airline.email,
                password = _authenticationService.GenerateHash(airline.password),
                name = airline.name
               
            };
            return Ok(_userAirlineService.Create(airline1));
        }


    }
}

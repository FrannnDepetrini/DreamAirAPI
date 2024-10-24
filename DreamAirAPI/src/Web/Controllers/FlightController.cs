using Application.Interfaces;
using Application.Models;
using Application.Models.Requests;
using Application.Services;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FlightController : ControllerBase
    {
        private readonly IFlightService _flightService;
        private readonly IUserService _userService;
        public FlightController(IFlightService flightService, IUserService userService)
        {
            _flightService = flightService;
            _userService = userService;
        }


        [HttpGet("[action]")]
        public IActionResult Get()
        {
            return Ok(_flightService.Get());
        }
        [HttpGet("[action]")]
        public IActionResult GetById(int id)
        {
            var flight = _flightService.GetById(id);
            if (flight == null) 
            { 
                return NotFound();
            }
            
            return Ok(flight);
        }
       
        [HttpPost("[action]")]

        [Authorize]
        public IActionResult Create(FlightRequest flight)
        {
            int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "");
            if (userId == null) throw new Exception("ID Not found");
            
            return Ok(_flightService.Create(flight, userId));

        }

        [HttpDelete("[action]")]
        public IActionResult Delete([FromBody]int id)
        {
            return Ok(_flightService.Delete(id));
        }

        [HttpPut("[action]")]
        public IActionResult Update([FromBody] FlightUpdateRequest flight)
        {
            return Ok(_flightService.Update(flight.flightId, flight));
        }
    }
}

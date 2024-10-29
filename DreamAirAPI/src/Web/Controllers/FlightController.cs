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
       
        public FlightController(IFlightService flightService)
        {
            _flightService = flightService;
        }


        [HttpGet("[action]")]
        public IActionResult Get()
        {
            return Ok(_flightService.Get());
        }

        [HttpGet("get/{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var flight = _flightService.GetById(id);
            if (flight == null) 
            { 
                return NotFound();
            }
            
            return Ok(flight);
        }
       
        [HttpPost("[action]")]
        [Authorize(Policy = "AirlinePolicy")]
        public IActionResult Create(FlightRequest flight)
        {
            int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "");
            if (userId == null) throw new Exception("ID Not found");
            
            return Ok(_flightService.Create(flight, userId));

        }

        [HttpDelete("delete/{id}")]
        [Authorize(Policy = "AdminOrAirlinePolicy")]
        public IActionResult Delete([FromRoute] int id)
        {
            var userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "");
            if (userId == null) throw new Exception("ID Not found");
            var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

            return Ok(_flightService.Delete(id,userId, userRole));
        }

        [HttpPut("[action]")]
        [Authorize(Policy = "AirlinePolicy")]
        public IActionResult Update([FromBody] FlightUpdateRequest flight)
        {
            return Ok(_flightService.Update(flight));
        }
    }
}

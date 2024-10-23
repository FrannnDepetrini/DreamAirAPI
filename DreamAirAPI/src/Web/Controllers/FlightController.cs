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
            var listMapped = _flightService.Get().Select((f) => FlightDto.Create(f)).ToList();
            return Ok(listMapped);
        }
        [HttpGet("[action]")]
        public IActionResult GetById(int id)
        {
            return Ok(FlightDto.Create(_flightService.GetById(id)));
        }
       
        [HttpPost("[action]")]

        [Authorize]
        public IActionResult Create(FlightRequest flight)
        {
            int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "");
            var clientFound = _userService.GetById(userId);
            if(clientFound is UserAirline userAirline)
            {
                Flight flight1 = new Flight
                {
                    departure = flight.departure,
                    arrival = flight.arrival,
                    date = flight.date,
                    timeDeparture = flight.timeDeparture,
                    timeArrival = flight.timeArrival,
                    totalAmountEconomic = flight.totalAmountEconomic,
                    totalAmountFirstClass = flight.totalAmountFirstClass,
                    priceDefault = flight.priceDefault,
                    UserAirline = userAirline,
                    airline = userAirline.name,

                };
                flight1.CalculateDuration();
                return Ok(_flightService.Create(flight1));
            }
            return Forbid();

        }

        [HttpDelete("[action]")]
        public IActionResult Delete([FromBody]int id)
        {
            return Ok(_flightService.Delete(id));
        }

        [HttpPut("[action]")]
        public IActionResult Update([FromBody] FlightUpdateRequest flight)
        {
            Flight flight1 = new Flight { date = flight.date, timeDeparture = flight.timeDeparture, timeArrival = flight.timeArrival };
            return Ok(_flightService.Update(flight.flightId, flight1));
        }
    }
}

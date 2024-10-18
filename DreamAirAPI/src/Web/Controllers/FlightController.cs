using Application.Interfaces;
using Application.Models;
using Application.Models.Requests;
using Application.Services;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
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
        [HttpGet("[action]")]
        public IActionResult GetById(int id)
        {
            return Ok(FlightDto.Create(_flightService.GetById(id)));
        }
       
        [HttpPost("[action]")]
        public IActionResult Create(FlightRequest flight)
        {
            Flight flight1 = new Flight{
                departure = flight.departure,
                arrival = flight.arrival,
                date = flight.date,
                timeDeparture = flight.timeDeparture,
                timeArrival = flight.timeArrival,
                totalAmountEconomic = flight.totalAmountEconomic,
                totalAmountFirstClass = flight.totalAmountFirstClass,
                priceDefault = flight.priceDefault,
                airline = flight.airline, };
            flight1.CalculateDuration();
            return Ok(_flightService.Create(flight1));
        }

        [HttpDelete("[action]")]
        public IActionResult Delete(int id)
        {
            return Ok(_flightService.Delete(id));
        }

        [HttpPut("[action]")]
        public IActionResult Update(int id,Flight flight)
        {
            return Ok(_flightService.Update(id, flight));
        }
    }
}

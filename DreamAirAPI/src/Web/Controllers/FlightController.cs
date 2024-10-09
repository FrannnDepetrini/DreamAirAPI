using Application.Interfaces;
using Application.Models.Requests;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class FlightController : Controller
    {
        private readonly IFlightService _flightService;
        public FlightController (IFlightService flightService)
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
            return Ok(_flightService.GetById(id));
        }
        [HttpPost("[action]")]
        public IActionResult Create(FlightRequest flight)
        {
            return Ok(_flightService.Create(new Flight{ 
                departure= flight.departure,
                arrival = flight.arrival,
                date = flight.date,
                timeDeparture = flight.timeDeparture,
                timeArrival = flight.timeArrival,
                totalAmount = flight.totalAmount,
                priceDefault = flight.priceDefault,
                airline = flight.airline,


            }));
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

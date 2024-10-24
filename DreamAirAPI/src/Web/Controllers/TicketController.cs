using Application.Interfaces;
using Application.Models.Requests;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _ticketService;
        private readonly IFlightService _flightService;

        public TicketController(ITicketService ticketService, IFlightService flightService)
        {
            _ticketService = ticketService;
            _flightService = flightService;
        }
    }
}

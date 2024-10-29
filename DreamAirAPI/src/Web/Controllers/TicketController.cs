using Application.Interfaces;
using Application.Models.Requests;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Sockets;
using System.Security.Claims;

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

        [HttpPost("[action]")]
        [Authorize(Policy = "ClientPolicy")]
        public IActionResult Create(TicketRequest ticket)
        {
            int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "");
            
            return Ok(_ticketService.Create(ticket, userId));
           
        }

        [HttpDelete("delete/{ticketId}")]
        [Authorize(Policy = "ClientPolicy")]
        public IActionResult Delete([FromRoute] int ticketId)
        {
            int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "");
            return Ok(_ticketService.Delete(ticketId,userId));
            

        }
    }
}

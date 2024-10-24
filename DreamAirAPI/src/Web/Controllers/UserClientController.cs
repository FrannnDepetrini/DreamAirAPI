using Application.Interfaces;
using Application.Models;
using Application.Models.Requests;
using Application.Services;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserClientController : ControllerBase
    {
        private readonly IUserClientService _userClientService;
        private readonly IFlightService _flightService;
        private readonly ITicketService _ticketService;
        private readonly IAutenticationService _authenticationService;

        public UserClientController(IUserClientService userClientService, IFlightService flightService, ITicketService ticketService, IAutenticationService authenticationService)
        {
            _userClientService = userClientService;
            _flightService = flightService;
            _ticketService = ticketService;
            _authenticationService = authenticationService;

        }
        [HttpGet("[action]")]
        public IActionResult Get()
        {
            
            return Ok(_userClientService.Get());
        }


        [HttpGet("[action]")]
        public IActionResult GetById(int id)
        {
            var user = _userClientService.GetById(id);

            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpGet("[action]")]
        public IActionResult GetByEmail(string email)
        {
            var user = _userClientService.GetByEmail(email);
            if (user == null) 
            {
                return NotFound();
            }

            return Ok(user);
        }


        [HttpPost("[action]")]
        public IActionResult Create(UserClientRequest client)
        {
            return Ok(_userClientService.Create(client));
        }

        [HttpPost("[action]")]

        [Authorize]
        public IActionResult BuyTicket(TicketRequest ticket)
        {
           


            int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "");
            var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

            if (userRole == "cliente")
            {
                return Ok(_ticketService.Create(ticket, userId));
            }
            return Forbid();
        }

        [HttpDelete("[action]")]
        public IActionResult Delete(int id)
        {
            return Ok(_userClientService.Delete(id));
        }
    }

}
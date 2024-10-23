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
            var listMapped = _userClientService.Get().Select((uc) => UserClientDto.Create(uc)).ToList();
            return Ok(listMapped);
        }


        [HttpGet("[action]")]
        public IActionResult GetById(int id)
        {
            return Ok(UserClientDto.Create(_userClientService.GetById(id)));
        }

        [HttpGet("[action]")]
        public IActionResult GetByEmail(string email)
        {
            return Ok(UserClientDto.Create(_userClientService.GetByEmail(email)));
        }


        [HttpPost("[action]")]
        public IActionResult Create(UserClientRequest client)
        {

            UserClient client1 = new UserClient
            {
                email = client.email,
                password = _authenticationService.GenerateHash(client.password),
                name = client.name,
                lastName = client.lastName,
                nationality = client.nationality,
                dni = client.dni,
                phone = client.phone,
                age = client.age
            };
            return Ok(_userClientService.Create(client1));
        }

        [HttpPost("[action]")]

        [Authorize]
        public IActionResult BuyTicket(TicketRequest ticket)
        {
            Flight? flightFound = _flightService.GetById(ticket.flightId);
            if (flightFound == null) return StatusCode(404, "Vuelo no encontrado");


            int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "");
            UserClient? clientFound = _userClientService.GetById(userId);
            if (clientFound == null) return StatusCode(404, "Cliente no encontrado");
            var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

            if (userRole == "cliente")
            {
                return Ok(_ticketService.Create(ticket.classSeat, clientFound, flightFound));
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
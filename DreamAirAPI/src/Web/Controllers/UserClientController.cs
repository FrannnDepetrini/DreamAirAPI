using Application.Interfaces;
using Application.Models;
using Application.Models.Requests;
using Application.Services;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        [Authorize(Roles = "cliente")]
        public IActionResult BuyTicket(TicketRequest ticket)
        {
            Flight? flightFound = _flightService.GetById(ticket.flightId);
            UserClient? clientFound = _userClientService.GetById(1);
            Ticket ticket1 = new Ticket
            {
                classSeat = ticket.classSeat,
                State = ticket.State,
                user = clientFound,
                flight = flightFound                
            };

            flightFound.CalculateSeat(ticket.classSeat);
            ticket1.CalculatePrice();
            ticket1.SeatSelected();
            return Ok(_ticketService.Create(ticket1));
        }

        [HttpDelete("[action]")]
        public IActionResult Delete(int id)
        {
            return Ok(_userClientService.Delete(id));
        }
    }
        
}

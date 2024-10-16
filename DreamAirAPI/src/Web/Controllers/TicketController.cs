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
        [HttpPost]
        public IActionResult Create(TicketRequest ticket)
        {
            Ticket ticket1 = new Ticket
            {
                classSeat = ticket.classSeat,
                State = ticket.State,
                UserName = ticket.UserName,
                UserLastName = ticket.UserLastName,
                flight=ticket.flight,

            };
           ticket1.CalculatePrice();
           ticket1.SeatSelected();



        }

    }
}

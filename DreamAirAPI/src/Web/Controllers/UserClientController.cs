﻿using Application.Interfaces;
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
        [Authorize(Policy = "AdminPolicy")]
        public IActionResult Get()
        {
            
            return Ok(_userClientService.Get());
        }


        [HttpGet("get/{id}")]
        [Authorize(Policy = "AdminPolicy")]
        public IActionResult GetById([FromRoute] int id)
        {
            return Ok(_userClientService.GetById(id));
        }


        [HttpPost("[action]")]
        public IActionResult Create(UserClientRequest client)
        {
            return Ok(_userClientService.Create(client));
        }

        [HttpGet("[action]")]
        [Authorize(Policy = "ClientPolicy")]
        public IActionResult GetTickets()
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            
            return Ok(_userClientService.GetTickets(int.Parse(userId)));
            
        }

        
    }

}
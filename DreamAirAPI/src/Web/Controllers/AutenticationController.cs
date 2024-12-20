﻿using Application.Interfaces;
using Application.Models.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticationController : ControllerBase
    {
        private readonly IAutenticationService _autenticationService;

        public AutenticationController(IAutenticationService autenticationService)
        {
            _autenticationService = autenticationService;
        }
        [HttpPost("[action]")]
        public IActionResult Login(LoginRequest user)
        {

            return Ok(_autenticationService.Authenticate(user));
        }
    }
}
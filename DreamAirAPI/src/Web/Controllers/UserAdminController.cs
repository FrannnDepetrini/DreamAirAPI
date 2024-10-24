using Application.Interfaces;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserAdminController : ControllerBase
    {
        private readonly IUserService _userService;
      

        public UserAdminController(IUserService userService)
        {
            _userService = userService;
       
        }

        [HttpGet("[action]")]
        public IActionResult Get()
        {
            var userRole = User.Claims.FirstOrDefault(u => u.Type == ClaimTypes.Role)?.Value;
            if (userRole == null) return NotFound();

            if (userRole == "admin") {
                return Ok(_userService.Get());
            }

            throw new Exception("Not allowed");
        }
        
    }
}

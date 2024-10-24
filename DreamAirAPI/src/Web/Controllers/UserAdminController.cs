using Application.Interfaces;
using Application.Models.Requests;
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
        private readonly IUserClientService _userClientService;
        private readonly IUserAirlineService _userAirlineService;
      

        public UserAdminController(IUserService userService, IUserClientService userClientService, IUserAirlineService userAirlineService)
        {
            _userService = userService;
            _userClientService = userClientService;
            _userAirlineService = userAirlineService;
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

        [HttpPost("[action]")]
        public IActionResult CreateClient(UserClientRequest client)
        {
            return Ok(_userClientService.Create(client));
        }

        [HttpPost("[action]")]
        public IActionResult CreateAirline(UserAirlineRequest airline)
        {
            return Ok(_userAirlineService.Create(airline));
        }

        [HttpPut("[action]")]
        public IActionResult UpdateRole(string newRole, int id) 
        {
            return Ok(_userService.UpdateRole(newRole, id));
        }

        [HttpDelete("[action]")]

        public IActionResult Delete(int id) 
        {
            return Ok(_userService.Delete(id));
        }
    }
}

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
    [Authorize(Policy = "AdminPolicy")]
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

            
          return Ok(_userService.Get());
            
         
        }

        

       
        [HttpPut("update/{id}")]
        public IActionResult UpdateRole([FromRoute] int id,string newRole) 
        {
            return Ok(_userService.UpdateRole(newRole, id));
        }

        [HttpDelete("delete/{id}")]
        [Authorize(Policy = "AdminPolicy")]
        public IActionResult Delete([FromRoute] int id)
        {
            return Ok(_userService.Delete(id));
        }
    }
}

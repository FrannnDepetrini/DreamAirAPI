using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "AdminPolicy")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;



        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("[action]")]

        public IActionResult Get()
        {

           
                return Ok(_userService.Get());
           
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

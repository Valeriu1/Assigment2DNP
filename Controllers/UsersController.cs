using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Assigment2WebApi.Data;

namespace Assigment2WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {

        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<User>> ValidateUser([FromQuery] string username, [FromQuery] string password)
        {
            Console.WriteLine("Here");
            try
            {
                var user = await userService.ValidateUser(username, password);
                return Ok(user);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
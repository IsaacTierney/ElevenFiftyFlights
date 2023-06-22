using ElevenFiftyFlights.Services.User;
using Microsoft.AspNetCore.Mvc;
using ElevenFiftyFlights.Models.User;
using Microsoft.AspNetCore.Authorization;

namespace ElevenFiftyFlights.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUser([FromBody] UserRegister model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var registerResult = await _userService.RegisterUserAsync(model);
            if (registerResult)
            {
                return Ok("User was registered.");
            }
       
            return BadRequest("Could not registere.");
        }
    }
}

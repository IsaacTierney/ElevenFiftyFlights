using ElevenFiftyFlights.Services.User;
using Microsoft.AspNetCore.Mvc;
using ElevenFiftyFlights.Models.User;
using Microsoft.AspNetCore.Authorization;
using ElevenFiftyFlights.Models.Token;
using ElevenFiftyFlights.Services.Token;

namespace ElevenFiftyFlights.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;
        public UserController(IUserService userService, ITokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUser([FromBody] UserRegister model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); //this could be causing errors
            }

            var registerResult = await _userService.RegisterUserAsync(model);
            if (registerResult)
            {
                return Ok("User was registered.");
            }
       
            return BadRequest("Could not register.");
        }

        [HttpPost("~/api/Token")]
        public async Task<IActionResult> GetToken([FromBody] TokenRequest request)
        {
            if (!ModelState.IsValid)
            return BadRequest(ModelState);

            var tokenResponse = await _tokenService.GetTokenAsync(request);
            if (tokenResponse is null)
                return BadRequest("Invalid username or password");
            
            return Ok(tokenResponse);
        }

        // [Authorize]
        //  [HttpGet("{UserId:int}")]
        // public async Task<IActionResult> GetUserId([FromRoute] int UserId)
        // {
        //     var userIdDetail = await _userService.(UserId);

        //     if (userIdDetail is null)
        //     {
        //         return NotFound();
        //     }

        //     return Ok(userIdDetail);
        // }

         [HttpDelete("{UserId:int}")]
        public async Task<IActionResult> DeleteUserId([FromRoute] int UserId)
        {
            return await _userService.DeleteUserIdAsync(UserId)
                ? Ok($"User {UserId} was deleted successfully.")
                : BadRequest($"User {UserId} could not be deleted.");
        }

    }
}

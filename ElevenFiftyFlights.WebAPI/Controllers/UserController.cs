using ElevenFiftyFlights.Services.User;
using Microsoft.AspNetCore.Mvc;
using ElevenFiftyFlights.Models.User;

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
    }
}

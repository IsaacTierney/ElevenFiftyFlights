using ElevenFiftyFlights.Services.User;
using Microsoft.AspNetCore.Mvc;

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

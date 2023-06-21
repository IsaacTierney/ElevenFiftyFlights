using ElevenFiftyFlights.Services.PassengerId;
using Microsoft.AspNetCore.Mvc;

namespace ElevenFiftyFlights.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassengerIdController : ControllerBase
    {
        private readonly IPassengerIdService _passengerIdService;
        public PassengerIdController(IPassengerIdService passengerIdService)
        {
            _passengerIdService = passengerIdService;
        }
    }
}

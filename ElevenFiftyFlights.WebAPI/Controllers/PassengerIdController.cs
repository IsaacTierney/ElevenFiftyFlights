using ElevenFiftyFlights.Models.PassengerId;
using ElevenFiftyFlights.Services.PassengerId;
using ElevenFiftyFlights.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using ElevenFiftyFlights.Data;
using ElevenFiftyFlights.Models;

namespace ElevenFiftyFlights.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassengerIdController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IPassengerIdService _passengerIdService;
        private readonly UserId _userId;
        public PassengerIdController(IPassengerIdService passengerIdService)
        {
            _passengerIdService = passengerIdService;
        }

        // GET api Passenger
        [HttpGet]
        public async Task<IActionResult> GetPassengerId([FromBody] PassengerIdDetail model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var response = await _passengerIdService.GetPassengerIdById(model);
            if (response is not null)
                return Ok(response);

            return BadRequest("Could not retrieve passengerId.");
        }
        [HttpPost]
        public async Task<PassengerIdCreate?> BookingPassengerByPassengerIdAsync([FromBody] PassengerIdCreate model)
        {
            var passengerEntity = await _userId.GetUserIdAsync(model);

            // variable with a response equal to a backing field in a service then invoke the method
            // if fight exists and userId exists then
            // create a passengerId and
            var passengerIdEntity = new PassengerIdEntity();
            var ConfirmationNumber = new ConfirmationNumberEntity();
            // create a ConfirmationNumber
           return (passengerEntity);
    }
    }
}


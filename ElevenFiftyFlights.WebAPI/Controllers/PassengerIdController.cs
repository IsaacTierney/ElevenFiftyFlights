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
        public PassengerIdController(IPassengerIdService passengerIdService)
        {
            _passengerIdService = passengerIdService;
        }
        // Create PassengerId
        [HttpPost] //any parameter in these methods must be in the request from the consumer
        public async Task<IActionResult?> BookingPassengerByUserIdAsync([FromForm] PassengerIdBooking model)
        {
            var passengerDetail = await _passengerIdService.BookpassengerAsync(model);
            //two options from our service either the response or null
            if (passengerDetail == null) //this would be the issue
            {
                return BadRequest();
            }
            // inherit a ConfirmationNumber
            return Ok(passengerDetail);
        }
        // GET single PassengerId by Id
        [HttpGet("{PassengerId:int}")]
        public async Task<IActionResult> GetPassengerId([FromRoute] int passengerId)
        {
            var UserDetail = await _passengerIdService.GetPassengerDetailById(passengerId);
            if (UserDetail is null)
            {
                return NotFound();
            }
            return Ok(UserDetail);

        }
        // Get all Flights by UserId
        [HttpGet("{flightId:int}")]
        public async Task<IActionResult> GetFlightById([FromRoute] int FlightEntity)
        {
            var flightId = await _flightId.GetFlightByIdAsync/*getting error code checked*/(FlightEntity);
            if (flightId is null)
            {
                return NotFound();
            }
            return Ok(flightId);
        }
        // Delete Passenger
        public async Task<IActionResult> GetPassengerById([FromForm] int PassengerId)
        {
            var validPassengerId = await _passengerIdService.GetPassengerIdAsync(PassengerId);
            if (validPassengerId is null)
            {
                return NotFound();
            }
            return Ok(validPassengerId);
        }
    }
}



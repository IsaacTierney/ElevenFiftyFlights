using ElevenFiftyFlights.Models.PassengerId;
using ElevenFiftyFlights.Services.PassengerId;
using Microsoft.AspNetCore.Mvc;
using ElevenFiftyFlights.Data;
using ElevenFiftyFlights.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace ElevenFiftyFlights.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassengerIdController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly PassengerIdService _passengerIdService;
        public PassengerIdController(PassengerIdService passengerIdService)
        {
            _passengerIdService = passengerIdService;
        }
        // Create PassengerId
        [HttpPost] //any parameter in these methods must be in the request from the consumer
        public async Task<IActionResult?> BookingPassengerByUserIdAsync([FromForm] PassengerIdBooking model)
        {
            var passengerDetail = await _passengerIdService.BookPassengerAsync(model);
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
        [HttpGet("flightId/{userId:int}")]
        public async Task<IActionResult> GetAllFlightsById([FromRoute] int userId)
        {
            var getAllFlights = await _passengerIdService.GetAllFlightsAsync(userId);
            if (getAllFlights is null)
            {
                //if not then send a console writeline with a notFound
                return NotFound("List not found.");
            }
            return Ok(getAllFlights);
        }

        [Authorize]
        [HttpPut]
        //Put/ update
        // this requires tokens or claims to run properly
        public async Task<IActionResult> UpdatePassenger(PassengerIdBooking model)
        {
            var user = User.Identity as ClaimsIdentity; //get user claim object from built-in UserId
            var UserId = user?.FindFirst("Id"); // gettting the id claim
            var Id = int.Parse(UserId?.Value ?? "0"); //string turns into int through parsing
            var response = await _passengerIdService.UpdatePassengerAsync(model, Id);
            return Ok(response);
        }

        // DELETE api/PassengerId/5
        [HttpDelete("{passengerId:int}")]
        public async Task<IActionResult> DeletePassengerByIdAsync([FromRoute] int passengerId)
        {
            return await _passengerIdService.DeletePassengerByIdAsync(passengerId)
                ? Ok($"PassengerId {passengerId} was deleted successfully.")
                : BadRequest($"PassengerId {passengerId} could not be deleted.");
        }
    }
}


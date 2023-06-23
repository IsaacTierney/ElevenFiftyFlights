using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElevenFiftyFlights.Models.Airlines;
using ElevenFiftyFlights.Services.AirlineService;
using Microsoft.AspNetCore.Mvc;

namespace ElevenFiftyFlights.WebAPI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class AirlinesController : ControllerBase
    {
        private readonly IAirlinesService _airlinesService;
        public AirlinesController(IAirlinesService airlinesService)
        {
            _airlinesService = airlinesService;
        }

        [HttpPost]
        public async Task<IActionResult> AirlinesControllerAsync([FromBody] AirlinesCreate request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await _airlinesService.CreateAirlinesAsync(request);
            if (response is not null)
                return Ok(response);

            return BadRequest("Could not list airlines.");
        }


        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<AirlinesListItem>), 200)]
        public async Task<IActionResult> GetAllAirlines()
        {
            var airlines = await _airlinesService.GetAirlinesByIdAsync(airlines);
            return Ok(airlines);
        }

        [HttpGet("{airlineId:int}")]
        public async Task<IActionResult> GetAirlinesById([FromRoute] int airlinesIdId)
        {
            var detail = await _airlinesService.GetAirlinesByIdAsync(airlinesIdId);

            // Similar to our service method, we're using a ternary to determine our return type
            // If the returned value (detail) is not null, then return it with a 200 OK
            // Otherwise return a NotFound() 404 response
            return detail is not null
                ? Ok(detail)
               : NotFound();
        }

        // PUT
        [HttpPut]
        public async Task<IActionResult> UpdateAirlinesById([FromBody] AirlinesUpdate request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return await _airlinesService.UpdateAirlinesAsync(request)
                ? Ok("Airline updated successfully.")
                : BadRequest("Airline could not be updated.");
        }

        // DELETE
        [HttpDelete("{airlineId:int}")]
        public async Task<IActionResult> DeleteAirlines([FromRoute] int airlineIdId)
        {
            return await _airlinesService.DeleteAirlinesAsync(airlineIdId)
                ? Ok($"Note {airlineIdId} was deleted successfully.")
                : BadRequest($"Note {airlineIdId} could not be deleted.");
        }

    }

}
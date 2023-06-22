using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElevenFiftyFlights.Models.Airport;
using ElevenFiftyFlights.Services.Airport;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ElevenFiftyFlights.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AirportController : ControllerBase
	{
		private readonly IAirportService _airportService;
		public AirportController(IAirportService airportService)
		{
			_airportService = airportService;
		}

		[HttpPost("Register")]
		public async Task<IActionResult> RegisterAirport([FromBody] AirportRegister model)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var registerResult = await _airportService.RegisterAirportAsync(model);
			if (registerResult)
			{
				return Ok("Airport was registered.");
			}

			return BadRequest("Airport could not be registered.");
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElevenFiftyFlights.Models.Flight;
using ElevenFiftyFlights.Services.Flight;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ElevenFiftyFlights.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FlightController : ControllerBase
	{
		private readonly IFlightService _flightService;
		public FlightController(IFlightService flightService)
		{
			_flightService = flightService;
		}

		[HttpPost("Register")]
		public async Task<IActionResult> RegisterFlight([FromBody] FlightRegister model)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var registerResult = await _flightService.RegisterFlightAsync(model);
			if (registerResult)
			{
				return Ok("Flight was registered.");
			}

			return BadRequest("Flight could not be registered.");
		}
	}
}

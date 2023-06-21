using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
	}
}

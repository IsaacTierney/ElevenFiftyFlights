using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
	}
}

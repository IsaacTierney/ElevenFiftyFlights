using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    }
}
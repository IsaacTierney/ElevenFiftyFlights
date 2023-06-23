using ElevenFiftyFlights.Models.Flight;

namespace ElevenFiftyFlights.Services.Flight;

public interface IFlightService
{
	Task<bool> RegisterFlightAsync(FlightRegister model);
}

using ElevenFiftyFlights.Models.Airport;

namespace ElevenFiftyFlights.Services.Airport;

public interface IAirportService
{
	Task<bool> RegisterAirportAsync(AirportRegister model);
}

using ElevenFiftyFlights.Data;
using ElevenFiftyFlights.Data.Entities;
using ElevenFiftyFlights.Models.Flight;

namespace ElevenFiftyFlights.Services.Flight;

public class FlightService : IFlightService
{
	private readonly ApplicationDbContext _context;
	public FlightService(ApplicationDbContext context)
	{
		_context = context;
	}

	public async Task<bool> RegisterFlightAsync(FlightRegister model)
	{
		if (await GetFlightByAirlineIdAsync(model.AirlineId) != null || await GetFlightByOriginIdAsync(model.OriginId) != null)
			return false;

		FlightEntity entity = new()
		{
			AirlineId = model.AirlineId,
			OriginId = model.OriginId,
			DestinationId = model.DestinationId,
			DepartureTime = model.DepartureTime,
			TicketPrice = model.TicketPrice,
			Gate = model.Gate
		};

		_context.Flight.Add(entity);
		int numberOfChanges = await _context.SaveChangesAsync();

		return numberOfChanges == 1;
	}

	private async Task<FlightEntity> GetFlightByAirlineIdAsync(int airlineId)
	{
		return await _context.Flight.FirstOrDefaultAsync(flight => flight.AirlineId == airlineId);
	}

	private async Task<FlightEntity> GetFlightByOriginIdAsync(int originId)
	{
		return await _context.Flight.FirstOrDefaultAsync(flight => flight.OriginId == originId.ToLower);
	}
}
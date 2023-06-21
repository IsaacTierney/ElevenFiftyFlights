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
}
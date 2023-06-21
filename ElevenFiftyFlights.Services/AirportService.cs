using ElevenFiftyFlights.Data;
using ElevenFiftyFlights.Data.Entities;
using ElevenFiftyFlights.Models.Airport;

namespace ElevenFiftyFlights.Services.Airport;

public class AirportService : IAirportService
{
	private readonly ApplicationDbContext _context;
	public AirportService(ApplicationDbContext context)
	{
		_context = context;
	}

	public async Task<bool> RegisterAirportAsync(AirportRegister model)
	{
		AirportEntity entity = new()
		{
			Country = model.Country,
			City = model.City,
			State = model.State,
			Name = model.Name,
			Code = model.Code
		};

		_context.Airport.Add(entity);
		int numberOfChanges = await _context.SaveChangesAsync();

		return numberOfChanges == 1;
	}
}

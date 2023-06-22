using ElevenFiftyFlights.Data;
using ElevenFiftyFlights.Data.Entities;
using ElevenFiftyFlights.Models.Airport;
using Microsoft.EntityFrameworkCore;

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
		// if (await GetAirportByCodeAsync(model.Code) != null || await GetAirportByNameAsync(model.Name) != null)
		// 	return false;

		AirportEntity entity = new()
		{
			Country = model.Country,
			State = model.State,
			City = model.City,
			Name = model.Name,
			Code = model.Code
		};

		_context.Airport.Add(entity);
		int numberOfChanges = await _context.SaveChangesAsync();

		return numberOfChanges == 1;
	}

	// private async Task<AirportEntity> GetAirportByCodeAsync(string? code)
	// {
	// 	return await _context.Airport.FirstOrDefaultAsync(airport => airport.Code.ToLower() == code.ToLower());
	// }

	// private async Task<AirportEntity> GetAirportByNameAsync(string? name)
	// {
	// 	return await _context.Airport.FirstOrDefaultAsync(airport => airport.Name.ToLower() == name.ToLower());
	// }
}

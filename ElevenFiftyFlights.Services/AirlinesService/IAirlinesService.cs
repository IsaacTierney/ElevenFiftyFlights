using ElevenFiftyFlights.Models.Airlines;

namespace ElevenFiftyFlights.Services.AirlineService;

public interface IAirlinesService
{
    Task<AirlinesDetail?> CreateAirlinesAsync(AirlinesCreate request);
    Task<IEnumerable<AirlinesListItem>> GetAllAirlinesAsync();
    Task<AirlinesDetail?> GetAirlinesByIdAsync(int AirlinesId);
    Task<bool> UpdateAirlinesAsync(AirlinesUpdate request);
    Task<bool> DeleteAirlinesAsync(int noteId);
}
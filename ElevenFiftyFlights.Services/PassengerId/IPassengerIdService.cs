using ElevenFiftyFlights.Models.PassengerId;

namespace ElevenFiftyFlights.Services.PassengerId;

public interface IPassengerIdService
{
    Task<bool> BookingPassengerAsync(PassengerIdDetail model);
    Task<PassengerIdDetail?> GetPassengerIdByIdAsync(int passengerId);
}
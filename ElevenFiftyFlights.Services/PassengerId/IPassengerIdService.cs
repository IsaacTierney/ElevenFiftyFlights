using ElevenFiftyFlights.Models.PassengerId;

namespace ElevenFiftyFlights.Services.PassengerId;

public interface IPassengerIdService
{
    
    Task<PassengerIdCreate?> BookingPassengerById(PassengerIdCreate model);
    Task<PassengerIdDetail> GetPassengerIdById(PassengerIdDetail model);
    
}
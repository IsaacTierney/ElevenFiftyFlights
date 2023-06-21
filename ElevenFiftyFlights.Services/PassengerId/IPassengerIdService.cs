using ElevenFiftyFlights.Models.PassengerId;
using ElevenFiftyFlights.Models.Flight;

namespace ElevenFiftyFlights.Services.PassengerId;

public interface IPassengerIdService
{
    //Declaration for method implementations in the service 
    //Data model as return types     Method Name             (paramaters)
    Task<PassengerIdResponse?> GetPassengerIdAsync(PassengerIdResponse model);
    Task<PassengerIdDetail?> BookPassengerAsync(PassengerIdBooking model);
    Task<PassengerIdDetail> GetPassengerDetailById(int Id);
    Task<IEnumerable<PassengerFlightListItem>> GetAllFlightsAsync(int Id);
    Task<bool> UpdatePassengerAsync(PassengerIdBooking request, int userId);
    Task<bool> DeletePassengerByIdAsync(int passengerId);
}
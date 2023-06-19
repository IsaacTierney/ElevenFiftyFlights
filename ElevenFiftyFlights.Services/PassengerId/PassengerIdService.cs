using ElevenFiftyFlights.Data.Entities;
using ElevenFiftyFlights.Models.PassengerId;

namespace ElevenFiftyFlights.Services.PassengerId;

public class PassengerIdService : IPassengerIdService
{

    private readonly int _passengerId;
    public async Task<bool> BookingPassengerAsync(PassengerIdDetail model)
    {
        PassengerIdEntity entity = new()
        {
            Id = model.Id,
            UserId = model.UserId,
            ConfirmationNumber = model.ConfirmationNumber,
            FlightId = model.FlightId

        }; return true;
    }    
    //this part is under construction
    //  public async Task<PassengerIdDetail?> GetPassengerIdByIdAsync(int passengerId)
//     {
//         _passengerId = passengerId;
//          return(passengerId);
//     }
 }
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElevenFiftyFlights.Models.PassengerId;

public class PassengerIdDetail
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int ConfirmationNumber { get; set; }
    public int FlightId { get; set; }
}
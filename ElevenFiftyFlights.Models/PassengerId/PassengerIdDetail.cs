using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElevenFiftyFlights.Models.PassengerId;

public class PassengerIdDetail
{
    public int PassengerId { get; set; }
    public int UserId { get; set; }
    public string CFCode { get; set; } = string.Empty;
    public int FlightId { get; set; }
}
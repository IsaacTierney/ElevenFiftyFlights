using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElevenFiftyFlights.Models.PassengerId;

public class PassengerIdCreate
{
    public int PassengerId { get; set; }
    public int UserId { get; set; }
    public int ConfirmationNumber { get; set; }
    [ForeignKey("ElevenFiftyFlights(Flights)")]
    public int FlightId { get; set; }
}
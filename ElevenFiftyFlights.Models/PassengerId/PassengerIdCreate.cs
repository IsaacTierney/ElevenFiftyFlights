using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElevenFiftyFlights.Models.PassengerId;

public class PassengerIdCreate
{
    [Key]
    public int Id { get; set; }
    [Key]
    public int UserId { get; set; }
    public int ConfirmationNumber { get; set; }
    [ForeignKey("ElevenFiftyFlights(Flights)")]
    public int FlightId { get; set; }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElevenFiftyFlights.Models.PassengerId;

public class PassengerIdDetail
{
    [Key]
    public int Id { get; set; }
    [Required]
    public int UserId { get; set; }
    public int ConfirmationNumber { get; set; }
    [ForeignKey("ElevenFiftyFlights(Flights)")]
    public int FlightId { get; set; }
}
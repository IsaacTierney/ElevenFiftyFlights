using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElevenFiftyFlights.Data.Entities;

public class PassengerIdEntity

{
    [Key]
    public int Id { get; set; }
    [Required]
    public int UserId { get; set; }
    public int ConfirmationNumber { get; set; }
    [ForeignKey("ElevenFiftyFlights.Flights(Id)")]
    public int FlightId { get; set; }

}
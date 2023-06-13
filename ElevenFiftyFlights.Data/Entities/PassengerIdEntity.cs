using System.ComponentModel.DataAnnotations;

namespace ElevenFiftyFlights.Data.Entities;

public class PassengerIdEntity

{
    [Key]
    public int Id { get; set; }
    [Required]
    public int UserId { get; set; }
    public int ConfirmationNumber { get; set; }
    public int FlightId { get; set; }

}
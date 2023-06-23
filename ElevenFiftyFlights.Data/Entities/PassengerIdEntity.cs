using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElevenFiftyFlights.Data.Entities;

public class PassengerIdEntity

{
    [Key]
    public int PassengerId { get; set; }
    [Required]
    public int UserId { get; set; }
    [Required]
    public string CFCode { get; set; } = string.Empty;
    [ForeignKey("ElevenFiftyFlights.Flights(Id)")]
    public int FlightId { get; set; }
    //stretch goal of bookingDate
    //[Required]
    //public DateTime BookingDate { get; set; }

}
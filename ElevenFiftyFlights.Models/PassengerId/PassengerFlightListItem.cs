using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElevenFiftyFlights.Models.PassengerId
{
    public class PassengerFlightListItem
    {
        [Required]
        [ForeignKey("Flight.Id")]
        public int FlightId { get; set; }
    }
}
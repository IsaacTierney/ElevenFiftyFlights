using System.ComponentModel.DataAnnotations;

namespace ElevenFiftyFlights.Models.Flight
{
	public class FlightRegister
	{
		[Required]
		public int Id { get; set; }

		[Required]
		public int AirlineId { get; set; }

		[Required]
		public int OriginId { get; set; }

		[Required]
		public int DestinationId { get; set; }

		[Required]
		public DateTime DepartureTime { get; set; }

		[Required]
		public float TicketPrice { get; set; }

		[Required]
		public string? Gate { get; set; }
	}
}

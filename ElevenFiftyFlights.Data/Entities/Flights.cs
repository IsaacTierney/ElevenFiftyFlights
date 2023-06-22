using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElevenFiftyFlights.Data.Entities;

public class FlightEntity
{
	[Key]
	public int Id { get; set; }

	[ForeignKey("Airlines.Id")]
	public int AirlineId { get; set; }

	[ForeignKey("Airports.Id")]
	public int OriginId { get; set; }

	[ForeignKey("Airports.Id")]
	public int DestinationId { get; set; }

	public DateTime DepartureTime { get; set; }

	public float TicketPrice { get; set; }

	public string? Gate { get; set; } = string.Empty;
}

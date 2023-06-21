namespace ElevenFiftyFlights.Models.Flight;

public class FlightRegister
{
	public int Id { get; set; }

	public int AirlineId { get; set; }

	public int OriginId { get; set; }

	public int DestinationId { get; set; }

	public DateTime DepartureTime { get; set; }

	public float TicketPrice { get; set; }

	public string? Gate { get; set; }
}
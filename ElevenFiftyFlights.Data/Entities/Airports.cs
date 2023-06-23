using System.ComponentModel.DataAnnotations;

namespace ElevenFiftyFlights.Data.Entities;

public class AirportEntity
{
	[Key]
	public int Id { get; set; }
	public string Country { get; set; } = string.Empty;
	public string City { get; set; } = string.Empty;
	public string State { get; set; } = string.Empty;
	public string Name { get; set; } = string.Empty;
	public string Code { get; set; } = string.Empty;

}
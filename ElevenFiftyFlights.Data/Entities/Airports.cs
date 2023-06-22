using System.ComponentModel.DataAnnotations;

namespace ElevenFiftyFlights.Data.Entities;

public class AirportEntity
{
	[Key]
	public int Id { get; set; }

	public string? Country { get; set; }

	public string? City { get; set; }

	public string? State { get; set; }

	public string? Name { get; set; }

	public string? Code { get; set; }


}
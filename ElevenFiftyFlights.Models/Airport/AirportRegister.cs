using System.ComponentModel.DataAnnotations;

namespace ElevenFiftyFlights.Models.Airport
{
	public class AirportRegister
	{
		[Required]
		public int Id { get; set; }

		[Required]
		public string? Country { get; set; }

		[Required]
		public string? State { get; set; }

		[Required]
		public string? City { get; set; }

		[Required]
		public string? Name { get; set; }

		[Required]
		public string? Code { get; set; }
	}
}

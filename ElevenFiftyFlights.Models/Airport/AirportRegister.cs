using System.ComponentModel.DataAnnotations;

namespace ElevenFiftyFlights.Models.Airport
{
	public class AirportRegister
	{
		[Required]
		public int Id { get; set; }

		[Required]
		public string Country { get; set; } = string.Empty;

		[Required]
		public string State { get; set; } = string.Empty;

		[Required]
		public string City { get; set; } = string.Empty;

		[Required]
		public string Name { get; set; } = string.Empty;

		[Required]
		public string Code { get; set; } = string.Empty;
	}
}

using System.ComponentModel.DataAnnotations;

namespace ElevenFiftyFlights.Models.Airlines;

public class AirlinesCreate
{
    [Required]
    [MinLength(2, ErrorMessage = "{0} must be at least {1} characters long.")]
    [MaxLength(50, ErrorMessage = "{0} must be no more than {1} characters.")]
    public string Name { get; set; } = string.Empty;

    [Required]
    public double BaseTicketPrice {get; set; }
}
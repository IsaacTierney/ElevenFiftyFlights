using System.ComponentModel.DataAnnotations;

namespace ElevenFiftyFlights.Models.Airlines;

public class AirlinesUpdate
{
    [Required]
    public int Id { get; set; } //default of 0
    [Required]
    public string Name {get; set;} = string.Empty;
    [Required]
    public double BaseTicketPrice {get; set;} 
}
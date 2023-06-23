using System.ComponentModel.DataAnnotations;

namespace ElevenFiftyFlights.Models.Airlines;

public class AirlinesUpdate
{
    [Required]
    public int Id { get; set; }
    [Required]
    public string Name {get; set;}
    [Required]
    public double BaseTicketPrice {get; set;}
}
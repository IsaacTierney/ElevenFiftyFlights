using System.ComponentModel.DataAnnotations;

namespace ElevenFiftyFlights.Models.Token;

public class TokenRequest
{
    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;
    // [Required]
    // public string Password { get; set; } = string.Empty;
}
using System.ComponentModel.DataAnnotations;

namespace ElevenFiftyFlights.Models.User;

public class UserRegister
{
    [Required]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string? FirstName { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    public string?  LastName { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    public string? Email { get; set; } = string.Empty;

    [Required]
    public int PhoneNumber { get; set; }
}
using System.ComponentModel.DataAnnotations;

namespace ElevenFiftyFlights.Models.User;

public class UserRegister
{
    [Required]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string? FirstName { get; set; }

    [Required]
    [MaxLength(100)]
    public string?  LastName { get; set; }

    [Required]
    [EmailAddress]
    public string? Email { get; set; }

    [Required]
    public int PhoneNumber { get; set; }
}
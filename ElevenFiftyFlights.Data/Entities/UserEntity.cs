using System.ComponentModel.DataAnnotations;

namespace ElevenFiftyFlights.Data.Entities;

public class UserEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string? FirstName { get; set; } 

    [Required]
    public string? LastName { get; set; }

    [Required]
    public string Email { get; set; } = string.Empty;

    [Required]
    public int PhoneNumber { get; set; }
}
using System.ComponentModel.DataAnnotations;

namespace ElevenFiftyFlights.Data.Entities;

public class UsersEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string? FullName { get; set; } 

    [Required]
    public string? Email { get; set; }

    [Required]
    public int PhoneNumber { get; set; }
}
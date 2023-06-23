using System.ComponentModel.DataAnnotations;

namespace ElevenFiftyFlights.Data.Entities;

public class Airlines
{
    [Key]
    public int Id {get ; set; }

    [Required]
    public string Name { get; set; }
    
    [Required]
    public double BaseTicketPrice { get; set ;}
}


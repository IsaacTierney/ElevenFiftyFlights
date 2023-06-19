using System.ComponentModel.DataAnnotations;

namespace ElevenFiftyFlights.Data.Entities;

public class Airlines
{
    [Key]

    public int Id {get ; set; }

    public string Name { get; set; }

}
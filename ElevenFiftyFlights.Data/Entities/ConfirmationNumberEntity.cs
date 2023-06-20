using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ElevenFiftyFlights.Data.Entities
{
    public class ConfirmationNumberEntity
    {
        [Required]
    public int ConfirmationNumber { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ElevenFiftyFlights.Models.PassengerId
{
    public class PassengerIdBooking
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public int FlightId { get; set; }   
    }
}
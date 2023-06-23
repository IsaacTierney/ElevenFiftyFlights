using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ElevenFiftyFlights.Services;

[PrimaryKey("PassengerId, ConfirmationCode")]
public class ConfirmationCode
{
    public string CFCode { get; } = string.Empty;
    private string GenerateConfirmationCode()
    {
        Random random = new();
        {
            string code = "";
            string letters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            char[] arr = letters.ToCharArray();
            //Given 7 random
            for (int i = 0; i < 7; i++)
            {
                int Number = random.Next(0, 52);
                code += arr[Number];
            }
            return code;
        }
    }
}

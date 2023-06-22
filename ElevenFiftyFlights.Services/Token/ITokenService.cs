using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElevenFiftyFlights.Models.Token;

namespace ElevenFiftyFlights.Services.Token;

public interface ITokenService
{
    Task<TokenResponse?> GetTokenAsync(TokenRequest model);
}

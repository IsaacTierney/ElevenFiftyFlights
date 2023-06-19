using ElevenFiftyFlights.Models.Users;
using ElevenFiftyFlights.Data.Entities;
using ElevenFiftyFlights.Data;

namespace ElevenFiftyFlights.Services.Users;

public class UsersService : IUsersService
{
    public async Task<bool> RegisterUsersAsync(UsersRegister model)
    {
        return true;
    }
}
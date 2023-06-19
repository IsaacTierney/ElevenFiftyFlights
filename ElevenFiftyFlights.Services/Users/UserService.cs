using ElevenFiftyFlights.Models.User;
using ElevenFiftyFlights.Data.Entities;
using ElevenFiftyFlights.Data;

namespace ElevenFiftyFlights.Services.User;

public class UserService : IUserService
{
    public async Task<bool> RegisterUserAsync(UserRegister model)
    {
        return true;
    }
}
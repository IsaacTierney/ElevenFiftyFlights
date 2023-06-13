using ElevenFiftyFlights.Models.Users;

namespace ElevenFiftyFlights.Services.Users;

public interface IUsersService
{
    Task<bool> RegisterUsersAsync(UsersRegister model);
}
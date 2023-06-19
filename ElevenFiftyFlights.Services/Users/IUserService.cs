using ElevenFiftyFlights.Models.Users;

namespace ElevenFiftyFlights.Services.User;

public interface IUserService
{
    Task<bool> RegisterUserAsync(UserRegister model);
}
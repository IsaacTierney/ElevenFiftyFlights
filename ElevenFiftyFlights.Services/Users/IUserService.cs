using ElevenFiftyFlights.Models.User;

namespace ElevenFiftyFlights.Services.User;

public interface IUserService
{
    Task<bool> RegisterUserAsync(UserRegister model);
}

    
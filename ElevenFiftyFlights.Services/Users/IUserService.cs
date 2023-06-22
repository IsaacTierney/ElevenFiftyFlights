using ElevenFiftyFlights.Data.Entities;
using ElevenFiftyFlights.Models.User;

namespace ElevenFiftyFlights.Services.User;

public interface IUserService
{
   
    Task <UserEntity?> GetUserIdByLastNameAsync(string userId);
    Task<bool> RegisterUserAsync(UserRegister model);
    Task<bool> DeleteUserIdAsync(int UserId);


   
}

    
using ElevenFiftyFlights.Models.User;
using ElevenFiftyFlights.Data.Entities;
using ElevenFiftyFlights.Data;
using Microsoft.EntityFrameworkCore;

namespace ElevenFiftyFlights.Services.User;

public class UserService : IUserService
{
    private readonly ApplicationDbContext _context;
    private readonly int _userId;
    public UserService(ApplicationDbContext context, int userId)
    {
        _context = context;
        _userId = userId;
    }

    public async Task<bool> RegisterUserAsync(UserRegister model)
    {
        UserEntity entity = new()
        {
            Id = model.Id,
            FirstName = model.FirstName,
            LastName = model.LastName,
            Email = model.Email,
            PhoneNumber = model.PhoneNumber
        };

        _context.Users.Add(entity);
        int numberOfChanges = await _context.SaveChangesAsync();

        return numberOfChanges == 1;
    }

    public async Task <UserEntity?> GetUserIdByLastNameAsync(string LastName)
    {
        return await _context.Users.FirstOrDefaultAsync(user => user.LastName == LastName);
    }

    public async Task<bool> DeleteUserIdAsync(int UserId)
    {
        var validUserId = await _context.UserId.FindAsync(UserId);
        if (validUserId?.UserId != _userId)
            return false;
    
        _context.UserId.Remove(validUserId);
                return await _context.SaveChangesAsync() == 1;
    }
    public async Task<UserIdEntity> GetUserIdAsync(int UserId)
    {
        return await _context.UserId.FirstOrDefaultAsync(user.UserId);
        return await _context.Users.FirstOrDefaultAsync(user => user.userId == UserId);
        // SAVE FOR JOSH
    }
} 

 
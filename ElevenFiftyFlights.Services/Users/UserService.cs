using ElevenFiftyFlights.Models.User;
using ElevenFiftyFlights.Data.Entities;
using ElevenFiftyFlights.Data;
using Microsoft.EntityFrameworkCore;

namespace ElevenFiftyFlights.Services.User;

public class UserService : IUserService
{
    private readonly ApplicationDbContext _context;
    public UserService(ApplicationDbContext context)
    {
        _context = context;
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

    private async Task <UserEntity?> GetUserByIdAsync(int Id)
    {
        return await _context.Users.FirstOrDefaultAsync(user => user.Id);
    }
    private async Task <UserEntity?> GetUserByLastName(string LastName)
    {
        return await _context.Users.FirstOrDefaultAsync(user => user.LastName.ToLower() == LastName.ToLower());
    }
}

 
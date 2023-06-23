using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ElevenFiftyFlights.Data;
using ElevenFiftyFlights.Data.Entities;
using ElevenFiftyFlights.Models.Token;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
// using Microsoft.AspNetCore.Identity;

namespace ElevenFiftyFlights.Services.Token;

public class TokenService : ITokenService
{
    // utilize the Users DbSet inside the TokenService from our _context field
    private readonly ApplicationDbContext _context;
    private readonly IConfiguration _config;
    public TokenService(ApplicationDbContext context, IConfiguration config)
    {
        _context = context;
        _config = config;
    }

    public async Task<TokenResponse?> GetTokenAsync(TokenRequest model)
    {
        UserEntity? entity = await GetValidUserAsync(model);

        if (entity is null)
            return null;

        return GenerateToken(entity);
    }
    private async Task<UserEntity?> GetValidUserAsync(TokenRequest model)
    {
        UserEntity? entity = await _context.Users.FirstOrDefaultAsync(User => User.Email.ToLower() == model.Email.ToLower());
        if (entity is null)
            return null;

        // var passwordHasher = new PassworkHasher<UserEntity>();
        // var verifyPasswordResult = passworkHasher.VerifyHashedPassword(entity, entity.Password, model.Password);
        // if (verifyPasswordResult == PasswordVerificationResult.Failed)
        // return null;

        return entity;
    }
    private TokenResponse GenerateToken(UserEntity entity)
    {
        var claims = GetClaims(entity);

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]?? ""));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        SecurityTokenDescriptor tokenDescriptor = new()
        {
            Issuer = _config["Jwt:Issuer"],
            Audience = _config["Jwt:Audience"],
            Subject = new ClaimsIdentity(claims),
            IssuedAt = DateTime.UtcNow,
            Expires = DateTime.UtcNow.AddDays(2),
            SigningCredentials = credentials
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);

        TokenResponse res = new()
        {
            Token = tokenHandler.WriteToken(token),
            IssuedAt = token.ValidFrom,
            Expires = token.ValidTo
        };
        
        return res;
    }
    
    private Claim[] GetClaims(UserEntity user)
    {
        var fullName = $"{user.FirstName}{user.LastName}".Trim();
        var name = !string.IsNullOrWhiteSpace(fullName) ? fullName : user.Email;

        var claims = new Claim[]
        {
            new("Id", user.Id.ToString()),
            // new("Username", user.Username),
            new("Email", user.Email),
            new("Name", name.ToString()),
        };

        return claims;
    }
}

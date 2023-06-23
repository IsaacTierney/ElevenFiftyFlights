using System.Security.Claims;
using ElevenFiftyFlights.Data;
using ElevenFiftyFlights.Data.Entities;
using ElevenFiftyFlights.Models.Airlines;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace ElevenFiftyFlights.Services.AirlineService;

public class AirlinesService : IAirlinesService
{
    private readonly int _userId;
    private readonly ApplicationDbContext _dbContext;
    public AirlinesService(IHttpContextAccessor httpContextAccessor, ApplicationDbContext dbContext)
    {
        var userClaims = httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity;
        var value = userClaims?.FindFirst("Id")?.Value;
        var validId = int.TryParse(value, out _userId);
        // if (!validId)
        //    throw new Exception("Attempted to build AirlineService without User Id claim.");

        _dbContext = dbContext;
    }

    public async Task<AirlinesDetail?> CreateAirlinesAsync(AirlinesCreate request)
    {
        var airlinesEntity = new Airlines
        {
            Name = request.Name,
            BaseTicketPrice = request.BaseTicketPrice,
        };
            

        _dbContext.Airlines.Add(airlinesEntity);
        var numberOfChanges = await _dbContext.SaveChangesAsync();

        if (numberOfChanges == 1)
        {
            AirlinesDetail response = new()
            {
                Id = airlinesEntity.Id,
                Name = airlinesEntity.Name,
                BaseTicketPrice = airlinesEntity.BaseTicketPrice
            };
            return response;
        }

        return null;
    }

    public async Task<IEnumerable<AirlinesListItem>> GetAllAirlinesAsync()
    {
        var airliness = await _dbContext.Airlines
            .Select(entity => new AirlinesListItem
            {
                Id = entity.Id,
                Name = entity.Name,
            })
            .ToListAsync();

        return airliness;
    }

    public async Task<AirlinesDetail?> GetAirlinesByIdAsync(int airlinesId)
    {
        // Find the first airlines that has the given Id
        // and an OwnerId that matches the requesting _userId
        var airlinesEntity = await _dbContext.Airlines
            .FirstOrDefaultAsync(e =>
                e.Id == airlinesId
            );

        // If airlinesEntity is null then return null
        // Otherwise initialize and return a new AirlinesDetail
        return airlinesEntity is null ? null : new AirlinesDetail
        {
            Id = airlinesEntity.Id,
            Name = airlinesEntity.Name,
            BaseTicketPrice = airlinesEntity.BaseTicketPrice,
        };
    }

    public async Task<bool> UpdateAirlinesAsync(AirlinesUpdate request)
    {
        // Find the airlines and validate it's owned by the user
        var airlinesEntity = await _dbContext.Airlines.FindAsync(request.Id);
       
        if (airlinesEntity is null)
            return false;

        // Now we update the entity's properties
        airlinesEntity.Id = request.Id;
        airlinesEntity.Name = request.Name;
        airlinesEntity.BaseTicketPrice = request.BaseTicketPrice;


        // Save the changes to the database and capture how many rows were updated
        var numberOfChanges = await _dbContext.SaveChangesAsync();

        // numberOfChanges is stated to be equal to 1 because only one row is updated
        return numberOfChanges == 1;
    }

    public async Task<bool> DeleteAirlinesAsync(int airlinesId)
    {
        // Find the airlines by the given Id
        var airlinesEntity = await _dbContext.Airlines.FindAsync(airlinesId);

        // Validate the airlines exists and is owned by the user
        if (airlinesEntity is null)
            return false;

        // Remove the airlines from the DbContext and assert that the one change was saved
        _dbContext.Airlines.Remove(airlinesEntity);
        return await _dbContext.SaveChangesAsync() == 1;
    }

}
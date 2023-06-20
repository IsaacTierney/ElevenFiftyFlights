using ElevenFiftyFlights.Data;
using ElevenFiftyFlights.Data.Entities;
using ElevenFiftyFlights.Models.PassengerId;
using ElevenFiftyFlights.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using ElevenFiftyFlights.Services.PassengerId.controller;
using Microsoft.AspNetCore.Http;


namespace ElevenFiftyFlights.Services.PassengerId;

public class PassengerIdService : IPassengerIdService
{

    private readonly int _userId;
    private readonly int _flightId;
    private readonly ApplicationDbContext _dbContext;
    // public PassengerBookingService(IHttpContextAccessor httpContextAccessor, ApplicationDbContext dbContext)
    // {
    //     // place variables for connection service here
    // }
    public PassengerIdService(IHttpContextAccessor httpContextAccessor, ApplicationDbContext dbContext)
    {
        var userClaims = httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity;
        _dbContext = dbContext;
        async Task<PassengerIdCreate?> BookPassengerByIdAsync(PassengerIdCreate model) //or request?
        {
            var value = userClaims?.FindFirst("Id")?.Value;
            var validId = int.TryParse(value, out _userId);
            var flightId = int.TryParse(value, out _flightId);
            // Check if user with given user Id exists
            if (!validId)
              {  throw new Exception("Attempted to book a flight without a valid User Id.");
               } else if (!Flights)
            {throw new Exception("Attempted to book a flight without a valid Flight Id.");
            } else if (BookingPassengerByPassengerIdAsync());


        // Check if flight with flight id exists
        // if either is null then return null
        // otherwise proceed with rest of the method
        // flightId?.validId?.(method)
        PassengerIdEntity passengerIdEntity = new()
        {
            UserId = model.UserId,
            FlightId = model.FlightId,
            ConfirmationNumber = GetConfirmationCode()

        };

        _dbContext.PassengerId.Add(passengerIdEntity);
        var numberOfChanges = await _dbContext.SaveChangesAsync();

        if (numberOfChanges == 1)
        {
            PassengerIdCreate response = new()
            {
                PassengerId = _passengerId,
                UserId = model.UserId,
                ConfirmationNumber = model.ConfirmationNumber,
                FlightId = model.FlightId
            };
            return response;
        }
        return null;
    }
    public async Task<IEnumerable<PassengerIdDetail?>> GetPassengerIdbyIdAsync(int PassengerId)
    {
        var GetPassengerId = await _dbContext.PassengerId
        .Where(entity => entity.PassengerId == _passengerId)
        .Select(entity => new PassengerIdDetail
        {
            PassengerId = entity.PassengerId,
            UserId = entity.UserId,
            ConfirmationNumber = entity.ConfirmationNumber,
            FlightId = entity.FlightId
        })
        .ToListAsync();
        return GetPassengerId;
    }
    private int GetConfirmationCode()
    {
        return -1;
    }
}
}
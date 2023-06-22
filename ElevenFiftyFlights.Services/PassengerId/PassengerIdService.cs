using ElevenFiftyFlights.Data;
using ElevenFiftyFlights.Data.Entities;
using ElevenFiftyFlights.Models.PassengerId;
using ElevenFiftyFlights.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using ElevenFiftyFlights.Services;

namespace ElevenFiftyFlights.Services.PassengerId;

public class PassengerIdService : IPassengerIdService
{

    private readonly int _userId;
    private readonly int _flightId;
    private readonly ApplicationDbContext _dbContext;
    private readonly PassengerIdBooking _passengerIdResponse;
    // constructor
    private readonly ApplicationDbContext _context;
    public PassengerIdService(ApplicationDbContext context, PassengerIdBooking booking)
    {
        _context = context;
        _passengerIdResponse = booking;
    }
    // public PassengerBookingService(IHttpContextAccessor httpContextAccessor, ApplicationDbContext dbContext)
    // {
    //     // place variables for connection service here
    // }
    // public PassengerIdService(IHttpContextAccessor httpContextAccessor, ApplicationDbContext dbContext)
    // {
    //     var userClaims = httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity;
    //     _dbContext = dbContext;
    //     async Task<PassengerIdCreate?> BookPassengerByIdAsync(PassengerIdCreate model) //or request?
    //     {
    //         // var value = userClaims?.FindFirst("Id")?.Value;
    // var validId = int.TryParse(value, out _userId);
    // var flightId = int.TryParse(value, out _flightId);
    // // Check if user with given user Id exists
    // if (!validId)
    //   {  throw new Exception("Attempted to book a flight without a valid User Id.");
    //    } else if (!Flights)
    // {throw new Exception("Attempted to book a flight without a valid Flight Id.");
    // } else if (BookingPassengerByPassengerIdAsync());


    // Check if flight with flight id exists
    // if either is null then return null
    // otherwise proceed with rest of the method
    // flightId?.validId?.(method)
    // type one
    public async Task<PassengerIdDetail?> BookPassengerAsync(PassengerIdBooking model) //we can trust this because of the controller
    {       // type two
        PassengerIdEntity passengerIdEntity = new()
        {
            //object inialization syntax  different than using a constructor
            //type two  = type one
            UserId = model.UserId,
            FlightId = model.FlightId,
            ConfirmationNumber = GetConfirmationCode()
        };
        // accessing.   locationWrite.  add information
        // database.    table.          add(Row)
        _dbContext.PassengerId.Add(passengerIdEntity);

        var numberOfChanges = await _dbContext.SaveChangesAsync();  //finally updates the DB

        if (numberOfChanges == 1)
        {
            PassengerIdDetail response = new() //this is a retrun that is why it is Detail
            {
                PassengerId = passengerIdEntity.PassengerId,
                ConfirmationNumber = passengerIdEntity.ConfirmationNumber,
                UserId = model.UserId, //model is info from the user
                FlightId = model.FlightId,
            };
            return (response); //if return type doesn't work check the method initial return type
        }

        return (null);
    }

    public async Task<PassengerIdDetail> GetPassengerDetailById(int Id)
    { //add logic here similar to getnote by id
        throw new NotImplementedException();
    }

    public async Task<PassengerIdResponse?> GetPassengerIdAsync(PassengerIdResponse model)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<PassengerFlightListItem>> GetAllFlightsAsync(int Id)
    {
        //check if there is a flightId that corresponds to the userId
        var flights = await _dbContext.PassengerId
        // take in the user Id
        .Where(entity => entity.UserId == _userId)
        //this new instance has to match the return type
        .Select(entity => new PassengerFlightListItem 
        {
            FlightId = entity.FlightId
        })
        //if there are any flights form a list of them
        .ToListAsync();
        //return all the flights to the requester 
        return (flights);
    }

    // corresponds to the PassengerUpdate
    public async Task<bool> UpdatePassengerAsync(PassengerIdBooking request, int userId)
    {
        //Find to see if passengerId is valid and request the userId
        var passengerUpdate = await _dbContext.PassengerId.FindAsync(request.UserId);

        //use null conditional operator to check if owned by the user
        if (passengerUpdate?.UserId != userId)
            return false;

        /* update the entity's properties */
        passengerUpdate.UserId = request.UserId;
        passengerUpdate.FlightId = request.FlightId;

        // save the changes to the database and capture how many rows were updated
        var numberOfChanges = await _dbContext.SaveChangesAsync();
        //return number of changes == to one becasue only one row in the table was affected
        return numberOfChanges == 1;
    }

    int GetConfirmationCode()
    {
        return -1;
    }
    // Method with 
    // variable with a response equal to a backing field in a service then invoke the method
    // if flight exists and userId exists then
    // create a passengerId and

    public async Task<bool> DeletePassengerByIdAsync(int passengerId)
    {
        // find passengerId then delete
        // parameter needs the x.x.async path to contain the same type
        var validPassengerId = await _dbContext.PassengerId.FindAsync(passengerId);
        if (validPassengerId?.UserId != _userId)
            return false;
        //update the db
        _dbContext.PassengerId.Remove(validPassengerId);
                return await _dbContext.SaveChangesAsync() == 1;
        // return 1
    }
   
}
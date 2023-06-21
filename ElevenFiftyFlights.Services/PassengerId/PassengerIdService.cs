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
    private readonly int _passengerIdResponse;
    // constructor
    private readonly ApplicationDbContext _context;
    public PassengerIdService(ApplicationDbContext context)
    {
        _context = context;
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
    public async Task<PassengerIdDetail?> BookpassengerAsync(PassengerIdBooking model) //we can trust this because of the controller
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

    public async Task<IActionResult> GetAllFlightsByIdAsync(int Id)
    {
        FlightEntity flightEntity = new();
        {
            //type two = type one
            List<Flight>() = flightEntity.Id,
            
       }

        //take in the user Id then return all the flights to the requester 
        //check if there is a flightId that corresponds to the userId
        //if there are any flights then list them
        // return the list to the requester
        //if not then send a console writeline with a notFound

    }
    int GetConfirmationCode()
    {
        return -1;
    }
}
// Method with 
// variable with a response equal to a backing field in a service then invoke the method
// if flight exists and userId exists then
// create a passengerId and
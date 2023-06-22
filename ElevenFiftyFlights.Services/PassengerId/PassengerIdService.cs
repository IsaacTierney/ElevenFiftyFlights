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
    public PassengerIdService(ApplicationDbContext dbContext/*, PassengerIdBooking booking*/)
    {
        _dbContext = dbContext;
        // _passengerIdResponse = booking;
    }

    // type one
    public async Task<PassengerIdEntity?> BookPassengerAsync(PassengerIdBooking model) //we can trust this because of the controller
    {       // type two
        PassengerIdEntity passengerIdEntity = new()
        {
            //object inialization syntax  different than using a constructor
            //type two  = type one
            UserId = model.UserId,
            FlightId = model.FlightId
        };

        passengerIdEntity.CFCode = (await GenerateConfirmationCodeAsnyc(passengerIdEntity)).ToString();

        // accessing.   locationWrite.  add information
        // database.    table.          add(Row)
        _dbContext.PassengerId.Add(passengerIdEntity);

        var numberOfChanges = await _dbContext.SaveChangesAsync();  //finally updates the DB

        if (numberOfChanges == 1)
        {
            PassengerIdEntity response = new() //this is a retrun that is why it is Detail
            {
                PassengerId = passengerIdEntity.PassengerId,
                CFCode = passengerIdEntity.CFCode,
                UserId = model.UserId, //model is info from the user
                FlightId = model.FlightId,
            };
            return (response); //if return type doesn't work check the method initial return type
        }

        return (null);
    }

    public async Task<PassengerIdEntity> GetPassengerDetailById(int Id)
    {
        //Find the first IdDetail that has the given Id
        // and an Id that matched the requesting _userId
        var passengerEntity = await _dbContext.PassengerId
        .FirstOrDefaultAsync(e =>
        e.PassengerId == Id && e.UserId == _userId
        );
        // If noteEntity is null then return null
        // Otherwise initialize and reutrn a new NoteDetail
        return passengerEntity is null ? null : new PassengerIdEntity
        {
            PassengerId = passengerEntity.PassengerId,
            UserId = passengerEntity.UserId,
            CFCode = passengerEntity.CFCode,
            FlightId = passengerEntity.FlightId,
        };
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
        if (passengerUpdate?.UserId != _userId)
            return false;

        /* update the entity's properties */
        passengerUpdate.UserId = request.UserId;
        passengerUpdate.FlightId = request.FlightId;

        // save the changes to the database and capture how many rows were updated
        var numberOfChanges = await _dbContext.SaveChangesAsync();
        //return number of changes == to one becasue only one row in the table was affected
        return numberOfChanges == 1;
    }

    public async Task<ConfirmationCode> GenerateConfirmationCodeAsnyc(PassengerIdEntity passId)
    {
        var confcode = new ConfirmationCode();

        // if valid passengerId
        if (passId != null)
        {
            passId.CFCode = confcode.CFCode;
            var numberOfChanges = await _dbContext.SaveChangesAsync();
            return confcode; //local variable
        }
        else
        {
            // return numberOfChanges == 1;

            throw new Exception("The inputted PassengerId in not valid");
        }
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
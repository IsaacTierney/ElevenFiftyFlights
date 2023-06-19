using ElevenFiftyFlights.Data;
using ElevenFiftyFlights.Services.Airport;
using ElevenFiftyFlights.Services.Flight;
using Microsoft.EntityFrameworkCore;
using ElevenFiftyFlights.Services.PassengerId;

var builder = WebApplication.CreateBuilder(args);

// Add connection string and DbContext setup
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

// Add Passenger Service/Interface for Dependency Injection here
builder.Services.AddScoped<IPassengerIdService, PassengerIdService>();
builder.Services.AddScoped<IAirportService, AirportService>();
builder.Services.AddScoped<IFlightService, FlightService>();

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

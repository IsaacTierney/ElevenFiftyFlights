using ElevenFiftyFlights.Data.Entities;
using Microsoft.EntityFrameworkCore;


namespace ElevenFiftyFlights.Data;

public class ApplicationDbContext : DbContext
{
	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
		: base(options) {}
	public DbSet<Airlines> Airlines { get; set; }
	public DbSet<UserEntity> Users { get; set; } =null!;
	public DbSet<AirportEntity> Airport { get; set; } = null!;
	public DbSet<FlightEntity> Flight { get; set; } = null!;
// PassengerId Table info
	public DbSet<PassengerIdEntity> PassengerId { get; set; } = null!;
	public DbSet<UserIdEntity> UserId { get; set; } = null!;
	public DbSet<ConfirmationNumberEntity> ConfNum { get; set; } = null!;
}

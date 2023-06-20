using ElevenFiftyFlights.Data.Entities;
using Microsoft.EntityFrameworkCore;


namespace ElevenFiftyFlights.Data;

public class ApplicationDbContext : DbContext
{
	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
		: base(options) { }


	public DbSet<UserEntity> Users { get; set; } =null!;
	public DbSet<AirportEntity> Airport { get; set; } = null!;
	public DbSet<FlightEntity> Flight { get; set; } = null!;

}

using ElevenFiftyFlights.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ElevenFiftyFlights.Data;

public class ApplicationDbContext : DbContext
{
	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
		: base(options) {}

		public DbSet<Airlines> Airlines { get; set; }
}

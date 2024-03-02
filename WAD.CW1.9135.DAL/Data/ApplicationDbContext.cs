using Microsoft.EntityFrameworkCore;
using WAD.CW1._9135.DAL.Models;

namespace WAD.CW1._9135.DAL.Data
{
	public class ApplicationDbContext : DbContext
	{
		// Declaring tables that will be created in migration
		public DbSet<Car> Cars { get; set; }
		public DbSet<Rental> Rentals { get; set; }

		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
													: base(options)
		{ }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// Configuration of relation between models
			modelBuilder.Entity<Rental>()
				.HasOne(r => r.Car)
				.WithMany(c => c.Rentals)
				.HasForeignKey(r => r.CarId);
		}
	}
}

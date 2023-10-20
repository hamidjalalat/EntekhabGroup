using Entekhab.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Entekhab.Persistence
{
	public class DatabaseContext :DbContext
	{
		public DatabaseContext
			(DbContextOptions<DatabaseContext> options) : base(options: options)
		{
			// TODO
			Database.EnsureCreated();
		}

		public DbSet<PersonSalary> PersonSalaries { get; set; }

		protected override void OnModelCreating
			(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
		}
	}
}

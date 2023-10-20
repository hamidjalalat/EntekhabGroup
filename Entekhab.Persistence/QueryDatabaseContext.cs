using Entekhab.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Entekhab.Persistence
{
	public class QueryDatabaseContext : DbContext
	{
		public QueryDatabaseContext
			(DbContextOptions<QueryDatabaseContext> options) : base(options: options)
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

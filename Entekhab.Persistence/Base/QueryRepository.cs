using Entekhab.Domain.Models.Base;
using Microsoft.EntityFrameworkCore;

namespace Entekhab.Persistence.Base
{
	public abstract class QueryRepository<TEntity> :
		object, IQueryRepository<TEntity> where TEntity : class, IEntity
    {
		protected QueryRepository
			(DbContext databaseContext) : base()
		{
			DatabaseContext =
				databaseContext ??
				throw new System.ArgumentNullException(paramName: nameof(databaseContext));

			DbSet = DatabaseContext.Set<TEntity>();
		}

		protected DbSet<TEntity> DbSet { get; }

		protected DbContext DatabaseContext { get; }

		public virtual async Task<TEntity> GetByIdAsync(System.Guid id)
		{
			return await DbSet.FindAsync(keyValues: id);
		}

		public virtual async Task<IList<TEntity>> GetAllAsync()
		{
			
			var result =
				await
				DbSet.ToListAsync()
				;

			return result;

		}
	}
}

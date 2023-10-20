using Entekhab.Domain.Models.Base;

namespace Entekhab.Persistence.Base
{
	public interface IQueryRepository<T> where T :IEntity
	{
		Task<T> GetByIdAsync(System.Guid id);

		Task<IList<T>> GetAllAsync();
	}
}

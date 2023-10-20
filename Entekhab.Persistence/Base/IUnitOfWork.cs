namespace Entekhab.Persistence.Base
{
	public interface IUnitOfWork : IQueryUnitOfWork
	{
		Task SaveAsync();
	}
}

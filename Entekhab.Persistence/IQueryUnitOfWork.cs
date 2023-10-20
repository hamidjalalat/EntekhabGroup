using Entekhab.Persistence.PersonSalaries.Repositories;

namespace Entekhab.Persistence
{
    public interface IQueryUnitOfWork : Entekhab.Persistence.Base.IQueryUnitOfWork
    {
        public IPersonSalaryQueryRepository PersonSalaries { get; }
    }
}

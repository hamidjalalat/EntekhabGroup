using Entekhab.Persistence.PersonSalaries.Repositories;

namespace Entekhab.Persistence
{
    public interface IUnitOfWork : Entekhab.Persistence.Base.IUnitOfWork
    {
        public IPersonSalaryRepository PersonSalaries { get; }
    }
}

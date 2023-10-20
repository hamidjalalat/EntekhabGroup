using Entekhab.Domain.Models;
using Entekhab.Persistence.Base;

namespace Entekhab.Persistence.PersonSalaries.Repositories
{
	public interface IPersonSalaryRepository : IRepository<PersonSalary>
	{
        Task<Domain.Models.PersonSalary> GetByDateAsync(String date, string firsName, string lastName);
    }
}

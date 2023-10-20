using Entekhab.Domain.Models;
using Entekhab.Persistence.Base;
using Entekhab.Persistence.ViewModels;

namespace Entekhab.Persistence.PersonSalaries.Repositories
{
	public interface IPersonSalaryQueryRepository :IQueryRepository<PersonSalary>
	{
		Task
			<IList<GetPersonSalariesQueryResponseViewModel>>
			GetSomeAsync( string firsName, string lastName,DateTime startDate, DateTime endDate);

         Task<GetPersonSalariesQueryResponseViewModel> GetByDateAsync(String date, string firsName, string lastName);

    }
}

using Entekhab.Persistence.Base;
using Entekhab.Persistence.PersonSalaries.Repositories;

namespace Entekhab.Persistence
{
	public class QueryUnitOfWork :
        QueryUnitOfWork<QueryDatabaseContext>, IQueryUnitOfWork
	{
		public QueryUnitOfWork
			(Options options) : base(options: options)
		{
		}

		private IPersonSalaryQueryRepository _personSalaries;

		public IPersonSalaryQueryRepository PersonSalaries
        {
			get
			{
				if (_personSalaries == null)
				{
                    _personSalaries =
						new PersonSalaryQueryRepository(databaseContext: DatabaseContext);
				}

				return _personSalaries;
			}
		}
	}
}

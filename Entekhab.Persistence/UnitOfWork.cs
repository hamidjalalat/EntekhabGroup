using Entekhab.Persistence.Base;
using Entekhab.Persistence.PersonSalaries.Repositories;

namespace Entekhab.Persistence
{
	public class UnitOfWork :
      UnitOfWork<DatabaseContext>, IUnitOfWork
	{
		public UnitOfWork
			(Options options) : base(options: options)
		{
		}

		private IPersonSalaryRepository _personSalaries;

		public IPersonSalaryRepository PersonSalaries
        {
			get
			{
				if (_personSalaries == null)
				{
                    _personSalaries =
						new PersonSalaryRepository(databaseContext: DatabaseContext);
				}

				return _personSalaries;
			}
		}
	}
}

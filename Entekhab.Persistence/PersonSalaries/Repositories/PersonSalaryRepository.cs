using Entekhab.Domain.Models;
using Entekhab.Persistence.Base;
using Microsoft.EntityFrameworkCore;

namespace Entekhab.Persistence.PersonSalaries.Repositories
{
	public class PersonSalaryRepository :
       Repository<PersonSalary>, IPersonSalaryRepository
	{
		protected internal PersonSalaryRepository
			(DbContext databaseContext) : base(databaseContext: databaseContext)
		{
        
        }
        public async Task<Domain.Models.PersonSalary> GetByDateAsync(String date,string firsName,string lastName)
        {
            var result = await DbSet
                        .Where(C => C.DateShamsi == date &&
                        C.FirstName.Trim().ToLower()==firsName.Trim().ToLower() &&
                        C.LastName.Trim().ToLower()==lastName.Trim().ToLower())
           .FirstOrDefaultAsync();

            return result;
        }
    }
}

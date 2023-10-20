using System.Linq;
using Entekhab.Domain.Models;
using Entekhab.Persistence.Base;
using Entekhab.Persistence.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Entekhab.Persistence.PersonSalaries.Repositories
{
    public class PersonSalaryQueryRepository :
        QueryRepository<PersonSalary>, IPersonSalaryQueryRepository
    {
        public PersonSalaryQueryRepository(QueryDatabaseContext databaseContext) : base(databaseContext)
        {
        }

        public async Task<IList<GetPersonSalariesQueryResponseViewModel>>GetSomeAsync( string firsName
                                                                                      ,string lastName
                                                                                      ,DateTime startDate
                                                                                      ,DateTime endDate)
        {
           
            var result = await DbSet
                .Where(C=>C.DateMiladi >= startDate && C.DateMiladi <= endDate)
                .Where(F=>F.FirstName.Trim().ToLower() == firsName.Trim().ToLower() &&
                       F.LastName.Trim().ToLower() == lastName.Trim().ToLower())
                .Select(current => new ViewModels.GetPersonSalariesQueryResponseViewModel()
                {
                    Id = current.Id,
                    FirstName = current.FirstName,
                    LastName = current.LastName,
                    Allowance = current.Allowance,
                    BasicSalary = current.BasicSalary,
                    DateShamsi = current.DateShamsi,
                    DateMiladi=current.DateMiladi,
                    Transportation = current.Transportation,
                })
                .ToListAsync();

            return result;
        }

        public async Task<GetPersonSalariesQueryResponseViewModel> GetByDateAsync(
                                                                                 string date
                                                                                ,string firsName
                                                                                ,string lastName)
        {
            var result = await DbSet
           .Where(C => C.DateShamsi == date &&
                  C.FirstName.Trim().ToLower() == firsName.Trim().ToLower() &&
                  C.LastName.Trim().ToLower() == lastName.Trim().ToLower())
              .Select(current => new ViewModels.GetPersonSalariesQueryResponseViewModel()
              {
                  Id = current.Id,
                  FirstName = current.FirstName,
                  LastName = current.LastName,
                  Allowance = current.Allowance,
                  BasicSalary = current.BasicSalary,
                  DateShamsi = current.DateShamsi,
                  DateMiladi = current.DateMiladi,
                  Transportation = current.Transportation,
              })
           .FirstOrDefaultAsync();

            return result;
        }

    }
}

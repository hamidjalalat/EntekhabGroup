

using Entekhab.Application.Proxy;
using Entekhab.Domain.Models;
using System.Resources;

namespace Entekhab.Application.PersonSalaries.CommandHandlers
{
	public class DeletePersonSalaryCommandHandler : Mediator.IRequestHandler
		<Commands.DeletePersonSalaryCommand, System.Guid>
	{
		public DeletePersonSalaryCommandHandler
            (
			AutoMapper.IMapper mapper,
			Persistence.IUnitOfWork unitOfWork) : base()
		{
			Mapper = mapper;
			UnitOfWork = unitOfWork;
		}

		protected AutoMapper.IMapper Mapper { get; }

		protected Persistence.IUnitOfWork UnitOfWork { get; }

		

		public async Task<FluentResults.Result<System.Guid>>
			Handle(Commands.DeletePersonSalaryCommand request,
			System.Threading.CancellationToken cancellationToken)
		{
			var result =
				new FluentResults.Result<System.Guid>();

            try
			{
                var personSalary = UnitOfWork.PersonSalaries.GetByDateAsync(date: request.Date
                                                                           , firsName: request.FirstName
                                                                           , lastName: request.LastName).Result;

                await UnitOfWork.PersonSalaries.DeleteByIdAsync(id: personSalary.Id);

                await UnitOfWork.SaveAsync();
               
                result.WithValue(value: personSalary.Id);
                string successInsert =
                    string.Format("عملیات حذف با موفقیت انجام شد");

                result.WithSuccess
                    (successMessage: successInsert);
            }
			catch (System.Exception ex)
			{
				
				result.WithError
					(errorMessage: ex.Message);
			}

			return result;
		}
	}
}

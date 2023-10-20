using Entekhab.Application.PersonSalaries.Queries;
using Entekhab.Persistence.ViewModels;

namespace Entekhab.Application.PersonSalaries.CommandHandlers
{
	public class GetPersonSalaryQueryHandler : Mediator.IRequestHandler
		<GetPersonSalaryQuery, GetPersonSalariesQueryResponseViewModel>
	{
		public GetPersonSalaryQueryHandler
            (
			AutoMapper.IMapper mapper,
            Entekhab.Persistence.IQueryUnitOfWork unitOfWork) : base()
		{
		
			Mapper = mapper;
			UnitOfWork = unitOfWork;
		}

		protected AutoMapper.IMapper Mapper { get; }

		protected Entekhab.Persistence.IQueryUnitOfWork UnitOfWork { get; }

		

		public
			async
		Task
			<FluentResults.Result
				<GetPersonSalariesQueryResponseViewModel>>
			Handle(GetPersonSalaryQuery request, System.Threading.CancellationToken cancellationToken)
		{
			var result =
				new FluentResults.Result
				<GetPersonSalariesQueryResponseViewModel>();

			try
			{
			
				var Users =await
					UnitOfWork.PersonSalaries
                    .GetByDateAsync(date: request.Date, lastName:request.LastName, firsName:request.FirstName)
					;
			

				result.WithValue(value: Users);
			
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

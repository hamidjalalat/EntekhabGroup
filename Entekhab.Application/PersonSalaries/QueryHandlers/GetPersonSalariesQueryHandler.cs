using AutoMapper;
using Entekhab.Application.PersonSalaries.Queries;
using Entekhab.Persistence;
using Entekhab.Persistence.ViewModels;
using Prime;

namespace Entekhab.Application.PersonSalaries.CommandHandlers
{
	public class GetPersonSalariesQueryHandler : Mediator.IRequestHandler
		<GetPersonSalariesQuery, IEnumerable<GetPersonSalariesQueryResponseViewModel>>
	{
		public GetPersonSalariesQueryHandler
            (
			IMapper mapper,
            IQueryUnitOfWork unitOfWork) : base()
		{
		
			Mapper = mapper;
			UnitOfWork = unitOfWork;
		}

		protected IMapper Mapper { get; }

		protected IQueryUnitOfWork UnitOfWork { get; }

		public async Task<FluentResults.Result<IEnumerable<GetPersonSalariesQueryResponseViewModel>>>
			Handle(Queries.GetPersonSalariesQuery request, CancellationToken cancellationToken)
		{
			var result =new FluentResults.Result<IEnumerable<GetPersonSalariesQueryResponseViewModel>>();

			try
			{
				var startDateMiladi = Shamsi.ToDateTimeYYMMDD(request.StartDate);
				var endDateMiladi = Shamsi.ToDateTimeYYMMDD(request.EndDate);

                var Users =await UnitOfWork.PersonSalaries.GetSomeAsync(
					firsName:request.FirstName
					,lastName:request.LastName
					,startDate: startDateMiladi
					,endDate:endDateMiladi
					);

				result.WithValue(value: Users);
			}
			catch (System.Exception ex)
			{
				result.WithError(errorMessage: ex.Message);
			}

			return result;
		}

      
    }
}


using Entekhab.Application.Proxy;
using Entekhab.Domain.Models;
using System.Resources;

namespace Entekhab.Application.PersonSalaries.CommandHandlers
{
	public class CreatePersonSalaryCommandHandler :Mediator.IRequestHandler
		<Commands.CreatePersonSalaryCommand, System.Guid>
	{
		public CreatePersonSalaryCommandHandler
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
			Handle(Commands.CreatePersonSalaryCommand request,
			System.Threading.CancellationToken cancellationToken)
		{
			var result =
				new FluentResults.Result<System.Guid>();

			ProxyOvetimePolicies ProxyOvetimePolicies = new ProxyOvetimePolicies();

            try
			{
                var personSalary = Mapper.Map<PersonSalary>(source: request);

				if (!ProxyOvetimePolicies.CheckIsMethod(request.OverTimeCalculator)) 
				{
					throw new Exception("نام متد وارد شده پیاده سازی نشده است");
				}

				var overTime = ProxyOvetimePolicies.OverTimeCalculator(basicSalary: personSalary.BasicSalary
					                                                   ,allowance:personSalary.Allowance
															           ,Transportation:personSalary.Transportation
																	   ,methodCalculator: request.OverTimeCalculator);

				personSalary.OverTime = overTime;

                await UnitOfWork.PersonSalaries.InsertAsync(entity: personSalary);

                await UnitOfWork.SaveAsync();
               
                result.WithValue(value: personSalary.Id);
                string successInsert =
                    string.Format("عملیات درج با موفقیت انجام شد");

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

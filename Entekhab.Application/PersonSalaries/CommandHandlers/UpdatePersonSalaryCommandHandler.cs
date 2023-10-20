

using Entekhab.Application.Proxy;
using Entekhab.Domain.Models;
using Prime;
using System.Resources;

namespace Entekhab.Application.PersonSalaries.CommandHandlers
{
	public class UpdatePersonSalaryCommandHandler : Mediator.IRequestHandler
		<Commands.UpdatePersonSalaryCommand, System.Guid>
	{
		public UpdatePersonSalaryCommandHandler
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
			Handle(Commands.UpdatePersonSalaryCommand request,
			System.Threading.CancellationToken cancellationToken)
		{
			var result =
				new FluentResults.Result<System.Guid>();

			ProxyOvetimePolicies ProxyOvetimePolicies = new ProxyOvetimePolicies();

            try
			{

				var personSalary = UnitOfWork.PersonSalaries.GetByDateAsync (date: request.Date
					                                                          ,firsName:request.FirstName
																			  , lastName:request.LastName).Result;
				if (personSalary==null)
				{
                    throw new Exception("هیچ اطلاعاتی  با این مشخصات در  بانک اطلاعاتی و جود ندارد");
                }

                if (!ProxyOvetimePolicies.CheckIsMethod(request.OverTimeCalculator)) 
				{
					throw new Exception("نام متد وارد شده پیاده سازی نشده است");
				}

				var overTime = ProxyOvetimePolicies.OverTimeCalculator(basicSalary: personSalary.BasicSalary
					                                                   ,allowance:personSalary.Allowance
															           ,Transportation:personSalary.Transportation
																	   ,methodCalculator: request.OverTimeCalculator);

				personSalary.OverTime = overTime;
				personSalary.DateMiladi = Shamsi.ToDateTimeYYMMDD(request.Date);
				personSalary.Transportation = request.Transportation;
				personSalary.Allowance = request.Allowance;
				personSalary.BasicSalary = request.BasicSalary;
				personSalary.DateShamsi = request.Date;
				personSalary.LastName = request.LastName;
				personSalary.FirstName = request.FirstName;

                await UnitOfWork.PersonSalaries.UpdateAsync(entity: personSalary);

                await UnitOfWork.SaveAsync();
               
                result.WithValue(value: personSalary.Id);
                string successInsert =
                    string.Format("عملیات ویرایش با موفقیت انجام شد");

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

using Entekhab.Application.PersonSalaries.Queries;
using FluentValidation;

namespace Entekhab.Application.PersonSalaries.Queries
{
	public class GetPersonSalariesQueryValidator :
		FluentValidation.AbstractValidator<GetPersonSalariesQuery>
	{
		public GetPersonSalariesQueryValidator() : base()
		{
			RuleFor(current => current.StartDate)
				.NotEmpty()
				.WithMessage(errorMessage: "وارد کردن فیلد تاریخ الزامی می باشد")
				;
            RuleFor(current => current.EndDate)
            .NotEmpty()
            .WithMessage(errorMessage: "وارد کردن فیلد تاریخ الزامی می باشد")
            ;
            RuleFor(current => current.FirstName)
              .NotEmpty()
              .WithMessage(errorMessage: "وارد کردن نام  الزامی می باشد")
              ;
            RuleFor(current => current.LastName)
                .NotEmpty()
                .WithMessage(errorMessage: "وارد کردن نام خانوادگی الزامی می باشد")
                ;
        }
	}
}

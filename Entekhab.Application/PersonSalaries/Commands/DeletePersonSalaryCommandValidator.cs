using Entekhab.Application.PersonSalaries.Commands;
using FluentValidation;

namespace Entekhab.Application.PersonSalaries.Commands
{
    public class DeletePersonSalaryCommandValidator :
        FluentValidation.AbstractValidator<DeletePersonSalaryCommand>
    {
        public DeletePersonSalaryCommandValidator() : base()
        {
            RuleFor(current => current.Date)
                .NotEmpty()
                .WithMessage(errorMessage: "وارد کردن تاریخ الزامی میباشد");
            RuleFor(current => current.FirstName)
              .NotEmpty()
              .WithMessage(errorMessage: "وارد کردن نام الزامی میباشد");
            RuleFor(current => current.LastName)
              .NotEmpty()
              .WithMessage(errorMessage: "وارد کردن نام خانوادگی الزامی میباشد");

        }
    }
}

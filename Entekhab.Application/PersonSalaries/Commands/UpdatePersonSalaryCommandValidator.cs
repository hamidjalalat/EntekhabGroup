using Entekhab.Application.PersonSalaries.Commands;
using FluentValidation;

namespace Entekhab.Application.PersonSalaries.Commands
{
    public class UpdatePersonSalaryCommandValidator :
        FluentValidation.AbstractValidator<UpdatePersonSalaryCommand>
    {
        public UpdatePersonSalaryCommandValidator() : base()
        {
            RuleFor(current => current.FirstName)
                .NotEmpty()
                .WithMessage(errorMessage: "وارد کردن نام الزامی میباشد");

            RuleFor(current => current.LastName)
                .NotEmpty()
                .WithMessage(errorMessage: "وارد کردن نام خانوادگی الزامی میباشد");

            RuleFor(current => current.Allowance)
                .NotEmpty()
                .WithMessage(errorMessage: "وارد کردن فوق العاده حق جذب الزامی میباشد");

            RuleFor(current => current.BasicSalary)
                .NotEmpty()
                .WithMessage(errorMessage: "وارد کردن  حقوق پایه الزامی میباشد");

            RuleFor(current => current.Date)
                .NotEmpty()
                .WithMessage(errorMessage: "وارد کردن تاریخ الزامی میباشد")
                .MinimumLength(8)
                .WithMessage("تاریخ نباید کمتر 8 رقم باشد");
        }
    }
}

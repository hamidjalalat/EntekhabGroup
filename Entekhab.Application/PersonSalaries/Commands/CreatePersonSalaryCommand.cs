namespace Entekhab.Application.PersonSalaries.Commands
{

	public class CreatePersonSalaryCommand : Mediator.IRequest<System.Guid>
	{
		public CreatePersonSalaryCommand() : base()
		{
		}

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public decimal BasicSalary { get; set; }

        public decimal Allowance { get; set; }

        public decimal Transportation { get; set; }

        public string Date { get; set; }

        public string OverTimeCalculator { get; set; }


    }
}

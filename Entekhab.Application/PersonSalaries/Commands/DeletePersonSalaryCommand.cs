namespace Entekhab.Application.PersonSalaries.Commands
{

	public class DeletePersonSalaryCommand : Mediator.IRequest<System.Guid>
	{
		public DeletePersonSalaryCommand() : base()
		{
		}
        public string Date { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}

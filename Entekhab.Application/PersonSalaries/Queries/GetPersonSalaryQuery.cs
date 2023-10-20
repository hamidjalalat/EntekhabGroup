using Entekhab.Persistence.ViewModels;

namespace Entekhab.Application.PersonSalaries.Queries
{
	public class GetPersonSalaryQuery : Mediator.IRequest
		<GetPersonSalariesQueryResponseViewModel>
	{
		public GetPersonSalaryQuery() : base()
		{
		}

		public string Date { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}

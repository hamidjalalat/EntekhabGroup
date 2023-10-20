using Entekhab.Persistence.ViewModels;

namespace Entekhab.Application.PersonSalaries.Queries
{
	public class GetPersonSalariesQuery : object,
		Mediator.IRequest
		<IEnumerable<GetPersonSalariesQueryResponseViewModel>>
	{
		public GetPersonSalariesQuery() : base()
		{
		}

		public string StartDate { get; set; }
		public string EndDate { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
	}
}

namespace Entekhab.Persistence.ViewModels
{
	public class GetPersonSalariesQueryResponseViewModel : object
	{
		public GetPersonSalariesQueryResponseViewModel() : base()
		{
		}

		 
		public System.Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public decimal BasicSalary { get; set; }

        public decimal Allowance { get; set; }

        public decimal Transportation { get; set; }

        public DateTime DateMiladi { get; set; }

        public string DateShamsi { get; set; }

        public decimal OverTime { get; set; }


    }
}

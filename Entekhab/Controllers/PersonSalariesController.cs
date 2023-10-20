using Entekhab.Application.PersonSalaries.Commands;
using Entekhab.Application.PersonSalaries.Queries;
using Entekhab.Request;
using Entekhab.Utility;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace Entekhab.Api.Controllers
{
    [ApiController]
    [Route(template: "[controller]")]
    public class PersonSalariesController : Entekhab.Infrastructure.ControllerBase
    {
        public PersonSalariesController(MediatR.IMediator mediator) : base(mediator: mediator)
        {
        }

        #region Post (Add JsonPersonSalary)
        [HttpPost(template: "/Json/PersonSalaries/AddPersonSalary")]
        public async Task<IActionResult>
       AddJsonPersonSalary(RequestPost requestPost)
        {
            Data data = DataConvertor.DeserializeJsonToObject(requestPost.Data);

            CreatePersonSalaryCommand request =
                new CreatePersonSalaryCommand()
                {
                    Allowance = data.Allowance,
                    BasicSalary = data.BasicSalary,
                    FirstName = data.FirstName,
                    LastName = data.LastName,
                    OverTimeCalculator = requestPost.OverTimeCalculator,
                    Date = data.Date,
                    Transportation = data.Transportation,
                };

            var result =
                await Mediator.Send(request);

            return FluentResult(result: result);
        }
        #endregion /Post (Add JsonPersonSalary)


        #region Post (Add XMLPersonSalary)
        [HttpPost(template: "/Xml/PersonSalaries/AddPersonSalary")]
        public async Task<IActionResult>
            AddXmlPersonSalary(RequestPost requestPost)
        {
            Data data = DataConvertor.DeserializeXmlToObject(requestPost.Data);

            CreatePersonSalaryCommand request =
                new CreatePersonSalaryCommand()
                {
                    Allowance = data.Allowance,
                    BasicSalary = data.BasicSalary,
                    FirstName = data.FirstName,
                    LastName = data.LastName,
                    OverTimeCalculator = requestPost.OverTimeCalculator,
                    Date = data.Date,
                    Transportation = data.Transportation,
                };

            var result =
                await Mediator.Send(request);

            return FluentResult(result: result);
        }
        #endregion /Post (Add XmlPersonSalary)


        #region Post (Add CsvPersonSalary)
        [HttpPost(template: "/Csv/PersonSalaries/AddPersonSalary")]
        public async Task<IActionResult>
       AddCsvPersonSalary(RequestPost requestPost)
        {
            Data data = DataConvertor.DeserializeCsvToObject(requestPost.Data);

            CreatePersonSalaryCommand request =
                new CreatePersonSalaryCommand()
                {
                    Allowance = data.Allowance,
                    BasicSalary = data.BasicSalary,
                    FirstName = data.FirstName,
                    LastName = data.LastName,
                    OverTimeCalculator = requestPost.OverTimeCalculator,
                    Date = data.Date,
                    Transportation = data.Transportation,
                };

            var result =
                await Mediator.Send(request);

            return FluentResult(result: result);
        }
        #endregion /Post (Add CsvPersonSalary)


        #region Post (Add CoustomPersonSalary)
        [HttpPost(template: "/Coustom/PersonSalaries/AddPersonSalary")]
        public async Task<IActionResult>
       AddCoustomPersonSalary(RequestPost requestPost)
        {
            Data data = DataConvertor.DeserializeCustomToObject(requestPost.Data);

            CreatePersonSalaryCommand request =
                new CreatePersonSalaryCommand()
                {
                    Allowance = data.Allowance,
                    BasicSalary = data.BasicSalary,
                    FirstName = data.FirstName,
                    LastName = data.LastName,
                    OverTimeCalculator = requestPost.OverTimeCalculator,
                    Date = data.Date,
                    Transportation = data.Transportation,
                };

            var result =
                await Mediator.Send(request);

            return FluentResult(result: result);
        }
        #endregion /Post (Add CoustomPersonSalary)


        #region Post (Add PersonSalary)
        [HttpPost(template: "AddPersonSalary")]
        public async Task<IActionResult>
            AddPersonSalary(CreatePersonSalaryCommand request)
        {
            var result =
                await Mediator.Send(request);

            return FluentResult(result: result);
        }
        #endregion /Post (Add PersonSalary)


        #region Put (Update PersonSalary)
        [HttpPut(template: "UpdatePersonSalary")]
        public async Task<IActionResult>
            UpdatePersonSalary(UpdatePersonSalaryCommand request)
        {
            var result =
                await Mediator.Send(request);

            return FluentResult(result: result);
        }
        #endregion /Put (Update PersonSalary)


        #region Delete (Delete PersonSalary)
        [HttpDelete(template: "DeletePersonSalary")]
        public async Task<IActionResult>
            DeletePersonSalary(DeletePersonSalaryCommand request)
        {
            var result =
                await Mediator.Send(request);

            return FluentResult(result: result);
        }
        #endregion /Put (Update PersonSalary)


        #region Get (Get PersonSalary)
        [HttpGet(template: "GetPersonSalary")]
        public async Task <IActionResult> GetPersonSalary(string date,string firstName,string lastName)
        {
            GetPersonSalaryQuery request 
                = new GetPersonSalaryQuery()
                {
                    Date = date,
                    FirstName = firstName,
                    LastName = lastName
                };

            var result =
                await Mediator.Send(request);

            return FluentResult(result: result);
        }
        #endregion /Get (Get PersonSalary)


        #region GetAll (Get PersonSalaries)
        [HttpGet(template: "GetPersonSalaries")]
        public async Task<IActionResult> GetPersonSalaries(string startDate, string endDate, string firstName, string lastName)
        {
            GetPersonSalariesQuery request
                = new GetPersonSalariesQuery()
                {
                    StartDate = startDate,
                    EndDate = endDate,
                    FirstName = firstName,
                    LastName = lastName
                };

            var result =
                await Mediator.Send(request);

            return FluentResult(result: result);
        }
        #endregion /GetAll (Get PersonSalaries)

    }
}

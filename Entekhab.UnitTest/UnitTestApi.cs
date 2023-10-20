using Entekhab.Application.PersonSalaries.Commands;
using Entekhab.Domain.Models;
using Entekhab.Persistence.Base;
using Entekhab.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Entekhab.UnitTest
{
    [TestClass]
    public class UnitTestApi


    {
    
        [TestMethod]
        public void TestResultCreatePersonSalary()
        {
            var mockMediator = new Moq.Mock<IMediator>();

            Entekhab.Api.Controllers.PersonSalariesController PersonSalariesController 
                = new Entekhab.Api.Controllers.PersonSalariesController(mockMediator.Object);

            Task<IActionResult> result = PersonSalariesController.AddPersonSalary(
                Moq.It.IsAny<CreatePersonSalaryCommand>());

            Assert.IsInstanceOfType(result, typeof(Task<IActionResult>));

        }

        [TestMethod]
        public void TestResultAddXmlPersonSalary()
        {
            var mockMediator = new Moq.Mock<IMediator>();

            Entekhab.Api.Controllers.PersonSalariesController PersonSalariesController
                = new Entekhab.Api.Controllers.PersonSalariesController(mockMediator.Object);

            Task<IActionResult> result = PersonSalariesController.AddXmlPersonSalary(
                Moq.It.IsAny<RequestPost>());

            Assert.IsInstanceOfType(result, typeof(Task<IActionResult>));

        }

        [TestMethod]
        public void TestResultAddCsvPersonSalary()
        {
            var mockMediator = new Moq.Mock<IMediator>();

            Entekhab.Api.Controllers.PersonSalariesController PersonSalariesController
                = new Entekhab.Api.Controllers.PersonSalariesController(mockMediator.Object);

            Task<IActionResult> result = PersonSalariesController.AddCsvPersonSalary(
                Moq.It.IsAny<RequestPost>());

            Assert.IsInstanceOfType(result, typeof(Task<IActionResult>));

        }

        [TestMethod]
        public void TestResultAddJsonPersonSalary()
        {
            var mockMediator = new Moq.Mock<IMediator>();

            Entekhab.Api.Controllers.PersonSalariesController PersonSalariesController
                = new Entekhab.Api.Controllers.PersonSalariesController(mockMediator.Object);

            Task<IActionResult> result = PersonSalariesController.AddJsonPersonSalary(
                Moq.It.IsAny<RequestPost>());

            Assert.IsInstanceOfType(result, typeof(Task<IActionResult>));

        }

        [TestMethod]
        public void TestResultAddCoustomPersonSalary()
        {
            var mockMediator = new Moq.Mock<IMediator>();

            Entekhab.Api.Controllers.PersonSalariesController PersonSalariesController
                = new Entekhab.Api.Controllers.PersonSalariesController(mockMediator.Object);

            Task<IActionResult> result = PersonSalariesController.AddCoustomPersonSalary(
                Moq.It.IsAny<RequestPost>());

            Assert.IsInstanceOfType(result, typeof(Task<IActionResult>));

        }
    }
}
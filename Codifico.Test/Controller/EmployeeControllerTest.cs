using Codifico.Model.Dto;
using Codifico.Model.Util;
using Codifico.Services.Service;
using Codifico.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Codifico.Test.Controller
{
    public class EmployeeControllerTest
    {
		[Fact]
		public async Task GetEmployees_ReturnOkResult_WhenSuccess()
		{
			var service = new Mock<IEmployeeService>();

			var listEmployee = new List<EmployeeDto>();
			var client = new EmployeeDto
			{
				EmpId = 1,
				Name = "test"
			};

			listEmployee.Add(client);
			var response = ResponseStatus.ResponseSucessful<IEnumerable<EmployeeDto>>(listEmployee);

			service.Setup(x => x.GetEmployees()).ReturnsAsync(response);

			var controller = new EmployeeController(service.Object);
			var result = await controller.GetEmployees();
			var okResult = Assert.IsType<OkObjectResult>(result);

			Assert.IsType<OkObjectResult>(okResult);
		}

		[Fact]
		public async Task GetEmployeesForNameAndId_ReturnInternalServerErrorResult_WhenFail()
		{
			var service = new Mock<IEmployeeService>();

			var response = ResponseStatus.ResponseError<IEnumerable<EmployeeDto>>("prueba error");

			service.Setup(x => x.GetEmployees()).ReturnsAsync(response);

			var controller = new EmployeeController(service.Object);
			var result = await controller.GetEmployees();
			var objectResult = Assert.IsType<ObjectResult>(result);
			Assert.Equal(500, objectResult.StatusCode);
		}
	}
}

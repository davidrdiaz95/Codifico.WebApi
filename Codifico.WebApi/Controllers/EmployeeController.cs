using Codifico.Services.Service;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Codifico.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EmployeeController : ControllerBase
	{
		private readonly IEmployeeService employeeService;

		public EmployeeController(IEmployeeService employeeService)
		{
			this.employeeService = employeeService;
		}

		[HttpGet]
		[Route("")]
		public async Task<IActionResult> GetEmployees()
		{
			var response = await this.employeeService.GetEmployees();
			return response.StatusCode.Equals(HttpStatusCode.OK) ? 
				Ok(response) :
				StatusCode(StatusCodes.Status500InternalServerError, response);
		}
	}
}

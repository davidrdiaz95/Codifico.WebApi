using Codifico.Services.Service;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Codifico.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ClientOrderController : ControllerBase
	{
		private readonly IClientOrderService clienteorderService;

		public ClientOrderController(IClientOrderService clienteOrderService)
		{
			this.clienteorderService = clienteOrderService;
		}

		[HttpGet]
		[Route("GetClientOrders")]
		public async Task<IActionResult> GetClientOrders(int? id,int page = 1, int size = 10)
		{
			var employees = await this.clienteorderService.GetClientOrdersForNameAndId(id,page,size);
			return employees.StatusCode.Equals(HttpStatusCode.OK) ?
				Ok(employees) :
				StatusCode(StatusCodes.Status500InternalServerError, employees);
		}
	}
}

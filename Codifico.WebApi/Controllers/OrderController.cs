using Codifico.Model.Dto;
using Codifico.Services.Service;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Codifico.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OrderController : ControllerBase
	{
		private readonly IOrderService orderService;

		public OrderController(IOrderService orderService)
		{
			this.orderService = orderService;
		}

		[HttpPost]
		[Route("AddNewOrder")]
		public async Task<IActionResult> AddNewOrder(NewOrderDto newOrder)
		{
			var response = await this.orderService.AddNewOrder(newOrder);
			return response.StatusCode.Equals(HttpStatusCode.OK) ? 
				Ok(response) : 
				StatusCode(StatusCodes.Status500InternalServerError, response);
		}
	}
}

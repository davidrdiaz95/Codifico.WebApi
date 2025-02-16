using Codifico.Services.Service;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Codifico.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ShipperController : ControllerBase
	{
		private readonly IShipperService shipperService;

		public ShipperController(IShipperService shipperService)
		{
			this.shipperService = shipperService;
		}

		[HttpGet]
		[Route("GetShippers")]
		public async Task<IActionResult> GetShippers()
		{
			var shippers = await this.shipperService.GetShippers();
			return shippers.StatusCode.Equals(HttpStatusCode.OK) ?
				Ok(shippers) :
				StatusCode(StatusCodes.Status500InternalServerError, shippers);
		}
	}
}

using Codifico.Services.Service;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Codifico.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private readonly IProductService productService;

		public ProductController(IProductService productService)
		{
			this.productService = productService;
		}

		[HttpGet]
		[Route("GetProducts")]
		public async Task<IActionResult> GetProducts()
		{
			var products = await this.productService.GetProducts();
			return products.StatusCode.Equals(HttpStatusCode.OK) ? 
				Ok(products) :
				StatusCode(StatusCodes.Status500InternalServerError, products);
		}	
	}
}

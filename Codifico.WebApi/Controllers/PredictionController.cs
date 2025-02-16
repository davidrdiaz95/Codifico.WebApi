using Codifico.Services.Service;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Codifico.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PredictionController : ControllerBase
	{
		private readonly IPredictionService predictionService;

		public PredictionController(IPredictionService predictionService)
		{
			this.predictionService = predictionService;
		}

		[HttpGet]
		[Route("GetSalesDatePrediction")]
		public async Task<IActionResult> GetSalesDatePrediction(int page=1, int size=10, string search="")
		{
			var prediction = await this.predictionService.GetSalesDatePrediction(page,size, search);
			return prediction.StatusCode.Equals(HttpStatusCode.OK)? 
				Ok(prediction) :
				StatusCode(StatusCodes.Status500InternalServerError, prediction);
		}
	}
}

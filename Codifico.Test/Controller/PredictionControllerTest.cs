using Codifico.Model.Dto;
using Codifico.Model.Util;
using Codifico.Services.Service;
using Codifico.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Codifico.Test.Controller
{
    public class PredictionControllerTest
    {
		[Fact]
		public async Task GetSalesDatePrediction_ReturnOkResult_WhenSuccess()
		{
			var service = new Mock<IPredictionService>();
			int page = 1;
			int size = 1;
			string search = "test";
			var listeSale = new List<SalesDatePredictionDto>();
			var sale = new SalesDatePredictionDto
			{
				CustomerName = "test",
			};
			listeSale.Add(sale);
			var response = ResponseStatus.ResponseSucessful<IEnumerable<SalesDatePredictionDto>>(listeSale);

			service.Setup(x => x.GetSalesDatePrediction(page,size,search)).ReturnsAsync(response);

			var controller = new PredictionController(service.Object);
			var result = await controller.GetSalesDatePrediction(page,size,search);
			var okResult = Assert.IsType<OkObjectResult>(result);

			Assert.IsType<OkObjectResult>(okResult);
		}

		[Fact]
		public async Task GetSalesDatePrediction_ReturnInternalServerErrorResult_WhenFail()
		{
			var service = new Mock<IPredictionService>();
			int page = 1;
			int size = 1;
			string search = "test";
			var newOrder = new NewOrderDto
			{
				EmpId = 1
			};
			var response = ResponseStatus.ResponseError<IEnumerable<SalesDatePredictionDto>>("prueba error");
			service.Setup(x => x.GetSalesDatePrediction(page, size, search)).ReturnsAsync(response);

			var controller = new PredictionController(service.Object);
			var result = await controller.GetSalesDatePrediction(page, size, search);
			var objectResult = Assert.IsType<ObjectResult>(result);
			Assert.Equal(500, objectResult.StatusCode);
		}
	}
}

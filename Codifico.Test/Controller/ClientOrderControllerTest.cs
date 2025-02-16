using Codifico.Model.Dto;
using Codifico.Model.Util;
using Codifico.Services.Service;
using Codifico.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Codifico.Test.Controller
{
	public class ClientOrderControllerTest
	{
		[Fact]
		public async Task GetClientOrders_ReturnOkResult_WhenSuccess()
		{
			var service = new Mock<IClientOrderService>();

			int id = 1;
			int page = 1;
			int size = 1;
			var listClient = new List<ClientOrderDto>();
			var client = new ClientOrderDto
			{
				OrderId = 1,
				RequiredDate = DateTime.Now,
				ShippedDate = DateTime.Now,
				ShipName = "test"
			};
			listClient.Add(client);
			var response = ResponseStatus.ResponseSucessful<IEnumerable<ClientOrderDto>>(listClient);

			service.Setup(x => x.GetClientOrdersForNameAndId(id,page,size)).ReturnsAsync(response);

			var controller = new ClientOrderController(service.Object);
			var result = await controller.GetClientOrders(id,page,size);
			var okResult = Assert.IsType<OkObjectResult>(result);

			Assert.IsType<OkObjectResult>(okResult);
		}

		[Fact]
		public async Task GetClientOrders_ReturnInternalServerErrorResult_WhenFail()
		{
			var service = new Mock<IClientOrderService>();

			string name = "test";
			int id = 1;
			int page = 1;
			int size = 1;

			var response = ResponseStatus.ResponseError<IEnumerable<ClientOrderDto>>("prueba error");
			service.Setup(x => x.GetClientOrdersForNameAndId(id,page,size)).ReturnsAsync(response);

			var controller = new ClientOrderController(service.Object);
			var result = await controller.GetClientOrders(id, page, size);
			var objectResult = Assert.IsType<ObjectResult>(result);
			Assert.Equal(500, objectResult.StatusCode);
		}
	}
}

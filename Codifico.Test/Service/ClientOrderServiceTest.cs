using Codifico.BusinessServices.Service;
using Codifico.Model.Dto;
using Codifico.Services.Command;
using Moq;
using System.Net;

namespace Codifico.Test.Service
{
    public class ClientOrderServiceTest
    {
		[Fact]
		public async Task GetClientOrdersForNameAndId_ReturnOkResult_WhenSuccess()
		{
			var service = new Mock<IGetClientOrderForNameAndIdCommand>();
			int page = 1;
			int size = 1;
			int id = 1;

			var listClinet = new List<ClientOrderDto>() {new ClientOrderDto
			{
				OrderId = 1,
				RequiredDate = DateTime.Now,
				ShipName = "test",
				ShippedDate = DateTime.Now
			}};

			service.Setup(x => x.Execute(id,page,size)).ReturnsAsync(listClinet);

			var controller = new ClientOrderService(service.Object);
			var result = await controller.GetClientOrdersForNameAndId(id, page, size);

			Assert.Equal(HttpStatusCode.OK, result.StatusCode);
		}

		[Fact]
		public async Task GetClientOrdersForNameAndId_ReturnOkResult_WhenNotFound()
		{
			var service = new Mock<IGetClientOrderForNameAndIdCommand>();
			int page = 1;
			int size = 1;
			int id = 1;

			var listClinet = new List<ClientOrderDto>();

			service.Setup(x => x.Execute(id, page, size)).ReturnsAsync(listClinet);

			var controller = new ClientOrderService(service.Object);
			var result = await controller.GetClientOrdersForNameAndId(id, page, size);

			Assert.NotEqual(HttpStatusCode.OK, result.StatusCode);
		}
	}
}

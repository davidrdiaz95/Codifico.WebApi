using Codifico.Model.Dto;
using Codifico.Model.Util;
using Codifico.Services.Service;
using Codifico.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codifico.Test.Controller
{
    public class OrderControllerTest
    {
		[Fact]
		public async Task AddNewOrder_ReturnOkResult_WhenSuccess()
		{
			var service = new Mock<IOrderService>();

			var newOrder = new NewOrderDto
			{
				EmpId = 1
			};
			var response = ResponseStatus.ResponseSucessful<string>("test exitoso");

			service.Setup(x => x.AddNewOrder(newOrder)).ReturnsAsync(response);

			var controller = new OrderController(service.Object);
			var result = await controller.AddNewOrder(newOrder);
			var okResult = Assert.IsType<OkObjectResult>(result);

			Assert.IsType<OkObjectResult>(okResult);
		}

		[Fact]
		public async Task AddNewOrder_ReturnInternalServerErrorResult_WhenFail()
		{
			var service = new Mock<IOrderService>();

			var newOrder = new NewOrderDto
			{
				EmpId = 1
			};
			var response = ResponseStatus.ResponseError<string>("prueba error");
			service.Setup(x => x.AddNewOrder(newOrder)).ReturnsAsync(response);

			var controller = new OrderController(service.Object);
			var result = await controller.AddNewOrder(newOrder);
			var objectResult = Assert.IsType<ObjectResult>(result);
			Assert.Equal(500, objectResult.StatusCode);
		}
	}
}

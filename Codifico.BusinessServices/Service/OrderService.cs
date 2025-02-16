using Codifico.Model.Dto;
using Codifico.Model.Util;
using Codifico.Services.Invoker;
using Codifico.Services.Service;

namespace Codifico.BusinessServices.Service
{
	public class OrderService : IOrderService
	{
		private readonly IAddNewOrderInvoker addNewOrderInvoker;

		public OrderService(IAddNewOrderInvoker addNewOrderInvoker)
		{
			this.addNewOrderInvoker = addNewOrderInvoker;
		}

		public async Task<ResponseDTO<string>> AddNewOrder(NewOrderDto newOrder)
		{
			var employees = await this.addNewOrderInvoker.Execute(newOrder);
			return employees > 0 ?
				ResponseStatus.ResponseSucessful<string>("Se registro la orden correctamente") :
				ResponseStatus.ResponseWithoutData<string>("No no pudo relizar la orden");
		}
	}
}

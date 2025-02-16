using Codifico.Model.Dto;
using Codifico.Repository.Constant;
using Codifico.Repository.Entity;
using Codifico.Repository.Repository.Interface;
using Codifico.Services.Invoker;
using Microsoft.Data.SqlClient;

namespace Codifico.BusinessServices.Invoker
{
	public class AddNewOrderInvoker : IAddNewOrderInvoker
	{
		private readonly IRepository<NewOrder> repository;

		public AddNewOrderInvoker(IRepository<NewOrder> repository)
		{
			this.repository = repository;
		}

		public async Task<int> Execute(NewOrderDto newOrderDto)
		{
			var parameters = new List<SqlParameter>();
			parameters.Add(new SqlParameter(Parameter.CustId, newOrderDto.CustId));
			parameters.Add(new SqlParameter(Parameter.EmpId, newOrderDto.EmpId));
			parameters.Add(new SqlParameter(Parameter.ShipperId, newOrderDto.ShipperId));
			parameters.Add(new SqlParameter(Parameter.ShipName, newOrderDto.ShipName));
			parameters.Add(new SqlParameter(Parameter.ShipAddress, newOrderDto.ShipAddress));
			parameters.Add(new SqlParameter(Parameter.ShipCity, newOrderDto.ShipCity));
			parameters.Add(new SqlParameter(Parameter.OrderDate, newOrderDto.OrderDate.ToString("yyyy-MM-dd")));
			parameters.Add(new SqlParameter(Parameter.RequiredDate, newOrderDto.RequiredDate.ToString("yyyy-MM-dd")));
			parameters.Add(new SqlParameter(Parameter.ShippedDate, newOrderDto.ShippedDate.ToString("yyyy-MM-dd")));
			parameters.Add(new SqlParameter(Parameter.Freight, newOrderDto.Freight));
			parameters.Add(new SqlParameter(Parameter.ShipCountry, newOrderDto.ShipCountry));
			parameters.Add(new SqlParameter(Parameter.PoductId, newOrderDto.PoductId));
			parameters.Add(new SqlParameter(Parameter.UnitPrice, newOrderDto.UnitPrice));
			parameters.Add(new SqlParameter(Parameter.Qty, newOrderDto.Qty));
			parameters.Add(new SqlParameter(Parameter.Discount, newOrderDto.Discount));

			var client = this.repository.ExecuteSp(Procedure.AddNewOrder, parameters);
			return client;

		}
	}
}

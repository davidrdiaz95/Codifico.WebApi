using Codifico.Model.Dto;
using Codifico.Repository.Entity;
using Codifico.Services.Mapper;

namespace Codifico.BusinessServices.Mapper
{
	public class ClientOrderMapper : IMapper<GetClientOrder, ClientOrderDto>
	{
		public ClientOrderDto MapFrom(GetClientOrder model)
		{
			return new ClientOrderDto
			{
				OrderId = model.OrderId,
				RequiredDate = model.RequiredDate,
				ShippedDate = model.ShippedDate,
				ShipName = model.ShipName,
				Count = model.Count
			};
		}

		public GetClientOrder MapTo(ClientOrderDto model)
		{
			return new GetClientOrder
			{
				OrderId = model.OrderId,
				RequiredDate = model.RequiredDate,
				ShippedDate = model.ShippedDate,
				ShipName = model.ShipName,
				Count = model.Count
			};
		}
	}
}

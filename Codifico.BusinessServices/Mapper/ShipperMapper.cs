using Codifico.Model.Dto;
using Codifico.Repository.Entity;
using Codifico.Services.Mapper;

namespace Codifico.BusinessServices.Mapper
{
	public class ShipperMapper : IMapper<Shipper, ShipperDto>
	{
		public ShipperDto MapFrom(Shipper model)
		{
			return new ShipperDto
			{
				CompanyName = model.CompanyName,
				ShipperId = model.ShipperId
			};
		}

		public Shipper MapTo(ShipperDto model)
		{
			return new Shipper
			{
				CompanyName = model.CompanyName,
				ShipperId = model.ShipperId
			};
		}
	}
}

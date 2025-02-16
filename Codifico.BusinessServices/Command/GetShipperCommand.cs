using Codifico.Model.Dto;
using Codifico.Repository.Constant;
using Codifico.Repository.Entity;
using Codifico.Repository.Repository.Interface;
using Codifico.Services.Command;
using Codifico.Services.Mapper;

namespace Codifico.BusinessServices.Command
{
	public class GetShipperCommand : IGetShipperCommand
	{
		private readonly IRepository<Shipper> repository;
		private readonly IMapper<Shipper, ShipperDto> mapper;

		public GetShipperCommand(IRepository<Shipper> repository,
			IMapper<Shipper, ShipperDto> mapper)
		{
			this.repository = repository;
			this.mapper = mapper;
		}

		public async Task<IEnumerable<ShipperDto>> Execute()
		{
			var shipper = this.repository.ExecuteSpTable(Procedure.GetShippers);
			return shipper.Select(x => this.mapper.MapFrom(x));
		}
	}
}

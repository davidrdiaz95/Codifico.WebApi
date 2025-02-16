using Codifico.Model.Dto;
using Codifico.Model.Util;
using Codifico.Services.Command;
using Codifico.Services.Service;

namespace Codifico.BusinessServices.Service
{
	public class ShipperService : IShipperService
	{
		private readonly IGetShipperCommand getShipperCommand;

		public ShipperService(IGetShipperCommand getShipperCommand)
		{
			this.getShipperCommand = getShipperCommand;
		}

		public async Task<ResponseDTO<IEnumerable<ShipperDto>>> GetShippers()
		{
			var shipper = await this.getShipperCommand.Execute();
			return shipper.Any() ?
				ResponseStatus.ResponseSucessful<IEnumerable<ShipperDto>>(shipper) :
				ResponseStatus.ResponseWithoutData<IEnumerable<ShipperDto>>("No se encontraron transportistas");
		}
	}
}

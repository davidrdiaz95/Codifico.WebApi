using Codifico.Model.Dto;

namespace Codifico.Services.Service
{
    public interface IShipperService
    {
        Task<ResponseDTO<IEnumerable<ShipperDto>>> GetShippers();
	}
}

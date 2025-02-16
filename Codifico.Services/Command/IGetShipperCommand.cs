using Codifico.Model.Dto;

namespace Codifico.Services.Command
{
    public interface IGetShipperCommand
    {
        Task<IEnumerable<ShipperDto>> Execute();
    }
}

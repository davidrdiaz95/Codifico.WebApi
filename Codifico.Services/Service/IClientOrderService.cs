using Codifico.Model.Dto;

namespace Codifico.Services.Service
{
    public interface IClientOrderService
    {
        Task<ResponseDTO<IEnumerable<ClientOrderDto>>> GetClientOrdersForNameAndId(int? id, int page = 1, int size = 10);
	}
}

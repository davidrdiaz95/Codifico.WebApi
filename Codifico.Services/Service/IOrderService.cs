using Codifico.Model.Dto;

namespace Codifico.Services.Service
{
    public interface IOrderService
    {
        Task<ResponseDTO<string>> AddNewOrder(NewOrderDto newOrder);
    }
}

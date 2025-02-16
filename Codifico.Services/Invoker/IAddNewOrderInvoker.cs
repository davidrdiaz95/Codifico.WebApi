using Codifico.Model.Dto;

namespace Codifico.Services.Invoker
{
    public interface IAddNewOrderInvoker
    {
        Task<int> Execute(NewOrderDto newOrderDto);
    }
}

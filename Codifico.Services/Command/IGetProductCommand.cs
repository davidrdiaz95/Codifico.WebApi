using Codifico.Model.Dto;

namespace Codifico.Services.Command
{
    public interface IGetProductCommand
    {
        Task<IEnumerable<ProductDto>> Execute();
    }
}

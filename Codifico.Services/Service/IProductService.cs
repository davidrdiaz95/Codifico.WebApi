using Codifico.Model.Dto;

namespace Codifico.Services.Service
{
    public interface IProductService
    {
		Task<ResponseDTO<IEnumerable<ProductDto>>> GetProducts();
	}
}

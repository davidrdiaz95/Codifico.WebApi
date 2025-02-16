using Codifico.Model.Dto;
using Codifico.Model.Util;
using Codifico.Services.Command;
using Codifico.Services.Service;

namespace Codifico.BusinessServices.Service
{
	public class ProductService : IProductService
	{
		private readonly IGetProductCommand getProductCommand;

		public ProductService(IGetProductCommand getProductCommand)
		{
			this.getProductCommand = getProductCommand;
		}

		public async Task<ResponseDTO<IEnumerable<ProductDto>>> GetProducts()
		{
			var product = await this.getProductCommand.Execute();
			return product.Any() ?
				ResponseStatus.ResponseSucessful<IEnumerable<ProductDto>>(product) :
				ResponseStatus.ResponseWithoutData<IEnumerable<ProductDto>>("No se encontraron productos");
		}
	}
}

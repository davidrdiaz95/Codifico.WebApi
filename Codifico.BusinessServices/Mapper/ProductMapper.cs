using Codifico.Model.Dto;
using Codifico.Repository.Entity;
using Codifico.Services.Mapper;

namespace Codifico.BusinessServices.Mapper
{
	public class ProductMapper : IMapper<Product, ProductDto>
	{
		public ProductDto MapFrom(Product model)
		{
			return new ProductDto
			{
				ProductId = model.ProductId,
				ProductName = model.ProductName
			};
		}

		public Product MapTo(ProductDto model)
		{
			return new Product
			{
				ProductId = model.ProductId,
				ProductName = model.ProductName
			};
		}
	}
}

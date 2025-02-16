using Codifico.Model.Dto;
using Codifico.Repository.Constant;
using Codifico.Repository.Entity;
using Codifico.Repository.Repository.Interface;
using Codifico.Services.Command;
using Codifico.Services.Mapper;

namespace Codifico.BusinessServices.Command
{
	public class GetProductCommand : IGetProductCommand
	{
		private readonly IRepository<Product> repository;
		private readonly IMapper<Product, ProductDto> mapper;

		public GetProductCommand(IRepository<Product> repository,
			IMapper<Product, ProductDto> mapper)
		{
			this.repository = repository;
			this.mapper = mapper;
		}

		public async Task<IEnumerable<ProductDto>> Execute()
		{
			var product = this.repository.ExecuteSpTable(Procedure.GetProducts);
			return product.Select(x => this.mapper.MapFrom(x));
		}
	}
}

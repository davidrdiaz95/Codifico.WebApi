using Codifico.Model.Dto;
using Codifico.Repository.Constant;
using Codifico.Repository.Entity;
using Codifico.Repository.Repository.Interface;
using Codifico.Services.Command;
using Codifico.Services.Mapper;
using Microsoft.Data.SqlClient;

namespace Codifico.BusinessServices.Command
{
	public class GetClientOrderForNameAndIdCommand : IGetClientOrderForNameAndIdCommand
	{
		private readonly IRepository<GetClientOrder> repository;
		private readonly IMapper<GetClientOrder, ClientOrderDto> mapper;

		public GetClientOrderForNameAndIdCommand(IRepository<GetClientOrder> repository,
			IMapper<GetClientOrder, ClientOrderDto> mapper)
		{
			this.repository = repository;
			this.mapper = mapper;
		}

		public async Task<IEnumerable<ClientOrderDto>> Execute(int? id, int page = 1, int size = 10)
		{
			var parameters = new List<SqlParameter>();
			if (id != null)
				parameters.Add(new SqlParameter(Parameter.IdCustomer, id));

			parameters.Add(new SqlParameter(Parameter.Size, size));
			parameters.Add(new SqlParameter(Parameter.Page, page));

			if (!parameters.Any())
				return null;

			var client = this.repository.ExecuteSpTable(Procedure.GetClientOrders, parameters);
			if (!client.Any())
				return null;

			return client.Select(x=> this.mapper.MapFrom(x));
		}
	}
}

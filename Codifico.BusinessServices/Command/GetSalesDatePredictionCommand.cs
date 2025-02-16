using Codifico.Model.Dto;
using Codifico.Repository.Constant;
using Codifico.Repository.Entity;
using Codifico.Repository.Repository.Interface;
using Codifico.Services.Command;
using Codifico.Services.Mapper;
using Microsoft.Data.SqlClient;

namespace Codifico.BusinessServices.Command
{
	public class GetSalesDatePredictionCommand : IGetSalesDatePredictionCommand
	{
		private readonly IRepository<SalesDatePrediction> repository;
		private readonly IMapper<SalesDatePrediction, SalesDatePredictionDto> mapper;

		public GetSalesDatePredictionCommand(IRepository<SalesDatePrediction> repository,
			IMapper<SalesDatePrediction, SalesDatePredictionDto> mapper)
		{
			this.repository = repository;
			this.mapper = mapper;
		}

		public async Task<IEnumerable<SalesDatePredictionDto>> Execute(int page, int size,string search)
		{
			var parameters = new List<SqlParameter>();
			parameters.Add(new SqlParameter(Parameter.Size, size));
			parameters.Add(new SqlParameter(Parameter.Page, page));
			parameters.Add(new SqlParameter(Parameter.Search, search));

			var prediction = this.repository.ExecuteSpTable(Procedure.SalesDatePrediction, parameters);
			return prediction.Select(x => this.mapper.MapFrom(x));

		}
	}
}

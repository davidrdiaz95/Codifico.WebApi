using Codifico.Model.Dto;
using Codifico.Repository.Entity;
using Codifico.Services.Mapper;

namespace Codifico.BusinessServices.Mapper
{
	public class SalesDatePredictionMapper : IMapper<SalesDatePrediction, SalesDatePredictionDto>
	{
		public SalesDatePredictionDto MapFrom(SalesDatePrediction model)
		{
			var dto = new SalesDatePredictionDto
			{
				CustomerName = model.CustomerName,
				LastOrderDate = model.LastOrderDate,
				NextPredictedOrder = model.NextPredictedOrder,
				Count = model.Count,
				CustomerId = model.CustomerId
			};
			return dto;
		}

		public SalesDatePrediction MapTo(SalesDatePredictionDto model)
		{
			var entity = new SalesDatePrediction
			{
				CustomerName = model.CustomerName,
				LastOrderDate = model.LastOrderDate,
				NextPredictedOrder = model.NextPredictedOrder,
				Count = model.Count,
				CustomerId = model.CustomerId
			};
			return entity;
		}
	}
}

using Codifico.Model.Dto;
using Codifico.Model.Util;
using Codifico.Services.Command;
using Codifico.Services.Service;

namespace Codifico.BusinessServices.Service
{
	public class PredictionService : IPredictionService
	{
		private readonly IGetSalesDatePredictionCommand getSalesDatePredictionCommand;

		public PredictionService(IGetSalesDatePredictionCommand getSalesDatePredictionCommand)
		{
			this.getSalesDatePredictionCommand = getSalesDatePredictionCommand;
		}


		public async Task<ResponseDTO<IEnumerable<SalesDatePredictionDto>>> GetSalesDatePrediction(int page, int size, string search)
		{
			var prediction = await this.getSalesDatePredictionCommand.Execute(page, size,search);
			return prediction.Any() ?
				ResponseStatus.ResponseSucessful<IEnumerable<SalesDatePredictionDto>>(prediction) :
				ResponseStatus.ResponseWithoutData<IEnumerable<SalesDatePredictionDto>>("No se encontraron predicciones");
		}
	}
}

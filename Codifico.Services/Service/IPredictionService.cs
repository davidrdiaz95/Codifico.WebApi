using Codifico.Model.Dto;

namespace Codifico.Services.Service
{
    public interface IPredictionService
    {
		Task<ResponseDTO<IEnumerable<SalesDatePredictionDto>>> GetSalesDatePrediction(int page, int size, string search);
	}
}

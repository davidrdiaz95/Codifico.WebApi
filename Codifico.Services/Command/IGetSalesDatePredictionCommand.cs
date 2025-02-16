using Codifico.Model.Dto;

namespace Codifico.Services.Command
{
    public interface IGetSalesDatePredictionCommand
    {
        Task<IEnumerable<SalesDatePredictionDto>> Execute(int page, int size, string search);
	}
}

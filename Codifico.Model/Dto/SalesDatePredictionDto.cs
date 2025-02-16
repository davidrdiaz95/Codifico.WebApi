namespace Codifico.Model.Dto
{
    public class SalesDatePredictionDto
    {
		public int CustomerId { get; set; }
		public string? CustomerName { get; set; }
		public DateTime? LastOrderDate { get; set; }
		public DateTime? NextPredictedOrder { get; set; }
		public int Count { get; set; }
	}
}

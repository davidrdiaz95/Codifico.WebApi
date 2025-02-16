namespace Codifico.Repository.Entity
{
    public class SalesDatePrediction
    {
		public int CustomerId { get; set; }
		public string? CustomerName { get; set; }
		public DateTime? LastOrderDate { get; set; }
		public DateTime? NextPredictedOrder { get; set; }
		public int Count { get; set; }
	}
}

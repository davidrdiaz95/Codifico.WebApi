namespace Codifico.Repository.Entity
{
    public class GetClientOrder
    {
		public int? OrderId { get; set; }
		public DateTime? RequiredDate { get; set; }
		public DateTime? ShippedDate { get; set; }
		public string? ShipName { get; set; }
		public int Count { get; set; }
	}
}

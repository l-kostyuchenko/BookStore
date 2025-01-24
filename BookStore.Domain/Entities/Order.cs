namespace BookStore.Domain.Entities
{
	public class Order : BaseEntity
	{
		public DateTimeOffset OrderDate { get; set; }
		public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
		public string CustomerName { get; set; } 
	}
}

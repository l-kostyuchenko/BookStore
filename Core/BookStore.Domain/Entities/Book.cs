namespace BookStore.Domain.Entities
{
	public class Book : BaseEntity
	{		
		public required string Title { get; set; }
		public required string Author { get; set; }
		public string ISBN { get; set; }
		public decimal Price { get; set; }
		public string Description { get; set; }		
		public DateTimeOffset PublicationDate { get; set; }
		
		public List<Category> Categories { get; set; } = new List<Category>();
	}
}

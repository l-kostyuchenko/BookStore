namespace BookStore.DTOs
{
	public class BookDetailsDto
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Author { get; set; }
		public string ISBN { get; set; }
		public decimal Price { get; set; }
		public string Description { get; set; }
		public int Stock { get; set; }
		public DateTime PublicationDate { get; set; }
		public string CoverImageUrl { get; set; }
		public List<string> Categories { get; set; }

	}
}

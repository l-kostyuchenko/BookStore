namespace BookStore.DTOs
{
	public class BookDto
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Author { get; set; }
		public decimal Price { get; set; }
		public string CoverImageUrl { get; set; }
		public List<string> Categories { get; set; }
	}
}

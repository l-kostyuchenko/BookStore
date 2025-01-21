using BookStore.Domain.Entities;

namespace BookStore.Domain.DTOs.Book
{
    public class BookDto
	{
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public DateTime PublicationDate { get; set; }
        public List<string> Categories { get; set; }
    }
}

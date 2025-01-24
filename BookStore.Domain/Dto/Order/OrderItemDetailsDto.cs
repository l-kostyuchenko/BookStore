namespace BookStore.Domain.Dto.Order
{
    public class OrderItemDetailsDto
    {
        public string BookTitle { get; set; }
        public string Author { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}

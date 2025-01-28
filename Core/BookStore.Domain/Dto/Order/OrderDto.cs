namespace BookStore.Domain.Dto.Order
{
    public class OrderDto
    {
        public int Id { get; set; }
        public DateTimeOffset OrderDate { get; set; }
        public List<OrderItemDetailsDto> OrderItems { get; set; }
        public decimal TotalAmount { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
    }
}

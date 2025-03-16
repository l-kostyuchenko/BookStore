namespace BookStore.Domain.Dto.Order
{
    public class CreateOrderDto
    {
        public List<OrderItemDto> OrderItems { get; set; }
        public string CustomerName { get; set; }        
    }
}

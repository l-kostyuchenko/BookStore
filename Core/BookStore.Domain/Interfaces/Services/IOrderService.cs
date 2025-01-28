using BookStore.Domain.Dto.Order;

namespace BookStore.Domain.Interfaces.Services
{
	public interface IOrderService
	{
		Task<OrderDto> CreateOrderAsync(CreateOrderDto createOrderDto, CancellationToken cancellationToken);
		Task<OrderDto> GetOrderByIdAsync(int id, CancellationToken cancellationToken);
	}
}

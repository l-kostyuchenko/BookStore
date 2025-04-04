using BookStore.Domain.Dto.Order;
using SimpleResults;

namespace BookStore.Domain.Interfaces.Services
{
	public interface IOrderService
	{
		Task<Result<OrderDto>> CreateOrderAsync(CreateOrderDto createOrderDto, CancellationToken cancellationToken);
		Task<Result<OrderDto>> GetOrderByIdAsync(int id, CancellationToken cancellationToken);
	}
}

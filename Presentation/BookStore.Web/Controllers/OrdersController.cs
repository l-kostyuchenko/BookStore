using Asp.Versioning;
using BookStore.Domain.Dto.Order;
using BookStore.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using SimpleResults;

namespace BookStore.Web.Controllers
{
	[ApiController]
	[Route("api/v{version:apiVersion}/[controller]")]
	[ApiVersion("1.0")]
	public class OrdersController : ControllerBase
	{
		private readonly IOrderService _orderService;

		public OrdersController(IOrderService orderService)
		{
			_orderService = orderService;
		}

		[HttpPost]
		public async Task<ActionResult<OrderDto>> CreateOrder([FromBody] CreateOrderDto createOrderDto, CancellationToken cancellationToken)
		{
			var createdOrder = await _orderService.CreateOrderAsync(createOrderDto, cancellationToken);
			return Ok(createdOrder);

		}

		[HttpGet("{id}")]
		public async Task<Result<OrderDto>> GetOrder(int id, CancellationToken cancellationToken)
		{
			var order = await _orderService.GetOrderByIdAsync(id, cancellationToken);
			
			return order;
		}
	}
}

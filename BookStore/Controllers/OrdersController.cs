using BookStore.Domain.DTOs.Order;
using BookStore.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Web.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class OrdersController : ControllerBase
	{
		private readonly IOrderService _orderService;

		public OrdersController(IOrderService orderService)
		{
			_orderService = orderService;
		}

		[HttpPost]
		public async Task<ActionResult<OrderDto>> CreateOrder([FromBody] CreateOrderDto createOrderDto)
		{
			var createdOrder = await _orderService.CreateOrderAsync(createOrderDto);
			return CreatedAtAction(nameof(GetOrder), new { id = createdOrder.Id }, createdOrder);

		}

		[HttpGet("{id}")]
		public async Task<ActionResult<OrderDto>> GetOrder(int id)
		{
			var order = await _orderService.GetOrderByIdAsync(id);
			if (order == null)
			{
				return NotFound();
			}
			return Ok(order);
		}
	}
}

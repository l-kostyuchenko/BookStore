using BookStore.Domain.DTOs.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Interfaces.Services
{
	public interface IOrderService
	{
		Task<OrderDto> CreateOrderAsync(CreateOrderDto createOrderDto);
		Task<OrderDto> GetOrderByIdAsync(int id);
	}
}

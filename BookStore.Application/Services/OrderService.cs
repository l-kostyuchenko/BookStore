using BookStore.Domain.DTOs.Book;
using BookStore.Domain.DTOs.Category;
using BookStore.Domain.DTOs.Order;
using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces.Repositories;
using BookStore.Domain.Interfaces.Services;
using MapsterMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BookStore.Application.Services
{
	public class OrderService : IOrderService
	{
		private readonly IOrderRepository _repository;
		private readonly IMapper _mapper;

		public OrderService(IOrderRepository repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		public async Task<OrderDto> CreateOrderAsync(CreateOrderDto createOrderDto, CancellationToken cancellationToken)
		{
			var order = _mapper.Map<Order>(createOrderDto);
			order = await _repository.CreateAsync(order, cancellationToken);
			
			return _mapper.Map<OrderDto>(order);
		}

		public async Task<OrderDto> GetOrderByIdAsync(int id, CancellationToken cancellationToken)
		{
			var order = await _repository.GetByIdAsync(id, cancellationToken);

			return _mapper.Map<OrderDto>(order);
		}
	}
}

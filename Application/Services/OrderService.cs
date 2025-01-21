using AutoMapper;
using BookStore.Domain.DTOs.Book;
using BookStore.Domain.DTOs.Category;
using BookStore.Domain.DTOs.Order;
using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces.Repositories;
using BookStore.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
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

		public async Task<OrderDto> CreateOrderAsync(CreateOrderDto createOrderDto)
		{
			var order = _mapper.Map<Order>(createOrderDto);
			order = await _repository.CreateAsync(order);
			
			return _mapper.Map<OrderDto>(order);
		}

		public async Task<OrderDto> GetOrderByIdAsync(int id)
		{
			var order = await _repository.GetByIdAsync(id);

			return _mapper.Map<OrderDto>(order);
		}
	}
}

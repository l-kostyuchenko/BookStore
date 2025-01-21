using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Persistence.Repositories
{
	public class OrderRepository : IOrderRepository
	{
		private readonly BookStoreContext _context;

		public OrderRepository(BookStoreContext context)
		{
			_context = context;
		}

		public async Task<Order> CreateAsync(Order entity)
		{
			_context.Orders.Add(entity);
			await _context.SaveChangesAsync();
			return entity;
		}

		public async Task DeleteAsync(int id)
		{
			var order = await _context.Orders.FindAsync(id);
			if (order != null)
			{
				_context.Orders.Remove(order);
				await _context.SaveChangesAsync();
			}
		}

		public async Task<List<Order>> GetAllAsync()
		{
			var orders = await _context.Orders.Include(x => x.OrderItems).ToListAsync();

			return orders;
		}

		public async Task<Order> GetByIdAsync(int id)
		{
			var order = await _context.Orders
				.Include(x => x.OrderItems)
				.FirstOrDefaultAsync(b => b.Id == id);

			return order;
		}

		public async Task UpdateAsync(Order entity)
		{
			if (entity != null)
			{
				_context.Orders.Update(entity);
				await _context.SaveChangesAsync();
			}
		}
	}
}

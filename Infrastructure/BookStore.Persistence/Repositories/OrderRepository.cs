using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Persistence.Repositories
{
	public class OrderRepository : IOrderRepository
	{
		private readonly BookStoreContext _context;

		public OrderRepository(BookStoreContext context)
		{
			_context = context;
		}

		public async Task<Order> CreateAsync(Order entity, CancellationToken cancellationToken)
		{
			_context.Orders.Add(entity);
			await _context.SaveChangesAsync(cancellationToken);
			return entity;
		}

		public async Task DeleteAsync(int id, CancellationToken cancellationToken)
		{
			var order = await _context.Orders.FindAsync(id, cancellationToken);
			if (order != null)
			{
				_context.Orders.Remove(order);
				await _context.SaveChangesAsync(cancellationToken);
			}
		}

		public async Task<List<Order>> GetAllAsync(CancellationToken cancellationToken)
		{
			var orders = await _context.Orders.Include(x => x.OrderItems).ToListAsync(cancellationToken);

			return orders;
		}

		public async Task<Order> GetByIdAsync(int id, CancellationToken cancellationToken)
		{
			var order = await _context.Orders
				.Include(x => x.OrderItems)
				.FirstOrDefaultAsync(b => b.Id == id, cancellationToken);

			return order;
		}

		public async Task UpdateAsync(Order entity, CancellationToken cancellationToken)
		{
			if (entity != null)
			{
				_context.Orders.Update(entity);
				await _context.SaveChangesAsync(cancellationToken);
			}
		}
	}
}

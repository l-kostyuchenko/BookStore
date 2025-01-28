using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Persistence.Repositories
{
	public class CategoryRepository : ICategoryRepository
	{
		private readonly BookStoreContext _context;

		public CategoryRepository(BookStoreContext context)
		{
			_context = context;
		}

		public async Task<Category> CreateAsync(Category entity, CancellationToken cancellationToken)
		{
			_context.Categories.Add(entity);
			await _context.SaveChangesAsync(cancellationToken);
			return entity;
		}

		public async Task DeleteAsync(int id, CancellationToken cancellationToken)
		{
			var category = await _context.Categories.FindAsync(id, cancellationToken);
			if (category != null)
			{
				_context.Categories.Remove(category);
				await _context.SaveChangesAsync(cancellationToken);
			}
		}

		public async Task<List<Category>> GetAllAsync(CancellationToken cancellationToken)
		{
			var categories = await _context.Categories.ToListAsync(cancellationToken);

			return categories;
		}

		public async Task<Category> GetByIdAsync(int id, CancellationToken cancellationToken)
		{
			var category = await _context.Categories
				.FirstOrDefaultAsync(b => b.Id == id, cancellationToken);

			return category;
		}

		public async Task UpdateAsync(Category entity, CancellationToken cancellationToken)
		{
			if (entity != null)
			{
				_context.Categories.Update(entity);
				await _context.SaveChangesAsync(cancellationToken);
			}
		}

		public List<Category> GetByCondition(Func<Category, bool> condition)
		{
			var categories = _context.Categories.Where(condition).ToList();

			return categories;
		}
	}
}

using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Persistence.Repositories
{
	public class CategoryRepository : ICategoryRepository
	{
		private readonly BookStoreContext _context;

		public CategoryRepository(BookStoreContext context)
		{
			_context = context;
		}

		public async Task<Category> CreateAsync(Category entity)
		{
			_context.Categories.Add(entity);
			await _context.SaveChangesAsync();
			return entity;
		}

		public async Task DeleteAsync(int id)
		{
			var category = await _context.Categories.FindAsync(id);
			if (category != null)
			{
				_context.Categories.Remove(category);
				await _context.SaveChangesAsync();
			}
		}

		public async Task<List<Category>> GetAllAsync()
		{
			var categories = await _context.Categories.ToListAsync();

			return categories;
		}

		public async Task<Category> GetByIdAsync(int id)
		{
			var category = await _context.Categories
				.FirstOrDefaultAsync(b => b.Id == id);

			return category;
		}

		public async Task UpdateAsync(Category entity)
		{
			if (entity != null)
			{
				_context.Categories.Update(entity);
				await _context.SaveChangesAsync();
			}
		}
	}
}

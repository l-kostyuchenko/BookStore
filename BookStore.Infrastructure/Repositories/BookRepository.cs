using Domain.DTOs.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Persistence.Repositories
{
	public class BookRepository : IBookRepository
	{
		private readonly BookStoreContext _context;
		
		public BookRepository(BookStoreContext context)
		{
			_context = context;			
		}

		public async Task<List<Book>> GetAllAsync()
		{
			var books = await _context.Books
				.Include(b => b.Categories)
				.ToListAsync();

			return books;
		}

		public async Task<Book> GetByIdAsync(int id)
		{
			var book = await _context.Books
				.Include(b => b.Categories)
				.FirstOrDefaultAsync(b => b.Id == id);

			return book;
		}

		public async Task DeleteAsync(int id)
		{
			var book = await _context.Books.FindAsync(id);
			if (book != null)
			{
				_context.Books.Remove(book);
				await _context.SaveChangesAsync();
			}
		}

		public async Task UpdateAsync(Book entity)
		{
			if (entity != null)
			{
				_context.Books.Update(entity);
				await _context.SaveChangesAsync();
			}
		}

		public async Task<Book> CreateAsync(Book entity)
		{
			_context.Books.Add(entity);
			await _context.SaveChangesAsync();
			return entity;
		}
	}
}

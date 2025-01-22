using BookStore.Domain.DTOs.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Domain.Interfaces.Repositories;
using BookStore.Domain.Entities;
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

		public async Task<List<Book>> GetAllAsync(CancellationToken cancellationToken)
		{
			var books = await _context.Books
				.Include(b => b.Categories)
				.ToListAsync(cancellationToken);

			return books;
		}

		public async Task<Book> GetByIdAsync(int id, CancellationToken cancellationToken)
		{
			var book = await _context.Books
				.Include(b => b.Categories)
				.FirstOrDefaultAsync(b => b.Id == id, cancellationToken);

			return book;
		}

		public async Task DeleteAsync(int id, CancellationToken cancellationToken)
		{
			var book = await _context.Books.FindAsync(id, cancellationToken);
			if (book != null)
			{
				_context.Books.Remove(book);
				await _context.SaveChangesAsync(cancellationToken);
			}
		}

		public async Task UpdateAsync(Book entity, CancellationToken cancellationToken)
		{
			if (entity != null)
			{
				_context.Books.Update(entity);
				await _context.SaveChangesAsync(cancellationToken);
			}
		}

		public async Task<Book> CreateAsync(Book entity, CancellationToken cancellationToken)
		{
			_context.Books.Add(entity);
			await _context.SaveChangesAsync(cancellationToken);
			return entity;
		}
	}
}

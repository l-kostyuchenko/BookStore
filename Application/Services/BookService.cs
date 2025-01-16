using AutoMapper;
using BookStore.Infrastructure;
using Domain.DTOs.Book;
using Domain.Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
	public class BookService : IBookService
	{
		private readonly BookStoreContext _context;
		private readonly IMapper _mapper;

		public BookService(BookStoreContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task<List<BookDto>> GetAllBooksAsync()
		{
			var books = await _context.Books
			.Include(b => b.Categories)
			.ToListAsync();

			return _mapper.Map<List<BookDto>>(books);
		}

		public async Task<BookDetailsDto> GetBookByIdAsync(int id)
		{
			var book = await _context.Books
			.Include(b => b.Categories)
			.FirstOrDefaultAsync(b => b.Id == id);

			return _mapper.Map<BookDetailsDto>(book);
		}

		public async Task<BookDetailsDto> CreateBookAsync(CreateBookDto createBookDto)
		{
			var book = _mapper.Map<Book>(createBookDto);

			if (createBookDto.CategoryIds != null && createBookDto.CategoryIds.Any())
			{
				var categories = await _context.Categories
					.Where(c => createBookDto.CategoryIds.Contains(c.Id))
					.ToListAsync();

				book.Categories.AddRange(categories);
			}

			_context.Books.Add(book);
			await _context.SaveChangesAsync();
			return _mapper.Map<BookDetailsDto>(book);
		}

		public async Task UpdateBookAsync(int id, UpdateBookDto updateBookDto)
		{
			var book = await _context.Books.FindAsync(id);
			if (book == null)
			{
				return;
			}

			_mapper.Map(updateBookDto, book);
			book.Categories.Clear();

			if (updateBookDto.CategoryIds != null && updateBookDto.CategoryIds.Any())
			{
				var categories = await _context.Categories
					   .Where(c => updateBookDto.CategoryIds.Contains(c.Id))
					   .ToListAsync();
				book.Categories.AddRange(categories);
			}
			await _context.SaveChangesAsync();
		}

		public async Task DeleteBookAsync(int id)
		{
			var book = await _context.Books.FindAsync(id);
			if (book != null)
			{
				_context.Books.Remove(book);
				await _context.SaveChangesAsync();
			}
		}
	}
}

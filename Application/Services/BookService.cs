using AutoMapper;
using Domain.DTOs.Book;
using Domain.Interfaces.Services;
using Domain.Entities;
using Domain.Interfaces.Repositories;

namespace Application.Services
{
	public class BookService : IBookService
	{
		private readonly IBookRepository _repository;
		private readonly IMapper _mapper;

		public BookService(IBookRepository repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		public async Task<List<BookDto>> GetAllBooksAsync()
		{
			var books = await _repository.GetAllAsync();

			return _mapper.Map<List<BookDto>>(books);
		}

		public async Task<BookDto> GetBookByIdAsync(int id)
		{
			var book = await _repository.GetByIdAsync(id);

			return _mapper.Map<BookDto>(book);
		}

		public async Task<BookDto> CreateBookAsync(CreateBookDto createBookDto)
		{
			var book = _mapper.Map<Book>(createBookDto);

			//if (createBookDto.CategoryIds != null && createBookDto.CategoryIds.Any())
			//{
			//	var categories = await _context.Categories
			//		.Where(c => createBookDto.CategoryIds.Contains(c.Id))
			//		.ToListAsync();

			//	book.Categories.AddRange(categories);
			//}

			book = await _repository.CreateAsync(book);
			return _mapper.Map<BookDto>(book);
		}

		public async Task UpdateBookAsync(UpdateBookDto updateBookDto)
		{
			var book = _mapper.Map<Book>(updateBookDto);
						
			//book.Categories.Clear();
			//if (updateBookDto.CategoryIds != null && updateBookDto.CategoryIds.Any())
			//{
			//	var categories = await _context.Categories
			//		   .Where(c => updateBookDto.CategoryIds.Contains(c.Id))
			//		   .ToListAsync();
			//	book.Categories.AddRange(categories);
			//}

			await _repository.UpdateAsync(book);
		}

		public async Task DeleteBookAsync(int id)
		{
			await _repository.DeleteAsync(id);
		}
	}
}

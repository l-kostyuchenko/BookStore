using BookStore.Domain.Dto.Book;
using BookStore.Domain.Interfaces.Services;
using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces.Repositories;
using MapsterMapper;
using Serilog;

namespace BookStore.Application.Services
{
	public class BookService : IBookService
	{
		private readonly IBookRepository _repository;
		private readonly ICategoryRepository _categoryRepository;
		private readonly IMapper _mapper;
		private readonly ILogger _logger;

		public BookService(IBookRepository repository, ICategoryRepository categoryRepository, 
			IMapper mapper, ILogger logger)
		{
			_repository = repository;
			_categoryRepository = categoryRepository;
			_mapper = mapper;
			_logger = logger.ForContext<BookService>();
		}

		public async Task<List<BookDto>> GetPageBooksAsync(int page, int pageSize, CancellationToken cancellationToken)
		{
			if (page < 1)
				page = 1;

			if (pageSize < 1)
				pageSize = 10;

			var books = await _repository.GetPageAsync(page, pageSize, cancellationToken);

			return _mapper.Map<List<BookDto>>(books);
		}

		public async Task<BookDto> GetBookByIdAsync(int id, CancellationToken cancellationToken)
		{
			var book = await _repository.GetByIdAsync(id, cancellationToken);

			return _mapper.Map<BookDto>(book);
		}

		public async Task<BookDto> CreateBookAsync(CreateBookDto createBookDto, CancellationToken cancellationToken)
		{
			var book = _mapper.Map<Book>(createBookDto);

			if (createBookDto.CategoryIds.Any())
			{
				var categories = _categoryRepository.GetByCondition(c => createBookDto.CategoryIds.Contains(c.Id));
				book.Categories.AddRange(categories);
			}

			book = await _repository.CreateAsync(book, cancellationToken);

			_logger.Information("Создана книга с ИД={bookId}", book.Id);
			return _mapper.Map<BookDto>(book);
		}

		public async Task UpdateBookAsync(UpdateBookDto updateBookDto, CancellationToken cancellationToken)
		{
			var book = _mapper.Map<Book>(updateBookDto);

			book.Categories.Clear();
			if (updateBookDto.CategoryIds.Any())
			{
				var categories = _categoryRepository.GetByCondition(c => updateBookDto.CategoryIds.Contains(c.Id));
				book.Categories.AddRange(categories);
			}

			await _repository.UpdateAsync(book, cancellationToken);
		}

		public async Task DeleteBookAsync(int id, CancellationToken cancellationToken)
		{
			await _repository.DeleteAsync(id, cancellationToken);
			_logger.Information("Удалена книга с ИД={id}", id);
		}
	}
}

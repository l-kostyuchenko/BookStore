using Asp.Versioning;
using BookStore.Domain.DTOs.Book;
using BookStore.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Web.Controllers
{
	[ApiController]
	[Route("api/v{version:apiVersion}/[controller]")]
	[ApiVersion("1.0")]
	[ApiVersion("1.1")]
	public class BooksController : ControllerBase
	{
		private readonly IBookService _bookService;

		public BooksController(IBookService bookService)
		{
			_bookService = bookService;
		}

		/// <summary>
		/// Получить все книги
		/// </summary>
		[HttpGet]
		public async Task<ActionResult<IEnumerable<BookDto>>> GetBooks(CancellationToken cancellationToken)
		{
			var books = await _bookService.GetAllBooksAsync(cancellationToken);
			return Ok(books);
		}

		/// <summary>
		/// Получить книгу по ИД
		/// </summary>
		[HttpGet("{id}")]
		public async Task<ActionResult<BookDto>> GetBook(int id, CancellationToken cancellationToken)
		{
			var book = await _bookService.GetBookByIdAsync(id, cancellationToken);
			if (book == null)
			{
				return NotFound();
			}
			return Ok(book);
		}

		/// <summary>
		/// Создание книги
		/// </summary>
		/// <param name="createBookDto">Книга</param>
		/// <returns></returns>
		[HttpPost]
		public async Task<ActionResult<BookDto>> CreateBook([FromBody] CreateBookDto createBookDto, CancellationToken cancellationToken)
		{
			var createdBook = await _bookService.CreateBookAsync(createBookDto, cancellationToken);
			return CreatedAtAction(nameof(GetBook), new { id = createdBook.Id }, createdBook);
		}

		/// <summary>
		/// Редактирование книги
		/// </summary>
		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateBook([FromBody] UpdateBookDto updateBookDto, CancellationToken cancellationToken)
		{
			await _bookService.UpdateBookAsync(updateBookDto, cancellationToken);
			return NoContent();
		}

		/// <summary>
		/// Удаление книги
		/// </summary>
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteBook(int id, CancellationToken cancellationToken)
		{
			await _bookService.DeleteBookAsync(id, cancellationToken);
			return NoContent();
		}
	}	
}

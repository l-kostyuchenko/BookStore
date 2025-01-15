using BookStore.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class BooksController : ControllerBase
	{
		private readonly IBookService _bookService;

		public BooksController(IBookService bookService)
		{
			_bookService = bookService;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<BookDto>>> GetBooks()
		{
			var books = await _bookService.GetAllBooksAsync();
			return Ok(books);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<BookDetailsDto>> GetBook(int id)
		{
			var book = await _bookService.GetBookByIdAsync(id);
			if (book == null)
			{
				return NotFound();
			}
			return Ok(book);
		}


		[HttpPost]
		public async Task<ActionResult<BookDetailsDto>> CreateBook([FromBody] CreateBookDto createBookDto)
		{
			var createdBook = await _bookService.CreateBookAsync(createBookDto);
			return CreatedAtAction(nameof(GetBook), new { id = createdBook.Id }, createdBook);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateBook(int id, [FromBody] UpdateBookDto updateBookDto)
		{
			await _bookService.UpdateBookAsync(id, updateBookDto);
			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteBook(int id)
		{
			await _bookService.DeleteBookAsync(id);
			return NoContent();
		}
	}

	public interface IBookService
	{
		Task<List<BookDto>> GetAllBooksAsync();
		Task<BookDetailsDto> GetBookByIdAsync(int id);
		Task<BookDetailsDto> CreateBookAsync(CreateBookDto createBookDto);
		Task UpdateBookAsync(int id, UpdateBookDto updateBookDto);
		Task DeleteBookAsync(int id);
	}
}

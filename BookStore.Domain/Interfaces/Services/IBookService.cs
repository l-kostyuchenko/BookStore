using BookStore.Domain.Dto.Book;

namespace BookStore.Domain.Interfaces.Services
{
	public interface IBookService
	{
		/// <summary>
		/// Получить книги из БД
		/// </summary>
		/// <param name="cancellationToken"></param>
		/// <returns>Все книги</returns>		
		Task<List<BookDto>> GetPageBooksAsync(int page, int pageSize, CancellationToken cancellationToken);

		/// <summary>
		/// Получить книгу из БД по ИД
		/// </summary>
		/// <param name="id">ИД книги</param>
		/// <param name="cancellationToken"></param>
		/// <returns>Книга</returns>
		Task<BookDto> GetBookByIdAsync(int id, CancellationToken cancellationToken);

		/// <summary>
		/// Создать новую книгу
		/// </summary>
		/// <param name="createBookDto">Новая книга</param>
		/// <param name="cancellationToken"></param>
		/// <returns>Созданная книга</returns>
		Task<BookDto> CreateBookAsync(CreateBookDto createBookDto, CancellationToken cancellationToken);
		
		/// <summary>
		/// Обновить данные существующей книги
		/// </summary>
		/// <param name="updateBookDto">Книга</param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		Task UpdateBookAsync(UpdateBookDto updateBookDto, CancellationToken cancellationToken);
		
		/// <summary>
		/// Удалить книгу
		/// </summary>
		/// <param name="id">ИД книги</param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		Task DeleteBookAsync(int id, CancellationToken cancellationToken);
	}
}

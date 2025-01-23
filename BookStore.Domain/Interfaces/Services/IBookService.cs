using BookStore.Domain.DTOs.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Interfaces.Services
{
    public interface IBookService
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		Task<List<BookDto>> GetAllBooksAsync(CancellationToken cancellationToken);
		Task<BookDto> GetBookByIdAsync(int id, CancellationToken cancellationToken);
		Task<BookDto> CreateBookAsync(CreateBookDto createBookDto, CancellationToken cancellationToken);
		Task UpdateBookAsync(UpdateBookDto updateBookDto, CancellationToken cancellationToken);
		Task DeleteBookAsync(int id, CancellationToken cancellationToken);
	}
}

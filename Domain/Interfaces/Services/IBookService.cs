using Domain.DTOs.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IBookService
	{
		Task<List<BookDto>> GetAllBooksAsync();
		Task<BookDetailsDto> GetBookByIdAsync(int id);
		Task<BookDetailsDto> CreateBookAsync(CreateBookDto createBookDto);
		Task UpdateBookAsync(int id, UpdateBookDto updateBookDto);
		Task DeleteBookAsync(int id);
	}
}

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
		Task<List<BookDto>> GetAllBooksAsync();
		Task<BookDto> GetBookByIdAsync(int id);
		Task<BookDto> CreateBookAsync(CreateBookDto createBookDto);
		Task UpdateBookAsync(UpdateBookDto updateBookDto);
		Task DeleteBookAsync(int id);
	}
}

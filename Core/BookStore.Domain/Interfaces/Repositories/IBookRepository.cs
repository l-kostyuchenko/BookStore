using BookStore.Domain.Entities;

namespace BookStore.Domain.Interfaces.Repositories
{
	public interface IBookRepository : IRepository<Book>
	{
		Task<List<Book>> GetPageAsync(int page, int pageSize, CancellationToken cancellationToken);		
	}
}

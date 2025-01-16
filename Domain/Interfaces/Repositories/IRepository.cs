using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface IRepository<T> where T : BaseEntity
	{
		Task<List<Book>> GetAllAsync();
		Task<Book> GetByIdAsync(int id);
		Task DeleteAsync(int id);
		Task UpdateAsync(Book entity);
		Task<int> CreateAsync(Book entity);
	}
}

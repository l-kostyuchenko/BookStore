using BookStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Interfaces.Repositories
{
    public interface IRepository<T> where T : BaseEntity
	{
		Task<List<T>> GetAllAsync();
		Task<T> GetByIdAsync(int id);
		Task DeleteAsync(int id);
		Task UpdateAsync(T entity);
		Task<T> CreateAsync(T entity);
	}
}

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
		Task<List<T>> GetAllAsync(CancellationToken cancellationToken);
		Task<T> GetByIdAsync(int id, CancellationToken cancellationToken);
		Task DeleteAsync(int id, CancellationToken cancellationToken);
		Task UpdateAsync(T entity, CancellationToken cancellationToken);
		Task<T> CreateAsync(T entity, CancellationToken cancellationToken);
	}
}

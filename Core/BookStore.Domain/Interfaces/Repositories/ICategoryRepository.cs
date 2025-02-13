using BookStore.Domain.Entities;

namespace BookStore.Domain.Interfaces.Repositories
{
	public interface ICategoryRepository : IRepository<Category>
	{
		List<Category> GetByCondition(Func<Category, bool> condition);
	}
}

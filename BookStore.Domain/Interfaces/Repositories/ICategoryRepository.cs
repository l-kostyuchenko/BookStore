using BookStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Interfaces.Repositories
{
	public interface ICategoryRepository : IRepository<Category>
	{
		List<Category> GetByCondition(Func<Category, bool> condition);
	}
}

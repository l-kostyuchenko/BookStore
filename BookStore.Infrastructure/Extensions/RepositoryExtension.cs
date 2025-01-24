using BookStore.Persistence.Repositories;
using BookStore.Domain.Interfaces.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BookStore.Persistence.Extensions
{
	public static class RepositoryExtension
	{
		public static void AddPersistence(this IServiceCollection services)
		{
			services.AddScoped<IBookRepository, BookRepository>();
			services.AddScoped<ICategoryRepository, CategoryRepository>();
			services.AddScoped<IOrderRepository, OrderRepository>();
		}
	}
}

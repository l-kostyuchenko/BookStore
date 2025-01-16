using Application.Services;
using Domain.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Extensions
{
	public static class DependencyInjectionExtension
	{
		public static void AddDependencies(this IServiceCollection services)
		{
			services.AddScoped<IBookService, BookService>();			
		}
	}
}

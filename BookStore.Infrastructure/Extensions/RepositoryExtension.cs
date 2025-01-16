using BookStore.Infrastructure.Repositories;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Infrastructure.Extensions
{
	public static class RepositoryExtension
	{
		public static void AddRepositories(this IServiceCollection services)
		{
			services.AddScoped<IBookRepository, BookRepository>();
		}
	}
}

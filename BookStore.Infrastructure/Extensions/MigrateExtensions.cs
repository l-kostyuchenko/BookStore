using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Infrastructure.Extensions
{
	public static class MigrateExtensions
	{
		public static void UseDBMigration(this IServiceProvider provider)
		{
			using var scope = provider.CreateScope();
			var dbcontext = scope.ServiceProvider.GetRequiredService<BookStoreContext>();
			dbcontext.Database.Migrate();
		}
	}
}

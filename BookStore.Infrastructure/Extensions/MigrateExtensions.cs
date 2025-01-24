using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BookStore.Persistence.Extensions
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

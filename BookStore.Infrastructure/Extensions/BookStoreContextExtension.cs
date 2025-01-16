using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Infrastructure.Extensions
{
    public static class BookStoreContextExtension
    {
        public static void AddContextExtension(this IServiceCollection services, IConfigurationManager configuration)
        {
            services.AddDbContext<BookStoreContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("BookStoreDatabase"))
                .UseSnakeCaseNamingConvention());
        }
    }
}

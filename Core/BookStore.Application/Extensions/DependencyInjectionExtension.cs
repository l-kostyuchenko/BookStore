using BookStore.Application.Mapper;
using BookStore.Application.Services;
using BookStore.Domain.Interfaces.Services;
using Mapster;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;

namespace BookStore.Application.Extensions
{
	public static class DependencyInjectionExtension
	{
		public static void AddApplication(this IServiceCollection services)
		{
			services.AddScoped<IBookService, BookService>();
			services.AddScoped<ICategoryService, CategoryService>();
			services.AddScoped<IOrderService, OrderService>();

			services.AddSingleton(TypeAdapterConfig.GlobalSettings);
			services.AddSingleton(() =>
			{
				var config = new TypeAdapterConfig();
				new RegisterMapper().Register(config);
				return config;
			});
			services.AddScoped<IMapper, ServiceMapper>();
		}
	}
}

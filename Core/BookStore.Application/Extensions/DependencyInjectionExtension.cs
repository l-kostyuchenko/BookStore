using BookStore.Application.Mapper;
using BookStore.Application.Services;
using BookStore.Domain.Interfaces.Services;
using Mapster;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;
using Refit;
//using Warehouse.Client.Interfaces;

namespace BookStore.Application.Extensions
{
	public static class DependencyInjectionExtension
	{
		public static void AddApplication(this IServiceCollection services)
		{
			services.AddScoped<IBookService, BookService>();
			services.AddScoped<ICategoryService, CategoryService>();
			services.AddScoped<IOrderService, OrderService>();

			//services.AddRefitClient<IWarehouseApi>().ConfigureHttpClient(c => c.BaseAddress = new Uri("localhost:5001"));

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

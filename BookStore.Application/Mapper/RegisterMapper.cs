using BookStore.Domain.Dto.Book;
using BookStore.Domain.Entities;
using Mapster;

namespace BookStore.Application.Mapper
{
	public class RegisterMapper : IRegister
	{
		public void Register(TypeAdapterConfig config)
		{
			config.NewConfig<Book, BookDto>()
				.RequireDestinationMemberSource(true);
		}
	}
}

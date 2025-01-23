using BookStore.Domain.DTOs.Book;
using BookStore.Domain.Entities;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

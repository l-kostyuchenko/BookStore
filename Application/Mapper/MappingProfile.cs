using AutoMapper;
using Domain.DTOs.Book;
using Domain.DTOs.Category;
using Domain.DTOs.Order;
using Domain.Entities;

namespace Application.Mapper
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<Book, BookDto>()
				.ForMember(dest => dest.Categories, opt => opt.MapFrom(src => src.Categories.Select(c => c.Name).ToList()));

			CreateMap<CreateBookDto, Book>();
			CreateMap<UpdateBookDto, Book>();

			CreateMap<Category, CategoryDto>();
			CreateMap<CreateCategoryDto, Category>();

			CreateMap<Order, OrderDto>()
				.ForMember(dest => dest.OrderItems, opt => opt.MapFrom(src => src.OrderItems));
			
			CreateMap<OrderItem, OrderItemDetailsDto>()
				.ForMember(dest => dest.BookTitle, opt => opt.MapFrom(src => src.Book.Title))
				.ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Book.Author));
		}
	}
}
